using System.Windows;
using System.Windows.Threading;

namespace WPFUI
{
    public partial class App
    {
        /// <summary>
        /// TODO:
        /// 1. Сделать подтягивание прошлых очков в просмотре ранее созданного турнира
        /// 2. Подлатать скрипт бд, чтобы удалять турниры и за ним все что с ним связано
        /// 3. Добавить функцию удалять турнир
        /// 4. Сделать По умолчанию выбранный первый элемент в раундах и true чекбокс в просмотре турнира
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