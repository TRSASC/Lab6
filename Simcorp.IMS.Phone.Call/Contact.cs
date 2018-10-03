using System.Collections.Generic;

namespace Simcorp.IMS.Phone.Calls {
    public class Contact {
        private string name;
        private List<string> numbers;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<string> Numbers
        {
            get { return numbers; }
            set { numbers = value; }
        }

        public Contact(string name, string number) {
            Name = name;
            Numbers = new List<string> { number };
        }

        public Contact(string name, List<string> numbers) {
            Name = name;
            Numbers = numbers;
        }

        public void AddNumber(string number) {
            Numbers.Add(number);
        }

        public void RemoveNumber(string number) {
            Numbers.Remove(number);
        }
    }
}
