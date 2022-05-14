using System.Windows;
using System.Windows.Threading;
using TrackerLibrary.BUL;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            this.Dispatcher.UnhandledException += GlobalHandlingErrors;
        }

        void GlobalHandlingErrors(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            string errorMessage = string.Format("Ошибка: {0}", e.Exception.Message);
            MessageBox.Show(errorMessage);
            e.Handled = true;
        }
    }
}