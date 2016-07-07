using System;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace TTSSynthesizer
{
    public partial class VoiceForm : Form
    {
        #region Constructors

        public VoiceForm()
        {
            InitializeComponent();
        }

        public VoiceForm(SpeechSynthesizer speechSynthesizer)
            : this()
        {
            _speechSynthesizer = speechSynthesizer;
        }

        #endregion

        #region Public Properties

        public Boolean VoiceControlsEnabled
        {
            get { return voiceGroupBox.Enabled; }
            set { voiceGroupBox.Enabled = value; }
        }

        #endregion

        #region Private Event Methods

        private void VoiceForm_Load(object sender, EventArgs e)
        {
            foreach (InstalledVoice voice in _speechSynthesizer.GetInstalledVoices())
            {
                voiceComboBox.Items.Add(voice.VoiceInfo.Name);
            }

            voiceComboBox.SelectedIndex = 0;
        }

        private void voiceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _speechSynthesizer.SelectVoice(voiceComboBox.SelectedItem.ToString());

            voiceNameLabel.Text = _speechSynthesizer.Voice.Name;
            voiceDescLabel.Text = _speechSynthesizer.Voice.Description;
            voiceCultureLabel.Text = _speechSynthesizer.Voice.Culture.NativeName + " [" + _speechSynthesizer.Voice.Culture.Name + "]";
            voiceGenderLabel.Text = _speechSynthesizer.Voice.Gender.ToString();
            voiceAgeLabel.Text = _speechSynthesizer.Voice.Age.ToString();
        }

        private void rateTrackBar_ValueChanged(object sender, EventArgs e)
        {
            _speechSynthesizer.Rate = rateTrackBar.Value;

            mainToolTip.SetToolTip(rateTrackBar, rateTrackBar.Value.ToString());
        }

        private void volumeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            _speechSynthesizer.Volume = volumeTrackBar.Value;

            mainToolTip.SetToolTip(volumeTrackBar, volumeTrackBar.Value.ToString());
        }

        #endregion

        #region Public Methods

        public void Reset()
        {
            voiceComboBox.SelectedIndex = 0;
            rateTrackBar.Value = 0;
            volumeTrackBar.Value = 100;
        }

        #endregion

        #region Private Fields

        private SpeechSynthesizer _speechSynthesizer;

        #endregion
    }
}