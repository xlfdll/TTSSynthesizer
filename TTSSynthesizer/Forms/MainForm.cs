using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Speech.Synthesis;

using TTSSynthesizer.Properties;

namespace TTSSynthesizer
{
    public partial class MainForm : Form
    {
        #region Constructors

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Methods

        #region MainForm

        private void MainForm_Load(object sender, EventArgs e)
        {
            speechSynthesizer = new SpeechSynthesizer();

            voiceForm = new VoiceForm(speechSynthesizer);
            voiceForm.Location = new Point(this.Location.X + this.Width + 5, this.Location.Y + 5);

            speechSynthesizer.SpeakStarted += new EventHandler<SpeakStartedEventArgs>(speechSynthesizer_SpeakStarted);
            speechSynthesizer.SpeakProgress += new EventHandler<SpeakProgressEventArgs>(speechSynthesizer_SpeakProgress);
            speechSynthesizer.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>(speechSynthesizer_SpeakCompleted);

            voiceFormToolStripButton.PerformClick();
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            String[] files = e.Data.GetData(DataFormats.FileDrop) as String[];

            if (files != null && files.Length > 0)
            {
                stopToolStripButton.PerformClick();

                String fileExt = Path.GetExtension(files[0]);
                IsSSML = (fileExt.Equals(".xml", StringComparison.InvariantCultureIgnoreCase) || fileExt.Equals(".ssml", StringComparison.InvariantCultureIgnoreCase));
                handleFileContents(files[0]);

                playToolStripButton.PerformClick();
            }
        }

        #endregion

        #region mainToolStrip

        private void mainToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripButton button = e.ClickedItem as ToolStripButton;

            if (button != null)
            {
                if (button == newToolStripButton)
                {
                    stopToolStripButton.PerformClick();

                    voiceForm.Reset();

                    IsSSML = false;

                    handleFileContents(null);
                }
                else if (button == openToolStripButton)
                {
                    String filterString = "Text Document (*.txt)|*.txt|SSML Document (*.ssml; *.xml)|*.ssml; *.xml|All Files (*.*)|*.*";

                    using (OpenFileDialog dlg = new OpenFileDialog())
                    {
                        dlg.Filter = filterString;
                        dlg.Multiselect = false;
                        dlg.RestoreDirectory = true;
                        dlg.CheckFileExists = true;

                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            stopToolStripButton.PerformClick();

                            IsSSML = (dlg.FilterIndex == 2);

                            handleFileContents(dlg.FileName);
                        }
                    }
                }
                else if (button == voiceFormToolStripButton)
                {
                    if (voiceForm.Visible)
                    {
                        voiceForm.Hide();
                    }
                    else
                    {
                        voiceForm.Show(this);
                    }

                    voiceFormToolStripButton.Checked = voiceForm.Visible;

                    this.Focus();
                }
                else if (button == playToolStripButton)
                {
                    if (contentTextBox.SelectionLength == 0)
                    {
                        contentTextBox.Select(0, 0);
                    }

                    if (speechSynthesizer.State == SynthesizerState.Ready)
                    {
                        speechSynthesizer.SetOutputToDefaultAudioDevice();

                        performSpeak(true);
                    }
                    else if (speechSynthesizer.State == SynthesizerState.Paused)
                    {
                        speechSynthesizer.Resume();
                    }
                    else
                    {
                        speechSynthesizer.Pause();
                    }
                }
                else if (button == stopToolStripButton)
                {
                    speechSynthesizer.SpeakAsyncCancelAll();
                    speechSynthesizer.Resume(); // Must resume once, or the state cannot be changed correctly.
                }
                else if (button == recordToolStripButton)
                {
                    using (SaveFileDialog dlg = new SaveFileDialog())
                    {
                        dlg.Filter = "Wave Audio (*.wav)|*.wav|All Files (*.*)|*.*";
                        dlg.OverwritePrompt = true;
                        dlg.RestoreDirectory = true;

                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            speechSynthesizer.SetOutputToWaveFile(dlg.FileName);

                            performSpeak(false);

                            speechSynthesizer_SynthStateChanged(sender, e);

                            contentTextBox.Select(0, 0);

                            speechSynthesizer.SetOutputToDefaultAudioDevice();

                            MessageBox.Show(String.Format("The voice has been saved successfully:{0}{0}{1}", Environment.NewLine, dlg.FileName), "Recording Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else if (button == aboutToolStripButton)
                {
                    using (AboutBox about = new AboutBox())
                    {
                        about.ShowDialog();
                    }
                }
            }
        }

        private void playToolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            playToolStripButton.Image = playToolStripButton.Checked ? Resources.Pause : Resources.Play;
            playToolStripButton.Text = playToolStripButton.Checked ? "&Pause" : "&Play";
        }

