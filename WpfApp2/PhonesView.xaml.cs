using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для PhonesView.xaml
    /// </summary>
    public partial class PhonesView : UserControl, INotifyPropertyChanged
    {
        public PhonesView()
        {
            InitializeComponent();
            OnPropertyChanged("LastPhone");
        }

        private void Phones_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RefreshPhonesGrid();
            OnPropertyChanged("LastPhone");
        }

        public static readonly DependencyProperty PhonesProperty = DependencyProperty.Register("Phones", typeof(ObservableCollection<Phone>), typeof(PhonesView), new PropertyMetadata(null, OnPhonesPropertyChangedCallback));

        private static void OnPhonesPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PhonesView)d).Phones.CollectionChanged += ((PhonesView)d).Phones_CollectionChanged;
            ((PhonesView)d).RefreshPhonesGrid();
            ((PhonesView)d).OnPropertyChanged("LastPhone");

        }

        private void RefreshPhonesGrid()
        {
            PhonesGrid.Children.Clear();
            foreach (var p in Phones)
            {
                OnePhoneView onePhoneView = new OnePhoneView() { DataContext = p };
                onePhoneView.Phone = p;
                PhonesGrid.Children.Add(onePhoneView);
            }
        }



        public ObservableCollection<Phone> Phones
        {
            get { return (ObservableCollection<Phone>)GetValue(PhonesProperty); }
            set { SetValue(PhonesProperty, value); }
        }


        public Phone LastPhone
        {
            get
            {
                if (Phones==null || Phones.Count == 0) return new Phone("---", 0);
                else return Phones.Last();
            }
        }


        public static readonly DependencyProperty SelectedPhoneProperty = DependencyProperty.Register("SelectedPhone", typeof(Phone), typeof(PhonesView));
        public Phone SelectedPhone
        {
            get { return (Phone)GetValue(SelectedPhoneProperty); }
            set { SetValue(SelectedPhoneProperty, value); }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
