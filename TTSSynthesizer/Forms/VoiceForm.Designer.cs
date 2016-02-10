namespace TTSSynthesizer
{
    partial class VoiceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoiceForm));
            this.voiceGroupBox = new System.Windows.Forms.GroupBox();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.rateLabel = new System.Windows.Forms.Label();
            this.rateTrackBar = new System.Windows.Forms.TrackBar();
            this.volumeTrackBar = new System.Windows.Forms.TrackBar();
            this.voiceComboBox = new System.Windows.Forms.ComboBox();
            this.voiceLabel = new System.Windows.Forms.Label();
            this.voiceInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.voiceInfoTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.voiceAgeLabel = new System.Windows.Forms.Label();
            this.voiceAgeHelpLabel = new System.Windows.Forms.Label();
            this.voiceGenderLabel = new System.Windows.Forms.Label();
            this.voiceGenderHelpLabel = new System.Windows.Forms.Label();
            this.voiceCultureLabel = new System.Windows.Forms.Label();
            this.voiceCultureHelpLabel = new System.Windows.Forms.Label();
            this.voiceDescLabel = new System.Windows.Forms.Label();
            this.voiceDescHelpLabel = new System.Windows.Forms.Label();
            this.voiceNameLabel = new System.Windows.Forms.Label();
            this.voiceNameHelpLabel = new System.Windows.Forms.Label();
            this.mainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.voiceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).BeginInit();
            this.voiceInfoGroupBox.SuspendLayout();
            this.voiceInfoTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // voiceGroupBox
            // 
            this.voiceGroupBox.Controls.Add(this.volumeLabel);
            this.voiceGroupBox.Controls.Add(this.rateLabel);
            this.voiceGroupBox.Controls.Add(this.rateTrackBar);
            this.voiceGroupBox.Controls.Add(this.volumeTrackBar);
            this.voiceGroupBox.Controls.Add(this.voiceComboBox);
            this.voiceGroupBox.Controls.Add(this.voiceLabel);
            resources.ApplyResources(this.voiceGroupBox, "voiceGroupBox");
            this.voiceGroupBox.Name = "voiceGroupBox";
            this.voiceGroupBox.TabStop = false;
            // 
            // volumeLabel
            // 
            resources.ApplyResources(this.volumeLabel, "volumeLabel");
            this.volumeLabel.Name = "volumeLabel";
            // 
            // rateLabel
            // 
            resources.ApplyResources(this.rateLabel, "rateLabel");
            this.rateLabel.Name = "rateLabel";
            // 
            // rateTrackBar
            // 
            resources.ApplyResources(this.rateTrackBar, "rateTrackBar");
            this.rateTrackBar.LargeChange = 1;
            this.rateTrackBar.Minimum = -10;
            this.rateTrackBar.Name = "rateTrackBar";
            this.rateTrackBar.ValueChanged += new System.EventHandler(this.rateTrackBar_ValueChanged);
            // 
            // volumeTrackBar
            // 
            resources.ApplyResources(this.volumeTrackBar, "volumeTrackBar");
            this.volumeTrackBar.Maximum = 100;
            this.volumeTrackBar.Name = "volumeTrackBar";
            this.volumeTrackBar.Value = 100;
            this.volumeTrackBar.ValueChanged += new System.EventHandler(this.volumeTrackBar_ValueChanged);
            // 
            // voiceComboBox
            // 
            this.voiceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.voiceComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.voiceComboBox, "voiceComboBox");
            this.voiceComboBox.Name = "voiceComboBox";
            this.voiceComboBox.SelectedIndexChanged += new System.EventHandler(this.voiceComboBox_SelectedIndexChanged);
            // 
            // voiceLabel
            // 
            resources.ApplyResources(this.voiceLabel, "voiceLabel");
            this.voiceLabel.Name = "voiceLabel";
            // 
            // voiceInfoGroupBox
            // 
            this.voiceInfoGroupBox.Controls.Add(this.voiceInfoTableLayoutPanel);
            resources.ApplyResources(this.voiceInfoGroupBox, "voiceInfoGroupBox");
            this.voiceInfoGroupBox.Name = "voiceInfoGroupBox";
            this.voiceInfoGroupBox.TabStop = false;
            // 
            // voiceInfoTableLayoutPanel
            // 
            resources.ApplyResources(this.voiceInfoTableLayoutPanel, "voiceInfoTableLayoutPanel");
            this.voiceInfoTableLayoutPanel.Controls.Add(this.voiceAgeLabel, 1, 4);
            this.voiceInfoTableLayoutPanel.Controls.Add(this.voiceAgeHelpLabel, 0, 4);
            this.voiceInfoTableLayoutPanel.Controls.Add(this.voiceGenderLabel, 1, 3);
            this.voiceInfoTableLayoutPanel.Controls.Add(this.voiceGenderHelpLabel, 0, 3);
            this.voiceInfoTableLayoutPanel.Controls.Add(this.voiceCultureLabel, 1, 2);
            this.voiceInfoTableLayoutPanel.Controls.Add(this.voiceCultureHelpLabel, 0, 2);
            this.voiceInfoTableLayoutPanel.Controls.Add(this.voiceDescLabel, 1, 1);
            this.voiceInfoTableLayoutPanel.Controls.Add(this.voiceDescHelpLabel, 0, 1);
            this.voiceInfoTableLayoutPanel.Controls.Add(this.voiceNameLabel, 1, 0);
            this.voiceInfoTableLayoutPanel.Controls.Add(this.voiceNameHelpLabel, 0, 0);
            this.voiceInfoTableLayoutPanel.Name = "voiceInfoTableLayoutPanel";
            // 
            // voiceAgeLabel
            // 
            this.voiceAgeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.voiceAgeLabel, "voiceAgeLabel");
            this.voiceAgeLabel.Name = "voiceAgeLabel";
            // 
            // voiceAgeHelpLabel
            // 
            resources.ApplyResources(this.voiceAgeHelpLabel, "voiceAgeHelpLabel");
            this.voiceAgeHelpLabel.Name = "voiceAgeHelpLabel";
            // 
            // voiceGenderLabel
            // 
            this.voiceGenderLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.voiceGenderLabel, "voiceGenderLabel");
            this.voiceGenderLabel.Name = "voiceGenderLabel";
            // 
            // voiceGenderHelpLabel
            // 
            resources.ApplyResources(this.voiceGenderHelpLabel, "voiceGenderHelpLabel");
            this.voiceGenderHelpLabel.Name = "voiceGenderHelpLabel";
            // 
            // voiceCultureLabel
            // 
            this.voiceCultureLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.voiceCultureLabel, "voiceCultureLabel");
            this.voiceCultureLabel.Name = "voiceCultureLabel";
            // 
            // voiceCultureHelpLabel
            // 
            resources.ApplyResources(this.voiceCultureHelpLabel, "voiceCultureHelpLabel");
            this.voiceCultureHelpLabel.Name = "voiceCultureHelpLabel";
            // 
            // voiceDescLabel
            // 
            this.voiceDescLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.voiceDescLabel, "voiceDescLabel");
            this.voiceDescLabel.Name = "voiceDescLabel";
            // 
            // voiceDescHelpLabel
            // 
            resources.ApplyResources(this.voiceDescHelpLabel, "voiceDescHelpLabel");
            this.voiceDescHelpLabel.Name = "voiceDescHelpLabel";
            // 
            // voiceNameLabel
            // 
            this.voiceNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.voiceNameLabel, "voiceNameLabel");
            this.voiceNameLabel.Name = "voiceNameLabel";
            // 
            // voiceNameHelpLabel
            // 
            resources.ApplyResources(this.voiceNameHelpLabel, "voiceNameHelpLabel");
            this.voiceNameHelpLabel.Name = "voiceNameHelpLabel";
            // 
            // VoiceForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.voiceGroupBox);
            this.Controls.Add(this.voiceInfoGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VoiceForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.VoiceForm_Load);
            this.voiceGroupBox.ResumeLayout(false);
            this.voiceGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).EndInit();
            this.voiceInfoGroupBox.ResumeLayout(false);
            this.voiceInfoTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip mainToolTip;
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.Label rateLabel;
        private System.Windows.Forms.TrackBar rateTrackBar;
        private System.Windows.Forms.TrackBar volumeTrackBar;
        private System.Windows.Forms.ComboBox voiceComboBox;
        private System.Windows.Forms.Label voiceLabel;
        private System.Windows.Forms.GroupBox voiceInfoGroupBox;
        private System.Windows.Forms.TableLayoutPanel voiceInfoTableLayoutPanel;
        private System.Windows.Forms.Label voiceAgeLabel;
        private System.Windows.Forms.Label voiceAgeHelpLabel;
        private System.Windows.Forms.Label voiceGenderLabel;
        private System.Windows.Forms.Label voiceGenderHelpLabel;
        private System.Windows.Forms.Label voiceCultureLabel;
        private System.Windows.Forms.Label voiceCultureHelpLabel;
        private System.Windows.Forms.Label voiceDescLabel;
        private System.Windows.Forms.Label voiceDescHelpLabel;
        private System.Windows.Forms.Label voiceNameLabel;
        private System.Windows.Forms.Label voiceNameHelpLabel;
        private System.Windows.Forms.GroupBox voiceGroupBox;


    }
}