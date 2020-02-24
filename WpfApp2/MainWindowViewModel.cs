using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class MainWindowViewModel:INPCBase
    {
        public MainWindowViewModel()
        {
            Phones = new ObservableCollection<Phone>
            {
                new Phone("IPhone", 10),
                new Phone("Samsung",12),
                new Phone("Redmi", 15)
            };
        }

        public ObservableCollection<Phone> Phones { get; set; }

        private Phone selectedPhone;
        public Phone SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        internal void AddPhone()
        {
            Phones.Add(new Phone("Телефон", Phones.Count));
        }
    }
}
