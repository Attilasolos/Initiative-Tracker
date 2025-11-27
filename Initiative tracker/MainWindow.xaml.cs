using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Initiative_tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Karakter> karakterek = new List<Karakter>();
        public MainWindow()
        {
            InitializeComponent();
            
            karakterek = Karakter.Read(); 
            
            foreach(var k in karakterek)
            {
                lstbx1.Items.Add(k.Nev);
            }

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int Index = lstbx1.SelectedIndex;
            Nmbx.Text = $"Name: {karakterek[Index].Nev}";
            Hpbx.Text = $"HP: {karakterek[Index].HP}";
            if (karakterek[Index].Akcio == true)
            {
                ACCB.IsChecked = true;
            }
            else
            {
                ACCB.IsChecked = false ;
            }
            if (karakterek[Index].Bonusz_Akcio == true)
            {
                BACB.IsChecked = true;
            }
            else
            {
                BACB.IsChecked = false;
            }
            if (karakterek[Index].Reakcio == true)
            { 
                RCB.IsChecked = true ;
            }
            else
            {
                RCB.IsChecked = false;
            }
            BTDP.SelectedDate = karakterek[Index].Szuletesi_Datum;

            Bbx.Text = $"Bónusz: {karakterek[Index].Bonusz}";

            Ibx.Text = $"Initiative: {karakterek[Index].Rendezesi_Ertek}";
        }

        private void ACCB_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void BACB_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void RCB_Checked(object sender, RoutedEventArgs e)
        {
            
        }
    }
}