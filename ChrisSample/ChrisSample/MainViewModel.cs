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
            get => name;
            set
            {
                name = value;
                //var p = PageValidation.Validate(this);
                NotifyPropertyChanged(nameof(Name));
            }
        }

        private string dateTimeString;
        private bool isCheckboxChecked;
        private string checkBoxValue;
        private bool buttonTwoIsEnabled;
        private string nameError;

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

        public string NameError
        {
            get => nameError; internal set
            {
                nameError = value;
                NotifyPropertyChanged(nameof(NameError));
            }
        }

        public PageValidation PageValidation { get; set; }


        public ICommand ButtonClickCommand { get; set; }
        public ICommand ButtonThreeClickCommand { get; set; }


        public MainViewModel()
        {
            //Name = "Test project";
            ButtonClickCommand = new Command(ButtonClickAction);
            ButtonThreeClickCommand = new Command(ButtonThreeClickAction);
            PageValidation = new PageValidation();
        }

        private void ButtonThreeClickAction(object obj)
        {
            ButtonTwoIsEnabled = IsCheckboxChecked;
        }

        private void ButtonClickAction(object obj)
        {
            var result = PageValidation.Validate(this);
            if (result.IsValid)
                NameError = string.Empty;

            DateTimeString = DateTime.Now.ToString("ffff");



        }

        private bool Validate()
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
