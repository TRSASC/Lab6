using System;
using System.Collections.Generic;
using System.Linq;

namespace Simcorp.IMS.Phone.Calls {
    public class CallGenerator {
        public delegate void CallReceivedDelegate(PhoneCall call);
        public event CallReceivedDelegate CallReceived;
        public ContactStorage AllContacts;

        public CallGenerator(ContactStorage allContacts) {
            AllContacts = allContacts;
        }

        public void MakeCall() {
            string number = GenerateNumber(AllContacts.ContactList);
            bool incoming = GenerateIncoming();
            Contact contact = DetectContact(number, AllContacts.ContactList);
            PhoneCall call = new PhoneCall(number, incoming, contact);
            RaiseCallReseivedEvent(call);
        }

        private void RaiseCallReseivedEvent(PhoneCall call) {
            var handler = CallReceived;
            if (handler != null) {
                handler(call);
            }
        }

        private static Contact DetectContact(string number, List<Contact> allContacts) {
            List<Contact> query = allContacts.
                                            Where(m => m.Numbers.Contains(number)).
                                            Select(m => m).ToList();
            switch (query.Count) {
                case 0:
                return null;
                case 1:
                return query[0];
                default:
                throw new Exception("It is Not possible to detect contact");
            }
        }
        private static string GenerateNumber(List<Contact> allContacts) {
            List<string> allNumbers = new List<string>();
            foreach (Contact contact in allContacts) {
                allNumbers.AddRange(contact.Numbers);
            }
            Random rnd = new Random();
            int resVal = rnd.Next(0, allNumbers.Count);
            return allNumbers[resVal];
        }

        private static bool GenerateIncoming() {
            Random rnd = new Random();
            int inc = rnd.Next(0, 2);
            return (inc == 1) ? true : false;
        }
    }
}
