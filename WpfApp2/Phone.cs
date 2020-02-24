using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class Phone: INPCBase 
    {
        public Phone(string _name, int _count)
        {
            Name = _name;
            Count = _count;
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; OnPropertyChanged("Count"); }
        }

    }
}
