using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace VintelerEricav2_Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private DoughnutMachine myDoughnutMachine;
        DoughnutType selectedDoughnut;
        KeyValuePair<DoughnutType, double>[] PriceList = {
         new KeyValuePair<DoughnutType, double>(DoughnutType.Sugar, 2.5),
         new KeyValuePair<DoughnutType, double>(DoughnutType.Glazed,3),
         new KeyValuePair<DoughnutType, double>(DoughnutType.Chocolate,4.5),
         new KeyValuePair<DoughnutType, double>(DoughnutType.Vanilla,4),
         new KeyValuePair<DoughnutType, double>(DoughnutType.Lemon,3.5)
        };

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            myDoughnutMachine = new DoughnutMachine();
            myDoughnutMachine.DoughnutComplete += new DoughnutMachine.DoughnutCompleteDelegate(DoughnutCompleteHandler);

            cmbType.ItemsSource = PriceList;
            cmbType.DisplayMemberPath = "Key";
            cmbType.SelectedValuePath = "Value";

        }

        private int mRaisedGlazed;
        private int mRaisedSugar;
        private int mFilledLemon;
        private int mFilledChocolate;
        private int mFilledVanilla;


        private void glazedToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            glazedMenuItem.IsChecked = true;
            sugarMenuItem.IsChecked = false;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Glazed);
        }
        private void sugarToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            glazedMenuItem.IsChecked = false;
            sugarMenuItem.IsChecked = true;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Sugar);
        }

        private void DoughnutCompleteHandler()
        {
            switch (myDoughnutMachine.Flavor)
            {
                case DoughnutType.Glazed:
                    mRaisedGlazed++;
                    txtGlazedRaised.Text = mRaisedGlazed.ToString();
                    break;
                case DoughnutType.Sugar:
                    mRaisedSugar++;
                    txtSugarRaised.Text = mRaisedSugar.ToString();
                    break;
                case DoughnutType.Lemon:
                    mFilledLemon++;
                    txtLemonFilled.Text = mFilledLemon.ToString(); break;
                case DoughnutType.Chocolate:
                    mFilledChocolate++;
                    txtChocolateFilled.Text = mFilledChocolate.ToString(); break;
                case DoughnutType.Vanilla:
                    mFilledVanilla++;
                    txtVanillaFilled.Text = mFilledVanilla.ToString(); break;
            }
        }
        private void stopToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            myDoughnutMachine.Enabled = false;
        }
        private void exitToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void txtQuantity_KeyPress(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9))
            {
                MessageBox.Show("Numai cifre se pot introduce!", "Input Error", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }

        private void FilledItems_Click(object sender, RoutedEventArgs e)
        {
            string DoughnutFlavour;

            MenuItem SelectedItem = (MenuItem)e.OriginalSource;
            DoughnutFlavour = SelectedItem.Header.ToString();
            Enum.TryParse(DoughnutFlavour, out DoughnutType myFlavour);
            myDoughnutMachine.MakeDoughnuts(myFlavour);
        }
        private void FilledItemsShow_Click(object sender, RoutedEventArgs e)
        {
            string mesaj;
            MenuItem SelectedItem = (MenuItem)e.OriginalSource;
            mesaj = SelectedItem.Header.ToString() + " doughnuts are being cooked!";
            this.Title = mesaj;
        }
        
    }
}
