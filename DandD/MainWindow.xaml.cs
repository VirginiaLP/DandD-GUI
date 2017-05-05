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

namespace DandD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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
        private void UpdateStat(object sender, RoutedEventArgs e)
        {
            int hold;
            TextBox box = (TextBox)sender;
            string thing = box.Name + "Block";
            TextBlock block = (TextBlock)this.FindName(thing);

            bool worked = Int32.TryParse(box.Text,out hold );

            if (worked && hold >= 1 && hold <= 29)
            {
                string temp = ((hold - 10) / 2).ToString();
                if ((hold - 10) / 2 > 0) temp = "+" + temp;
                block.Text = temp;
            }
            else
                block.Text = "NaN";

            CheckBox boxy = (CheckBox)this.FindName(box.Name + "1");
            UpdateSkill(boxy, e);
        }
        private void UpdateSkill(object sender, RoutedEventArgs e)
        {
            //pull from stat bonus
            //pull from prof check
            CheckBox cbox = (CheckBox)sender;
            if (cbox == null)
                return;
            string skill = cbox.Name.Substring(0, 3);
            TextBlock block = (TextBlock)this.FindName(skill + "Block");

            for (int i=1;i<7;i++)
            {
                int statBonus = 0;
                CheckBox checkMe = (CheckBox)this.FindName(skill + i.ToString());
                if(checkMe != null)
                {
                    Int32.TryParse(block.Text, out statBonus);
                    
                    int profBonus;
                    TextBox prof = (TextBox)FindName("ProfBonusBox");
                    bool work = Int32.TryParse(prof.Text, out profBonus);
                    if (work)
                    {
                        int bonus = statBonus + ((bool)checkMe.IsChecked ? profBonus : 0);

                        TextBlock blep = (TextBlock)this.FindName(skill + i.ToString() + "Block");
                        blep.Text = bonus.ToString();
                    }
                    else break;
                }
            }
        }
        private void ProfUpdateSkills(object sender, RoutedEventArgs e)
        {
            CheckBox boxy = (CheckBox)this.FindName("str1");
            UpdateSkill(boxy, e);

            boxy = (CheckBox)this.FindName("dex1");
            UpdateSkill(boxy, e);

            boxy = (CheckBox)this.FindName("con1");
            UpdateSkill(boxy, e);

            boxy = (CheckBox)this.FindName("int1");
            UpdateSkill(boxy, e);

            boxy = (CheckBox)this.FindName("wis1");
            UpdateSkill(boxy, e);

            boxy = (CheckBox)this.FindName("chr1");
            UpdateSkill(boxy, e);
        }

        private void UpdateStuff(object sender, RoutedEventArgs e)
        {
            TextBox boxy = (TextBox)sender;

            UpdateKey(boxy.Name, boxy.Text);
        }

        private void UpdateKey(object key, object value)
        {
            // load the resource dictionary
            var rd = new System.Windows.ResourceDictionary();
            rd.Source = new System.Uri("SavedStuff.xaml", System.UriKind.RelativeOrAbsolute);

            rd[key] = value;

            var settings = new System.Xml.XmlWriterSettings();
            settings.Indent = true;
            var writer = System.Xml.XmlWriter.Create(@"SavedStuff.xaml", settings);
            System.Windows.Markup.XamlWriter.Save(rd, writer);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
