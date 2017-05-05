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
    /// Interaction logic for DiceRoller.xaml
    /// </summary>
    public partial class DiceRoller : Window
    {
        Random rando = new Random();
        public DiceRoller()
        {
            InitializeComponent();
            this.DataContext = SavedThings.Instance;
        }
        private void GoToCharDetails(object sender, RoutedEventArgs e)
        {
            CharDetails cd = new CharDetails();
            cd.Show();
            this.Close();
        }
        private void GoToJournal(object sender, RoutedEventArgs e)
        {
            Journal j = new Journal();
            j.Show();
            this.Close();
        }
        private void GoToCharStats(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
        private void GoToSettings(object sender, RoutedEventArgs e)
        {
            Settings s = new Settings();
            s.Show();
            this.Close();
        }
        private void RollDie(object sender, RoutedEventArgs e)
        {
            int total = 0;
            int x, y;
            

            TextBox xBox = (TextBox)this.FindName("xBox");
            bool ex = Int32.TryParse(xBox.Text, out x);
            TextBox yBox = (TextBox)this.FindName("yBox");
            bool why = Int32.TryParse(yBox.Text, out y);

            int[] rolled = new int[x];
            if (ex && why && x != 0 && y != 0)
            {
                for (int i = 0; i < x; i++)
                {
                    int hold = rando.Next(1, y + 1);
                    total += hold;
                    rolled[i] = hold;
                }

                TextBlock dieOutput = (TextBlock)this.FindName("multipleDieOutputBox");
                string temp = "";
                for (int i = 0; i < x - 1; i++)
                    temp += rolled[i].ToString() + "+";
                temp += rolled[x - 1].ToString();

                dieOutput.Text = temp;

                TextBlock output = (TextBlock)this.FindName("DieOutputBlock");
                output.Text = total.ToString();
            }
            else
            {
                TextBlock output = (TextBlock)this.FindName("DieOutputBlock");
                output.Text = "NO";
                TextBlock dieoutput = (TextBlock)this.FindName("multipleDieOutputBox");
                dieoutput.Text = "You can't do that, Scrub";
            }
        }
    }
}
