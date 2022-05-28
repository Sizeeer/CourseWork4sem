using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI.Properties
{
    internal sealed partial class Settings
    {

        public Settings()
        {
            // // Для добавления обработчиков событий для сохранения и изменения параметров раскомментируйте приведенные ниже строки:
            //
            // this.SettingChanging += this.SettingChangingEventHandler;
            //
            // this.SettingsSaving += this.SettingsSavingEventHandler;
            //
        }

        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            // Добавьте здесь код для обработки события SettingChangingEvent.
        }

        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Добавьте здесь код для обработки события SettingsSaving.
        }
    }
}
