using System;
using System.Collections.Generic;
using System.Linq;

namespace Simcorp.IMS.Phone.Calls {
    public class CallStorage {
        public delegate void CallAddedDelegate(PhoneCall call);
        public event CallAddedDelegate CallAdded;
        public delegate void CallRemovedDelegate(PhoneCall call);
        public event CallRemovedDelegate CallRemoved;

        public List<PhoneCall> CallList { get; set; }

        public CallStorage() {
            CallList = new List<PhoneCall>();
        }

        public CallStorage(List<PhoneCall> call) {
            CallList = call;
            CallList.Sort(new CallsComparer());
        }

        public void Add(PhoneCall call) {
            CallList.Add(call);
            CallList.Sort(new CallsComparer());
            CallAdded(call);
        }

        public void Remove(PhoneCall call) {
            CallList.Remove(call);
            CallList.Sort(new CallsComparer());
            CallRemoved(call);
        }
    }
}

