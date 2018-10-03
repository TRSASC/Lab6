using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simcorp.IMS.Phone;
using Simcorp.IMS.Phone.Output;
using Simcorp.IMS.Phone.Calls;

namespace SMSPhone {

    public delegate void AddCall(PhoneCall call);
    public delegate void UpdateProgBar();

    public partial class SMSPhone : Form {
        private SimCorpMobile simCorp;
        private AddCall CallAdder;
        private UpdateProgBar UpdProgBar;
        private MsgStorage MsgData=new MsgStorage();
        private bool CallButtonClicked;
        private bool bCharge = false;
        private bool bDischarge = true;
        Task SMSGenTask;
        Task BatteryChargeTask;
        Task BatteryDischargeTask;
        
        public SMSPhone() {
            CallButtonClicked = false;

            simCorp = new SimCorpMobile(new ListViewOutput(CallListView));
            CallAdder += AddCallToTextBox;
            simCorp.CallStor.CallAdded += OnCallAdded;
            simCorp.CallStor.CallRemoved += OnCallRemoved;

            InitializeComponent();


            ChargeProgressBar.Value = simCorp.Battery.GetCurrentCharge();
            UpdProgBar += OnChargeChanged;
            BatteryDischargeTask = new Task(() => { Discharge(); });
            BatteryDischargeTask.Start();
            simCorp.Battery.ChargeChanged += OnChargeLevelChanged;
        }

        private void Discharge() {
            while (bDischarge) {
                simCorp.Discharge(10);
                BatteryDischargeTask.Wait(1000);
            }
        }

        private void OnChargeLevelChanged() {
            try {
                Invoke(UpdProgBar, new object[] { });
            } catch { bCharge = bDischarge = false; }
        }

        private void OnChargeChanged() {
            ChargeProgressBar.Value = (int)simCorp.Battery.GetCurrentCharge();
        }

        private void OnCallAdded(PhoneCall call) {
            try {
                Invoke(CallAdder, new object[] { call });
            } catch { CallButtonClicked = false; }    
        }

        public void AddCallToTextBox(PhoneCall call) {
            DisplayAll(simCorp.CallStor.CallList);
        }

        private void OnCallRemoved(PhoneCall call) {
            DisplayAll(simCorp.CallStor.CallList);
        }

        private void DisplayAll(List<PhoneCall> callList) {
            CallListView.Items.Clear();
            DisplayCalls(callList);
        }

        private void DisplayCalls(List<PhoneCall> callList) {
            PhoneCall lastCall = null;
            int numOfCalls = 1;
            foreach (PhoneCall call in callList) {
                if (!call.Equals(lastCall)) {
                    if (lastCall != null) { ShowCall(lastCall, numOfCalls); }
                    numOfCalls = 1;
                    lastCall = call;
                } else {
                    numOfCalls++;
                }
            }
            ShowCall(lastCall, numOfCalls);
        }

        private void ShowCall(PhoneCall call, int numOfCalls) {
            string name;
            if (numOfCalls==1) {
                name = call.GetContactName();
            } else {
                name = call.GetContactName() + " (" + numOfCalls.ToString() + ")";
            }
            string number = call.CallNumber;
            string type = call.GetCallType();
            CallListView.Items.Add(new ListViewItem(new[] { name, number, type,}));
        }

        private void SMSButton_Click(object sender, EventArgs e) {
            CallButtonClicked = !CallButtonClicked;
            if ( CallButtonClicked ) {
                SMSButton.Text = "Stop generate calls";
                SMSGenTask = new Task(() => {
                    while (CallButtonClicked) {
                        simCorp.GenCall();
                        SMSGenTask.Wait(1000);
                    }
                });
                SMSGenTask.Start();
            } else {
                SMSButton.Text = "Generate calls";
            }
        }


        private void ChargeButton_Click(object sender, EventArgs e) {
            bCharge = !bCharge;
            bDischarge = !bDischarge;
            if (bCharge) {
                ChargeButton.Text = "Stop charging";
                BatteryChargeTask = new Task(() => {
                    while (bCharge) {
                        simCorp.Charge(30);
                        BatteryChargeTask.Wait(1000);
                    }
                });
                BatteryChargeTask.Start();
            } else {
                ChargeButton.Text = "Charge";
                BatteryDischargeTask = new Task(() => { Discharge(); });
                BatteryDischargeTask.Start();
            }
        }

        private void SMSPhone_Load(object sender, EventArgs e) {

        }
    }
}
