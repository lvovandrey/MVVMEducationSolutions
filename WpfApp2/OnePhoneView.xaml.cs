using System.Windows;
using System.Windows.Controls;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для OnePhoneView.xaml
    /// </summary>
    public partial class OnePhoneView : UserControl
    {
        public OnePhoneView()
        {
            InitializeComponent();
            
        }

        public static readonly DependencyProperty PhoneProperty = DependencyProperty.Register("Phone", typeof(Phone), typeof(PhonesView));
        public Phone Phone
        {
            get { return (Phone)GetValue(PhoneProperty); }
            set { SetValue(PhoneProperty, value); }
        }
    }
}
