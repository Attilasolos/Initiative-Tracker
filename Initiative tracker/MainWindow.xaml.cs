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
        public MainWindow()
        {
            InitializeComponent();
            
            karakterek = Karakter.LoadFromJson();

            Frissit();

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Index = lstbx1.SelectedIndex;
            Listaválasztás(Index);
        }
        private void Listaválasztás(int Index)
        {
            if (Index >=0 && Index <= karakterek.Count-1)
            {
                Nmbx.Text = $"{karakterek[Index].Nev}";
                Hpbx.Text = $"{karakterek[Index].HP}";
                
                if (karakterek[Index].Akcio == true)
                {
                    ACCB.IsChecked = true;
                }
                else
                {
                    ACCB.IsChecked = false;
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
                    RCB.IsChecked = true;
                }
                else
                {
                    RCB.IsChecked = false;
                }
                
                BTDP.SelectedDate = karakterek[Index].Szuletesi_Datum;

                Bbx.Text = $"Bónusz: {karakterek[Index].Bonusz}";

                Ibx.Text = $"Initiative: {karakterek[Index].Rendezesi_Ertek}";
            }
            
        }

        private void ACCB_Checked(object sender, RoutedEventArgs e)
        {
           int I = lstbx1.SelectedIndex;
           if(ACCB.IsChecked == true)
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
            if (BACB.IsChecked == true)
            {
                karakterek[I].Bonusz_Akcio = true;
            }
            else
            {

                karakterek[I].Bonusz_Akcio = false;
            }
        }

        private void RCB_Checked(object sender, RoutedEventArgs e)
        {
            int I = lstbx1.SelectedIndex;
            if (RCB.IsChecked == true)
            {
                karakterek[I].Reakcio = true;
            }
            else
            {
                karakterek[I].Reakcio = false;
            }
        }


        /// lista frissitése (lista újrarendezése, listBox kiírás, combobox kiírás)
        private void Frissit()
        {
            karakterek = karakterek.OrderByDescending(k => k.Rendezesi_Ertek).ToList();
            eraseCB.SelectedIndex=-1;
            eraseCB.Items.Clear();
            lstbx1.SelectedIndex=-1;
            lstbx1.Items.Clear();

            foreach (var item in karakterek)
            {
                lstbx1.Items.Add(item.Nev);
                eraseCB.Items.Add(item.Nev);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frissit();
        }

        /// karakter törlése (combobox)
        private void Törlés(int index)
        {
            Nmbx.Text = index.ToString();
            if (index != -1)
            {
                karakterek.RemoveAt(index);
            }
            Frissit();
        }
        /// karakter hozzáadás (Add gomb)
        private void UjKarakter()
        {
            Karakter ujkarakter = new Karakter("hi",10,1,1,false,false,false,DateTime.Now);
            karakterek.Add(ujkarakter);
            Frissit();
            lstbx1.SelectedIndex = karakterek.IndexOf(ujkarakter);
            
        }
        /// karakter adatainak módosítása (Minden alkalommal amikor valamit beírnak automatikusan meghívja)
        
        private void Hpbx_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Nmbx_TextChanged(object sender, TextChangedEventArgs e)
        {
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

        /// json frissítése
        /// 

    }
}