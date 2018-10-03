using System;
using System.Collections.Generic;
using System.Linq;

namespace Simcorp.IMS.Phone.Calls {
    public class PhoneCall {
        private Contact contact;
        public string CallNumber { get; set; }
        public bool Incoming { get; set; }
        public DateTime CallTime { get; set; }

        public PhoneCall(string number, bool incoming, Contact cont) {
            CallNumber = number;
            Incoming = incoming;
            CallTime = GetTime();
            contact = cont;
        }

        public string GetCallType() {
            return Incoming ? "Incoming": "Outcoming";
        }

        public string GetContactName() {
            return contact.Name;
        }

        protected virtual DateTime GetTime() {
            return DateTime.Now;
        }
    }
}
