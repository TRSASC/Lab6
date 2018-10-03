using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simcorp.IMS.Phone.Calls;

namespace SortingTest {

    [TestClass]
    public class EqualsTest {
        Contact cont1 = new Contact("Taras", new List<string> { "123", "444" });

        [TestMethod]
        public void DifCallTypeTest() {
            PhoneCall call1 = new PhoneCall("123", true, cont1);
            PhoneCall call2 = new PhoneCall("123", false, cont1);

            bool res = call1.Equals(call2);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void DifNumsTest() {
            PhoneCall call1 = new PhoneCall("123", true, cont1);
            PhoneCall call2 = new PhoneCall("444", true, cont1);

            bool res = call1.Equals(call2);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void EqualCallsTest() {
            PhoneCall call1 = new PhoneCall("123", true, cont1);
            PhoneCall call2 = new PhoneCall("123", true, cont1);

            bool res = call1.Equals(call2);

            Assert.IsTrue(res);
        }
    }
}
