using System;
using System.Collections.ObjectModel;
using System.Speech.Synthesis;
using System.Windows.Input;

using Xlfdll;

namespace TTSSynthesizer
{
    public class SpeechState : ObservableObject, IDisposable
    {
        public SpeechState()
        {
            this.Synthesizer = new SpeechSynthesizer();
            this.InstalledVoices = this.Synthesizer.GetInstalledVoices();
            this.Text = String.Empty;

            this.Synthesizer.StateChanged += SpeechSynthesizer_StateChanged;
            this.Synthesizer.SpeakStarted += SpeechSynthesizer_SpeakStarted;
            this.Synthesizer.SpeakProgress += SpeechSynthesizer_SpeakProgress;
            this.Synthesizer.SpeakCompleted += SpeechSynthesizer_SpeakCompleted;

            SpeechState.Current = this;
        }

        public SpeechSynthesizer Synthesizer { get; }
        public ReadOnlyCollection<InstalledVoice> InstalledVoices { get; }

        public String State => this.Synthesizer.State.ToString();

        public VoiceInfo Voice
        {
            get
            {
                return this.Synthesizer.Voice;
            }
            set
            {
                this.Synthesizer.SelectVoice(value.Name);

                OnPropertyChanged(nameof(this.Voice));
            }
        }

        public Int32 VoiceRate
        {
            get
            {
                return this.Synthesizer.Rate;
            }
            set
            {
                this.Synthesizer.Rate = value;

                OnPropertyChanged(nameof(this.VoiceRate));
            }
        }
        public Int32 VoiceVolume
        {
            get
            {
                return this.Synthesizer.Volume;
            }
            set
            {
                this.Synthesizer.Volume = value;

                OnPropertyChanged(nameof(this.VoiceVolume));
            }
        }

        private String _text;

        private String _speakingText;
        private Int32 _speakingTextIndex;

        public String Text
        {
            get { return _text; }
            set { this.SetField(ref _text, value); }
        }
        public String SpeakingText
        {
            get { return _speakingText; }
            private set { this.SetField(ref _speakingText, value); }
        }
        public Int32 SpeakingTextIndex
        {
            get { return _speakingTextIndex; }
            private set { this.SetField(ref _speakingTextIndex, value); }
        }

        private void SpeechSynthesizer_StateChanged(object sender, StateChangedEventArgs e)
        {
            OnPropertyChanged(nameof(this.State));

            // Force CommandManager to refresh CanExecute states on all commands
            CommandManager.InvalidateRequerySuggested();
        }
        private void SpeechSynthesizer_SpeakStarted(object sender, SpeakStartedEventArgs e)
        {
            this.ResetSpeakingText();
        }
        private void SpeechSynthesizer_SpeakProgress(object sender, SpeakProgressEventArgs e)
        {
            this.SpeakingTextIndex += this.SpeakingText.Length;
            this.SpeakingText = e.Text;
            this.SpeakingTextIndex = this.Text.IndexOf(this.SpeakingText, this.SpeakingTextIndex);
        }
        private void SpeechSynthesizer_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            this.ResetSpeakingText();
        }

        private void ResetSpeakingText()
        {
            this.SpeakingText = String.Empty;
            this.SpeakingTextIndex = 0;
        }

        #region IDisposable Members

        public void Dispose()
        {
            this.Synthesizer.Dispose();
        }

        #endregion

        public static SpeechState Current { get; private set; }
    }
}