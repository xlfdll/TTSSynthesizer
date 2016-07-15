using System;

using Xlfdll.Windows.Presentation;
using Xlfdll.Windows.Presentation.Dialogs;

namespace TTSSynthesizer
{
    public static class GeneralCommands
    {
        static GeneralCommands()
        {
            GeneralCommands.AboutCommand = new RelayCommand<Object>
            (
                delegate
                {
                    AboutWindow aboutWindow = new AboutWindow
                    (ApplicationHelper.MainWindow,
                    ApplicationHelper.Metadata,
                    new ApplicationPackUri("/Images/TTSSynthesizer.png"));

                    aboutWindow.ShowDialog();
                }
            );
        }

        public static RelayCommand<Object> AboutCommand { get; }
    }
}