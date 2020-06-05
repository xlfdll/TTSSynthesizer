using System;
using System.Speech.Synthesis;

using Microsoft.Win32;

using Xlfdll.Windows.Presentation;

namespace TTSSynthesizer
{
    public static class TextCommands
    {
        static TextCommands()
        {
            TextCommands.NewCommand = new RelayCommand<Object>
            (
                delegate
                {
                    SpeechState.Current.Text = String.Empty;
                },
                delegate
                {
                    return (SpeechState.Current?.Synthesizer.State == SynthesizerState.Ready);
                }
            );

            TextCommands.OpenCommand = new RelayCommand<Object>
            (
                delegate
                {
                    OpenFileDialog dlg = new OpenFileDialog()
                    {
                        Filter = "Text Document (*.txt)|*.txt|All Files (*.*)|*.*"
                    };

                    if (dlg.ShowDialog(App.MainWindow) == true)
                    {
                        SpeechState.Current.Text = TextHelper.LoadTextFile(dlg.FileName);
                    }
                },
                delegate
                {
                    return (SpeechState.Current?.Synthesizer.State == SynthesizerState.Ready);
                }
            );
        }

        public static RelayCommand<Object> NewCommand { get; }
        public static RelayCommand<Object> OpenCommand { get; }
    }
}