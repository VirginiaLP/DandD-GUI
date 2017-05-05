using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DandD
{
    public class LoadMe
    {
        public string[] characterStats { get; set; }
        public string[] scoresArray { get; set; }
        public string[] characterStats2 { get; set; }
        public string[] characterDetails { get; set; }
        public string[] journalText { get; set; }
        public bool[] statArray { get; set; }
        public string[] spells { get; set; }
    }

    public class SavedThings : INotifyPropertyChanged
    {
        public bool unsavedChanges = false;
        private static SavedThings instance;
        private SavedThings() { }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String info)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            unsavedChanges = true;
        }

        public static SavedThings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SavedThings();
                }
                return instance;
            }
        }

        string[] _characterStats = { "", "", "", "", "", "", "", "+2", ""};
        public string[] characterStats
        {
            get { return _characterStats; }
            set
            {
                _characterStats = value;

                OnPropertyChanged("characterStats");
            }
        }

        string[] _scoresArray = { "8", "8", "8", "8", "8", "8" };
        public string[] scoresArray
        {
            get { return _scoresArray; }
            set
            {
                _scoresArray = value;

                OnPropertyChanged("scoresArray");
            }
        }

        bool[] _statarray = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        public bool[] statArray
        {
            get { return _statarray; }
            set
            {
                _statarray = value;

                OnPropertyChanged("statArray");
            }
        }

        string[] _spells = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        public string[] spells
        {
            get { return _spells; }
            set
            {
                _spells = value;

                OnPropertyChanged("spells");
            }
        }

        string[] _characterStats2 = { "", "", "", "", "", "", "", "", "","","","","","","","", "", "", "", "", "", "", "", "" };
        public string[] characterStats2
        {
            get { return _characterStats2; }
            set
            {
                _characterStats2 = value;

                OnPropertyChanged("characterStats2");
            }
        }

        string[] _characterDetials = { "", "", "", "", "", "enter text...", "", "", "", "", "" };
        public string[] characterDetails
        {
            get { return _characterDetials; }
            set
            {
                _characterDetials = value;

                OnPropertyChanged("characterDetails");
            }
        }

        string[] _journalText = {"enter text...", "enter text...", "enter text..." };
        public string[] journalText
        {
            get { return _journalText; }
            set
            {
                _journalText = value;

                OnPropertyChanged("journalText");
            }
        }
    }
}
