using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChrisSample
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get => name; set
            {
                name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        private string dateTimeString;
        private bool isCheckboxChecked;
        private string checkBoxValue;
        private bool buttonTwoIsEnabled;

        public string DateTimeString
        {
            get => dateTimeString; set
            {
                dateTimeString = value;
                NotifyPropertyChanged(nameof(DateTimeString));
            }
        }

        public bool IsCheckboxChecked
        {
            get => isCheckboxChecked; set
            {
                isCheckboxChecked = value;
                NotifyPropertyChanged(nameof(IsCheckboxChecked));
                CheckBoxValue = value ? "True" : "False";

            }
        }

        public bool ButtonTwoIsEnabled
        {
            get => buttonTwoIsEnabled; set
            {
                buttonTwoIsEnabled = value;
                NotifyPropertyChanged(nameof(ButtonTwoIsEnabled));
            }
        }


        public string CheckBoxValue
        {
            get => checkBoxValue; set
            {
                checkBoxValue = value;
                NotifyPropertyChanged(nameof(CheckBoxValue));
            }
        }


        public ICommand ButtonClickCommand { get; set; }
        public ICommand ButtonThreeClickCommand { get; set; }

        public MainViewModel()
        {
            Name = "Test project";
            ButtonClickCommand = new Command(ButtonClickAction);
            ButtonThreeClickCommand = new Command(ButtonThreeClickAction);
        }

        private void ButtonThreeClickAction(object obj)
        {
            ButtonTwoIsEnabled = IsCheckboxChecked;
        }

        private void ButtonClickAction(object obj)
        {
            DateTimeString = DateTime.Now.ToString("ffff");



        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
