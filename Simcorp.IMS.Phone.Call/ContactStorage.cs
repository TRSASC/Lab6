using System.Collections.Generic;

namespace Simcorp.IMS.Phone.Calls {
    public class ContactStorage {
        public List<Contact> ContactList { get; set; }

        public ContactStorage() {
            ContactList = new List<Contact>();
        }

        public ContactStorage(List<Contact> contactList) {
            ContactList = contactList;
        }

        public void Add(Contact contact) {
            ContactList.Add(contact);
        }

        public void Remove(Contact contact) {
            ContactList.Remove(contact);
        }
    }
}