        #endregion

        #region contentTextBox

        private void contentTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 1)
            {
                e.Handled = true;

                contentTextBox.SelectAll();
            }
        }

        #endregion

        #region speechSynthesizer

        private void speechSynthesizer_SpeakStarted(object sender, SpeakStartedEventArgs e)
        {
            speechSynthesizer_SynthStateChanged(sender, e);
        }

        private void speechSynthesizer_SpeakProgress(object sender, SpeakProgressEventArgs e)
        {
            if (!isSSML && !speakingWords.Equals(e.Text))
            {
                speakingWords = e.Text;
                speakingWordsIndex = contentTextBox.Text.IndexOf(speakingWords, contentTextBox.SelectionStart);

                contentTextBox.Select(speakingWordsIndex, speakingWords.Length);
                contentTextBox.ScrollToCaret();

                speakingWordIndexToolStripLabel.Text = (speakingWordsIndex + 1).ToString();
                speakingWordsIndex += speakingWords.Length;
            }
        }

        private void speechSynthesizer_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            speechSynthesizer_SynthStateChanged(sender, e);

            contentTextBox.Select(0, 0);
        }

        private void speechSynthesizer_SynthStateChanged(object sender, EventArgs e)
        {
            playToolStripButton.Checked = (speechSynthesizer.State == SynthesizerState.Speaking);
            stopToolStripButton.Enabled = !(speechSynthesizer.State == SynthesizerState.Ready);
            recordToolStripButton.Enabled = (speechSynthesizer.State == SynthesizerState.Ready);

            voiceForm.VoiceControlsEnabled = (speechSynthesizer.State == SynthesizerState.Ready);

            contentTextBox.ReadOnly = !(speechSynthesizer.State == SynthesizerState.Ready);

            speakingStateToolStripLabel.Text = speechSynthesizer.State.ToString();

            speakingWordsIndex = 0;
            speakingWordIndexToolStripLabel.Text = speakingWordsIndex.ToString();
        }

        // SpeechSynthesizer.StateChanged event has a problem.
        // When paused and then resumed, this event args "e.State" cannot change automatically.
        // It is the same as VoiceChange event (VoiceChange is only available for SSML). DO NOT use them directly!

        #endregion

        #endregion

        #region Helper Methods

        private void handleFileContents(String filename)
        {
            Boolean isFileNameNullOrEmpty = !String.IsNullOrEmpty(filename);

            contentTextBox.Text = isFileNameNullOrEmpty ? File.ReadAllText(filename, Encoding.Default) : String.Empty;

            this.Text = isFileNameNullOrEmpty ? String.Format("{0} - {1}", Path.GetFileNameWithoutExtension(filename), this.ProductName) : this.ProductName;
        }

        private void performSpeak(Boolean isAsync)
        {
            if (isAsync)
            {
                if (!isSSML)
                {
                    speechSynthesizer.SpeakAsync(String.IsNullOrEmpty(contentTextBox.SelectedText) ? contentTextBox.Text : contentTextBox.SelectedText);
                }
                else
                {
                    speechSynthesizer.SpeakSsmlAsync(contentTextBox.Text);
                }
            }
            else
            {
                if (!isSSML)
                {
                    speechSynthesizer.Speak(String.IsNullOrEmpty(contentTextBox.SelectedText) ? contentTextBox.Text : contentTextBox.SelectedText);
                }
                else
                {
                    speechSynthesizer.SpeakSsml(contentTextBox.Text);
                }
            }
        }

        #endregion

        #region Properties

        private Boolean IsSSML
        {
            get { return isSSML; }
            set
            {
                isSSML = value;

                speakingWordIndexToolStripLabel.Text = isSSML ? "SSML" : speakingWordsIndex.ToString();
            }
        }

        #endregion

        #region Fields

        private SpeechSynthesizer speechSynthesizer;

        private String speakingWords = String.Empty;
        private Int32 speakingWordsIndex = 0;
        private Boolean isSSML = false;

        private VoiceForm voiceForm;

        #endregion
    }
}