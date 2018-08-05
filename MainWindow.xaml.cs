using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Interop;
using System.Speech.Synthesis;

using Microsoft.Win32;

namespace TTSSynthesizerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //protected override void OnSourceInitialized(EventArgs e)
        //{
        //    base.OnSourceInitialized(e);

        //    AeroGlassHelper.OnInitialized(this, new Thickness(-1));
        //}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (InstalledVoice voice in synth.GetInstalledVoices())
            {
                voiceComboBox.Items.Add(voice.VoiceInfo.Name);
            }
            voiceComboBox.SelectedIndex = 0;

            wordsIndexTextBox.Text = speakingWordsIndex.ToString();

            synth.SpeakStarted += new EventHandler<SpeakStartedEventArgs>(synth_SpeakStarted);
            synth.SpeakProgress += new EventHandler<SpeakProgressEventArgs>(synth_SpeakProgress);
            synth.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>(synth_SpeakCompleted);
        }

        private void contentTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
        }

        private void contentTextBox_Drop(object sender, DragEventArgs e)
        {
            String[] files = e.Data.GetData(DataFormats.FileDrop) as String[];

            if (files != null && files.Length > 0)
            {
                loadFileContents(files[0]);

                playToggleButton_Checked(sender, new RoutedEventArgs());
            }
        }

        void synth_SpeakStarted(object sender, SpeakStartedEventArgs e)
        {
            synth_SynthStateChanged(sender, e);

            contentTextBox.Focus();
        }

        void synth_SpeakProgress(object sender, SpeakProgressEventArgs e)
        {
            if (!(Boolean)ssmlCheckBox.IsChecked && !speakingWords.Equals(e.Text))
            {
                speakingWords = e.Text;

                speakingWordsIndex = contentTextBox.Text.IndexOf(speakingWords, speakingWordsIndex);

                contentTextBox.Select(speakingWordsIndex, speakingWords.Length);

                wordsIndexTextBox.Text = (speakingWordsIndex + 1).ToString();

                speakingWordsIndex += speakingWords.Length;
            }
        }

        void synth_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            synth_SynthStateChanged(sender, e);

            contentTextBox.Select(0, 0);
        }

        void synth_SynthStateChanged(object sender, EventArgs e)
        {
            playToggleButton.IsChecked = (synth.State == SynthesizerState.Speaking);
            stopButton.IsEnabled = !(synth.State == SynthesizerState.Ready);
            recordButton.IsEnabled = (synth.State == SynthesizerState.Ready);

            voiceGroupBox.IsEnabled = (synth.State == SynthesizerState.Ready);
            contentStackPanel.IsEnabled = (synth.State == SynthesizerState.Ready);

            contentTextBox.IsReadOnly = !(synth.State == SynthesizerState.Ready);

            speakingWordsIndex = 0;
            wordsIndexTextBox.Text = speakingWordsIndex.ToString();
        }

        private void voiceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            synth.SelectVoice(voiceComboBox.SelectedItem.ToString());

            voiceNameLabel.Content = synth.Voice.Name;
            voiceDescLabel.Content = synth.Voice.Description;
            voiceCultureLabel.Content = synth.Voice.Culture.NativeName + " [" + synth.Voice.Culture.Name + "]";
            voiceGenderLabel.Content = synth.Voice.Gender;
            voiceAgeLabel.Content = synth.Voice.Age;
        }

        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            synth.Volume = Convert.ToInt32(volumeSlider.Value);
            volumeSlider.ToolTip = synth.Volume;
        }

        private void rateSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            synth.Rate = Convert.ToInt32(rateSlider.Value);
            rateSlider.ToolTip = synth.Rate;
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "Text Document (*.txt)|*.txt|SSML Document (*.xml; *.ssml)|*.xml;*.ssml|All Files (*.*)|*.*";
            dlg.Multiselect = false;
            dlg.RestoreDirectory = true;
            dlg.CheckFileExists = true;

            if ((Boolean)dlg.ShowDialog())
            {
                loadFileContents(dlg.FileName);
            }
        }

        private void ssmlCheckBox_CheckedStateChanged(object sender, RoutedEventArgs e)
        {
            voiceGroupBox.IsEnabled = voiceInfoGroupBox.IsEnabled = !(Boolean)ssmlCheckBox.IsChecked;
        }

        private void playToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            if (synth.State == SynthesizerState.Ready)
            {
                synth.SetOutputToDefaultAudioDevice();

                performSpeakAsync();
            }
        }

        private void playToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            if (synth.State == SynthesizerState.Speaking)
            {
                synth.Pause();
            }
            else if (synth.State == SynthesizerState.Paused)
            {
                synth.Resume();
            }
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            synth.SpeakAsyncCancelAll();
            synth.Resume(); // Must resume once, or the state cannot change correctly.
        }

        private void recordButton_Click(object sender, RoutedEventArgs e)
        {
            stopButton_Click(sender, e);

            SaveFileDialog dlg = new SaveFileDialog();

            dlg.Filter = "Wave Document (*.wav)|*.wav|All Files (*.*)|*.*";
            dlg.OverwritePrompt = true;
            dlg.RestoreDirectory = true;

            if ((Boolean)dlg.ShowDialog())
            {
                synth.SetOutputToWaveFile(dlg.FileName);

                performSpeak();
            }

            stopButton_Click(sender, e);
        }

        private void performSpeak()
        {
            if (!(Boolean)ssmlCheckBox.IsChecked)
            {
                synth.Speak(contentTextBox.Text);
            }
            else
            {
                synth.SpeakSsml(contentTextBox.Text);
            }
        }

        private void performSpeakAsync()
        {
            if (!(Boolean)ssmlCheckBox.IsChecked)
            {
                synth.SpeakAsync(contentTextBox.Text);
            }
            else
            {
                synth.SpeakSsmlAsync(contentTextBox.Text);
            }
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            stopButton_Click(sender, e);

            voiceComboBox.SelectedIndex = 0;
            rateSlider.Value = 0;
            volumeSlider.Value = 100;
            contentTextBox.Text = "Enter text here or Load a file.";
            ssmlCheckBox.IsChecked = false;
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void loadFileContents(String fileName)
        {
            using (StreamReader reader = new StreamReader(fileName, Encoding.Default))
            {
                contentTextBox.Text = reader.ReadToEnd();
            }

            ssmlCheckBox.IsChecked = (System.IO.Path.GetExtension(fileName).Equals(".xml", StringComparison.InvariantCultureIgnoreCase)
                || System.IO.Path.GetExtension(fileName).Equals(".ssml", StringComparison.InvariantCultureIgnoreCase));
        }

        SpeechSynthesizer synth = new SpeechSynthesizer();
        private Int32 speakingWordsIndex = 0;
        private String speakingWords = String.Empty;

        // "bool?" is a Boolean structure that can be "null".
    }
}
