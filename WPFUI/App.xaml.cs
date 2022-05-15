using System.Windows;
using System.Windows.Threading;

namespace WPFUI
{
    public partial class App
    {
        /// <summary>
        /// TODO:
        /// </summary>
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