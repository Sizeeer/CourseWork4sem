using System.Windows;
using System.Windows.Threading;

namespace WPFUI
{
    public partial class App
    {
        /// <summary>
        ///TODO: 
        /// Добавить материал дизайн
        /// информировать о текущих состязаниях четко большими буквами информативно
        /// Стата лучший игрок, рейтинг команд
        /// задержку перед след раундом
        /// 
        /// 
        /// /// Блок схема формирования турнирной доски в записку - OK
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