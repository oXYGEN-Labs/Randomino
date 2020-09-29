using Prism.Mvvm;

namespace Randomizer
{
    public class MainWindowVM : BindableBase
    {
        private string _title = "Randomino 0.1";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowVM()
        {

        }
    }
}