using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simcorp.IMS.Phone.Calls;

namespace SortingTest {
    
    public class PhoneCall1 : PhoneCall {
        public PhoneCall1(string number, bool incoming, Contact cont) : base(number, incoming, cont) { }
        protected override DateTime GetTime() { return new DateTime(2018,10 ,1); }
    }

    public class PhoneCall2 : PhoneCall {
        public PhoneCall2(string number, bool incoming, Contact cont) : base(number, incoming, cont) { }
        protected override DateTime GetTime() { return new DateTime(2018, 10, 2); }
    }

    public class PhoneCall3 : PhoneCall {
        public PhoneCall3(string number, bool incoming, Contact cont) : base(number, incoming, cont) { }
        protected override DateTime GetTime() { return new DateTime(2018, 10, 3); }
    }

    [TestClass]
    public class SortTest {
        public void OnCallDummy(PhoneCall call) {
            ///Dummy event action: nothing to do
        }

        private CallStorage CallStor;
        private List<PhoneCall> expCallList;
        private Contact cont = new Contact("Taras", "123");
        

        [TestMethod]
        public void AddTest() {
            PhoneCall1 call1 = new PhoneCall1("123", true, cont);
            PhoneCall2 call2 = new PhoneCall2("123", false, cont);
            PhoneCall3 call3 = new PhoneCall3("123", true, cont);
            expCallList = new List<PhoneCall> { call3, call2, call1 };
            CallStor = new CallStorage(new List<PhoneCall> { call1, call2 });
            CallStor.CallAdded += OnCallDummy;

            CallStor.Add(call3);

            Assert.IsTrue(expCallList.SequenceEqual(CallStor.CallList));
        }

        [TestMethod]
        public void RemoveTest() {
            PhoneCall1 call1 = new PhoneCall1("123", true, cont);
            PhoneCall2 call2 = new PhoneCall2("123", false, cont);
            PhoneCall3 call3 = new PhoneCall3("123", true, cont);
            expCallList = new List<PhoneCall> { call3, call1 };
            CallStor = new CallStorage(new List<PhoneCall> { call2, call3, call1 });
            CallStor.CallRemoved += OnCallDummy;

            CallStor.Remove(call2);

            Assert.IsTrue(expCallList.SequenceEqual(CallStor.CallList));
        }
    }
}
