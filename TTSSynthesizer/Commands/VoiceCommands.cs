using System;
using System.Speech.Synthesis;
using System.Windows;

using Microsoft.Win32;

using Xlfdll.Windows.Presentation;

namespace TTSSynthesizer
{
    public static class VoiceCommands
    {
        static VoiceCommands()
        {
            VoiceCommands.PlayCommand = new RelayCommand<Object>
            (
                delegate
                {
                    switch (SpeechState.Current.Synthesizer.State)
                    {
                        case SynthesizerState.Ready:
                            {
                                SpeechState.Current.Synthesizer.SetOutputToDefaultAudioDevice();
                                SpeechState.Current.Synthesizer.SelectVoice(SpeechState.Current.Voice.Name);
                                SpeechState.Current.Synthesizer.SpeakAsync(SpeechState.Current.Text);

                                break;
                            }
                        case SynthesizerState.Speaking:
                            {
                                SpeechState.Current.Synthesizer.Pause();

                                break;
                            }
                        case SynthesizerState.Paused:
                            {
                                SpeechState.Current.Synthesizer.Resume();

                                break;
                            }
                    }
                }
            );

            VoiceCommands.StopCommand = new RelayCommand<Object>
            (
                delegate
                {
                    SpeechState.Current.Synthesizer.SpeakAsyncCancelAll();
                    SpeechState.Current.Synthesizer.Resume(); // Stop even if paused
                },
                delegate
                {
                    return (SpeechState.Current?.Synthesizer.State != SynthesizerState.Ready);
                }
            );

            VoiceCommands.RecordCommand = new RelayCommand<Object>
            (
                delegate
                {
                    SaveFileDialog dlg = new SaveFileDialog()
                    {
                        Filter = "Wave File (*.wav)|*.wav|All Files (*.*)|*.*"
                    };

                    if (dlg.ShowDialog(ApplicationHelper.MainWindow) == true)
                    {
                        SpeechState.Current.Synthesizer.SetOutputToWaveFile(dlg.FileName);
                        SpeechState.Current.Synthesizer.SelectVoice(SpeechState.Current.Voice.Name);
                        SpeechState.Current.Synthesizer.Speak(SpeechState.Current.Text);
                        SpeechState.Current.Synthesizer.SetOutputToDefaultAudioDevice();

                        MessageBox.Show(ApplicationHelper.MainWindow,
                            String.Format("The voice has been saved to{0}{0}{1}", Environment.NewLine, dlg.FileName),
                            ApplicationHelper.Metadata.AssemblyTitle, MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                },
                delegate
                {
                    return (SpeechState.Current?.Synthesizer.State == SynthesizerState.Ready);
                }
            );
        }

        public static RelayCommand<Object> PlayCommand { get; }
        public static RelayCommand<Object> StopCommand { get; }
        public static RelayCommand<Object> RecordCommand { get; }
    }
}