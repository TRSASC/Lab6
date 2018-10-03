using System;

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
        public static bool operator ==(PhoneCall x, PhoneCall y) {
            return x.Equals(y);
        }
        public static bool operator !=(PhoneCall x, PhoneCall y) {
            return !Equals(x,y);
        }

        public override bool Equals(object obj) {
            if (obj == null) { return false; }
            if (ReferenceEquals(obj, this)) { return true; }
            if (obj.GetType() != this.GetType()) { return false; }
            PhoneCall phc = obj as PhoneCall;
            return this.CallNumber == phc.CallNumber && this.Incoming == phc.Incoming;
        }

        public override int GetHashCode() {
            return this.CallNumber.GetHashCode() ^ this.Incoming.GetHashCode();
        }
    }
}
