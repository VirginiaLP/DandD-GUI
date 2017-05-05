using System;
using System.IO;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace DandD
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void loadStuff(object sender, RoutedEventArgs e)
        {
            SavedThings saveMe = SavedThings.Instance;
            LoadMe loadMe;
            XmlSerializer serial = new XmlSerializer(typeof(LoadMe));

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Character";
            dlg.DefaultExt = ".char";
            dlg.Filter = "Character Sheets (.char)|*.char";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                using (StreamReader reader = new StreamReader(dlg.FileName))
                {
                    loadMe = (LoadMe)serial.Deserialize(reader);
                }

                saveMe.characterStats = loadMe.characterStats;
                saveMe.scoresArray = loadMe.scoresArray;
                saveMe.characterStats2 = loadMe.characterStats2;
                saveMe.characterDetails = loadMe.characterDetails;
                saveMe.journalText = loadMe.journalText;
                saveMe.statArray = loadMe.statArray;
                saveMe.unsavedChanges = false;
            }

            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void saveStuff(object sender, RoutedEventArgs e)
        {
            LoadMe loadMe = new LoadMe();
            SavedThings saveMe = SavedThings.Instance;
            XmlSerializer serial = new XmlSerializer(typeof(LoadMe));

            loadMe.characterStats = saveMe.characterStats;
            loadMe.statArray = saveMe.statArray;
            loadMe.characterStats2 = saveMe.characterStats2;
            loadMe.characterDetails = saveMe.characterDetails;
            loadMe.journalText = saveMe.journalText;
            loadMe.scoresArray = saveMe.scoresArray;

            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Character";
            dlg.DefaultExt = ".char";
            dlg.Filter = "Character Sheets (.char)|*.char";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                using (XmlWriter xmlWriter = XmlWriter.Create(dlg.FileName, settings))
                {
                    serial.Serialize(xmlWriter, loadMe);
                }
            }
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
        private void GoToCharStats(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
