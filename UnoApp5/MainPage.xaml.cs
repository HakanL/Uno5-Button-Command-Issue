using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Input;

namespace UnoApp5
{
    public sealed partial class MainPage : Page
    {
        private bool canExecuteTheCommand = true;

        public MainPage()
        {
            this.InitializeComponent();

            CommandOn = new RelayCommand(OnCommandOn, () => !this.canExecuteTheCommand);
            CommandOff = new RelayCommand(OnCommandOff, () => this.canExecuteTheCommand);
            TheCommand = new RelayCommand(OnTheCommand, () => this.canExecuteTheCommand);
        }

        private void Item_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Console.WriteLine($"Item tapped: {sender.GetType().Name}");
        }

        public IRelayCommand CommandOn { get; set; }

        public IRelayCommand TheCommand { get; set; }

        public IRelayCommand CommandOff { get; set; }

        public void ClickHandler(object sender, RoutedEventArgs e)
        {
            CommandOn.NotifyCanExecuteChanged();
            TheCommand.NotifyCanExecuteChanged();
            CommandOff.NotifyCanExecuteChanged();
        }

        private void OnCommandOff()
        {
            Console.WriteLine("OFF");

            this.canExecuteTheCommand = false;

            CommandOn.NotifyCanExecuteChanged();
            TheCommand.NotifyCanExecuteChanged();
            CommandOff.NotifyCanExecuteChanged();
        }

        private void OnCommandOn()
        {
            Console.WriteLine("ON");

            this.canExecuteTheCommand = true;

            CommandOn.NotifyCanExecuteChanged();
            TheCommand.NotifyCanExecuteChanged();
            CommandOff.NotifyCanExecuteChanged();
        }

        private void OnTheCommand()
        {
            Console.WriteLine("The command");
        }
    }
}
