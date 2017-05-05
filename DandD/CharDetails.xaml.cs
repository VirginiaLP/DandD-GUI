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
using System.Windows.Shapes;

namespace DandD
{
    /// <summary>
    /// Interaction logic for CharDetails.xaml
    /// </summary>
    public partial class CharDetails : Window
    {
        public CharDetails()
        {
            InitializeComponent();
            this.DataContext = SavedThings.Instance;
        }
        private void GoToCharStats(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
        private void GoToJournal(object sender, RoutedEventArgs e)
        {
            Journal j = new Journal();
            j.Show();
            this.Close();
        }
        private void GoToDiceRoller(object sender, RoutedEventArgs e)
        {
            DiceRoller dr = new DiceRoller();
            dr.Show();
            this.Close();
        }
        private void GoToSettings(object sender, RoutedEventArgs e)
        {
            Settings s = new Settings();
            s.Show();
            this.Close();
        }
    }
}
