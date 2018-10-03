using System.Collections.Generic;

namespace Simcorp.IMS.Phone.Calls {
    public class CallsComparer : IComparer<PhoneCall> {
        public int Compare(PhoneCall x, PhoneCall y) {
            if (x == null && y == null) { return 0; }
            if (y == null) { return -1; }
            if (x == null) { return 1; }
            int dummy = y.CallTime.CompareTo(x.CallTime);
            return dummy;
        }
    }
}
