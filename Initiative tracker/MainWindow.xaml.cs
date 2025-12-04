using System.ComponentModel;
using System.IO;
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
        private int Index = 0;
        private bool mehet = false;
        
        public MainWindow()
        {
            InitializeComponent();
            
            karakterek = Karakter.LoadFromJson();
            
            Frissit();
            lstbx1.SelectedIndex = 0;
            mehet = true;


        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Index = lstbx1.SelectedIndex;
            Listaválasztás(Index);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            randomolas();
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (eraseCB.SelectedIndex != -1)
            {
                Törlés(eraseCB.SelectedIndex);
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UjKarakter();
        }


        private void ACCB_Checked(object sender, RoutedEventArgs e)
        {
            int I = lstbx1.SelectedIndex;
            if (ACCB.IsChecked == true)
                {
                karakterek[I].Akcio = true;
                }
                else
                {

                karakterek[I].Akcio = false;
                }
                
            
           
        }
        private void BACB_Checked(object sender, RoutedEventArgs e)
        {
            int I = lstbx1.SelectedIndex;
            if (I != -1)
            {
                if (BACB.IsChecked == true)
                {
                    karakterek[I].Bonusz_Akcio = true;
                }
                else
                {

                    karakterek[I].Bonusz_Akcio = false;
                }
                
            }
            
        }
        private void RCB_Checked(object sender, RoutedEventArgs e)
        {
            int I = lstbx1.SelectedIndex;
            if (I != -1)
            {
                if (RCB.IsChecked == true)
                {
                    karakterek[I].Reakcio = true;
                }
                else
                {
                    karakterek[I].Reakcio = false;
                }
                
            }
            
        }
        private void Hpbx_TextChanged(object sender, RoutedEventArgs e)
        {
            int I = lstbx1.SelectedIndex;
            if (I != -1)
            {
                karakterek[I].HP = int.Parse(Hpbx.Text);
                
            }
            
        }
        private void Nmbx_TextChanged(object sender, RoutedEventArgs e)
        {
            int I = lstbx1.SelectedIndex;
            if (lstbx1.SelectedIndex != -1)
            {
                karakterek[I].Nev = Nmbx.Text;
                
            }
            
        }
        private void Bbx_TextChanged(object sender, RoutedEventArgs e)
        {
            int I = lstbx1.SelectedIndex;
            if (I != -1)
            {
                karakterek[I].Bonusz = int.Parse(Bbx.Text);
                
            }
            
        }
        private void Ibx_TextChanged(object sender, RoutedEventArgs e)
        {
            int I = lstbx1.SelectedIndex;
            if (I != -1)
            {
                karakterek[I].Rendezesi_Ertek = int.Parse(Ibx.Text);
                
            }
            
        }
        private void BTDP_DateChanged(object sender, RoutedEventArgs e)
        {
            int I = lstbx1.SelectedIndex;
            if (I != -1)
            {
                karakterek[I].Szuletesi_Datum = BTDP.SelectedDate!.Value;
                
            }
            
        }


        private void Listaválasztás(int Index)
        {
            if(lstbx1.SelectedIndex!=-1){
                Karakter kivalasztott = karakterek[Index];
                Nmbx.Text = $"{kivalasztott.Nev}";
                Hpbx.Text = $"{kivalasztott.HP}";

                if (kivalasztott.Akcio == true)
                {
                    ACCB.IsChecked = true;
                }
                else
                {
                    ACCB.IsChecked = false;
                }
                if (kivalasztott.Bonusz_Akcio == true)
                {
                    BACB.IsChecked = true;
                }
                else
                {
                    BACB.IsChecked = false;
                }
                if (kivalasztott.Reakcio == true)
                {
                    RCB.IsChecked = true;
                }
                else
                {
                    RCB.IsChecked = false;
                }

                BTDP.SelectedDate = kivalasztott.Szuletesi_Datum;

                Bbx.Text = $"{kivalasztott.Bonusz}";

                Ibx.Text = $"{kivalasztott.Rendezesi_Ertek}";
            }
            

        }
        private void betotltes()
        {
                
            
        }
        private void Frissit()
        {
            karakterek = karakterek.OrderByDescending(k => k.Rendezesi_Ertek+k.Bonusz).ToList();
            eraseCB.SelectedIndex=-1;
            eraseCB.Items.Clear();
            lstbx1.SelectedIndex=-1;
            lstbx1.Items.Clear();
            Karakter.SaveToJson(karakterek);

            foreach (var item in karakterek)
            {
                lstbx1.Items.Add(item.Nev);
                eraseCB.Items.Add(item.Nev);
            }
        }
        private void Törlés(int index)
        {
            if (index != -1)
            {
                karakterek.RemoveAt(index);
            }
            Frissit();
        }
        private void UjKarakter()
        {
            Karakter ujkarakter = new Karakter("Új karakter", 1, 0, 1, false, false, false, DateTime.Now);
            karakterek.Add(ujkarakter);
            Frissit();
            lstbx1.SelectedIndex = karakterek.IndexOf(ujkarakter);

        }
        private void randomolas()
        {
            Random rnd = new Random();
            foreach (var item in karakterek)
            {
                item.Rendezesi_Ertek = rnd.Next(1, 21);
            }
            Frissit();
        }





        private void Bbx_TextChanged_1(object sender, TextChangedEventArgs e)
        {
        }

        private void Ibx_TextChanged_1(object sender, TextChangedEventArgs e)
        {
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Frissit();
        }
    }
}