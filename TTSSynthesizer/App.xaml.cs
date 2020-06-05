using System.Windows;

using Xlfdll.Diagnostics;

namespace TTSSynthesizer
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            SpeechState.Current.Dispose();
        }

        public static AssemblyMetadata Metadata => AssemblyMetadata.EntryAssemblyMetadata;
        public static new MainWindow MainWindow => Application.Current.MainWindow as MainWindow;
    }
}