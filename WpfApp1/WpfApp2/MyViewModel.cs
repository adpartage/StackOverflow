using System.ComponentModel;
using System.Windows.Input;

namespace WpfApp2
{
    public class MyViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public MyViewModel(string textBoxValue)
        {
            TextBoxValue = textBoxValue;
            ChooseGameCommand = new RelayCommand<object>(_ => ChooseGameCommandHandler(), _ => !string.IsNullOrEmpty(TextBoxValue));
        }
        
        public MyViewModel() : this(string.Empty) { }


        private bool _isvisible = true;
        private string _textBoxValue;

        public string TextBoxValue
        {
            get { return _textBoxValue; }
            set
            {
                if (_textBoxValue != value)
                {
                    _textBoxValue = value;
                    RaisePropertyChanged(nameof(TextBoxValue));
                }
            }
        }
        public bool IsVisible
        {
            get { return _isvisible; }
            set
            {
                if (_isvisible != value)
                {
                    _isvisible = value;
                    RaisePropertyChanged(nameof(IsVisible));
                }
            }
        }

        private void ChooseGameCommandHandler()
        {
            var window = new MainWindow();
            window.DataContext = new MyViewModel(TextBoxValue);
            window.Show();
            IsVisible = false;
        }

        public ICommand ChooseGameCommand { get; private set; }        
    }
}
