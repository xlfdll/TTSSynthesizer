namespace TTSSynthesizer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.contentTextBox = new System.Windows.Forms.TextBox();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.firstToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fileButtonToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.voiceFormToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.voiceFormToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.playToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.stopToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.recordToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.controlButtonToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.lastToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.speakingWordIndexToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.speakingWordIndexLabelToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.speakingStateToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.speakingStateToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.mainToolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.mainToolStripContainer.ContentPanel.SuspendLayout();
            this.mainToolStripContainer.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainToolStripContainer
            // 
            // 
            // mainToolStripContainer.BottomToolStripPanel
            // 
            this.mainToolStripContainer.BottomToolStripPanel.Controls.Add(this.mainToolStrip);
            // 
            // mainToolStripContainer.ContentPanel
            // 
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.contentTextBox);
            resources.ApplyResources(this.mainToolStripContainer.ContentPanel, "mainToolStripContainer.ContentPanel");
            resources.ApplyResources(this.mainToolStripContainer, "mainToolStripContainer");
            this.mainToolStripContainer.LeftToolStripPanelVisible = false;
            this.mainToolStripContainer.Name = "mainToolStripContainer";
            this.mainToolStripContainer.RightToolStripPanelVisible = false;
            this.mainToolStripContainer.TopToolStripPanelVisible = false;
            // 
            // contentTextBox
            // 
            resources.ApplyResources(this.contentTextBox, "contentTextBox");
            this.contentTextBox.HideSelection = false;
            this.contentTextBox.Name = "contentTextBox";
            this.contentTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.contentTextBox_KeyPress);
            // 
            // mainToolStrip
            // 
            resources.ApplyResources(this.mainToolStrip, "mainToolStrip");
            this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firstToolStripSeparator,
            this.newToolStripButton,
            this.openToolStripButton,
            this.fileButtonToolStripSeparator,
            this.voiceFormToolStripButton,
            this.voiceFormToolStripSeparator,
            this.playToolStripButton,
            this.stopToolStripButton,
            this.recordToolStripButton,
            this.controlButtonToolStripSeparator,
            this.speakingStateToolStripLabel,
            this.speakingStateToolStripSeparator,
            this.speakingWordIndexToolStripLabel,
            this.speakingWordIndexLabelToolStripSeparator,
            this.aboutToolStripButton,
            this.lastToolStripSeparator});
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mainToolStrip.Stretch = true;
            this.mainToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mainToolStrip_ItemClicked);
            // 
            // firstToolStripSeparator
            // 
            this.firstToolStripSeparator.Name = "firstToolStripSeparator";
            resources.ApplyResources(this.firstToolStripSeparator, "firstToolStripSeparator");
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.Image = global::TTSSynthesizer.Properties.Resources.New;
            resources.ApplyResources(this.newToolStripButton, "newToolStripButton");
            this.newToolStripButton.Name = "newToolStripButton";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.Image = global::TTSSynthesizer.Properties.Resources.Open;
            resources.ApplyResources(this.openToolStripButton, "openToolStripButton");
            this.openToolStripButton.Name = "openToolStripButton";
            // 
            // fileButtonToolStripSeparator
            // 
            this.fileButtonToolStripSeparator.Name = "fileButtonToolStripSeparator";
            resources.ApplyResources(this.fileButtonToolStripSeparator, "fileButtonToolStripSeparator");
            // 
            // voiceFormToolStripButton
            // 
            this.voiceFormToolStripButton.Image = global::TTSSynthesizer.Properties.Resources.Voice;
            resources.ApplyResources(this.voiceFormToolStripButton, "voiceFormToolStripButton");
            this.voiceFormToolStripButton.Name = "voiceFormToolStripButton";
            // 
            // voiceFormToolStripSeparator
            // 
            this.voiceFormToolStripSeparator.Name = "voiceFormToolStripSeparator";
            resources.ApplyResources(this.voiceFormToolStripSeparator, "voiceFormToolStripSeparator");
            // 
            // playToolStripButton
            // 
            this.playToolStripButton.CheckOnClick = true;
            this.playToolStripButton.Image = global::TTSSynthesizer.Properties.Resources.Play;
            resources.ApplyResources(this.playToolStripButton, "playToolStripButton");
            this.playToolStripButton.Name = "playToolStripButton";
            this.playToolStripButton.CheckedChanged += new System.EventHandler(this.playToolStripButton_CheckedChanged);
            // 
            // stopToolStripButton
            // 
            resources.ApplyResources(this.stopToolStripButton, "stopToolStripButton");
            this.stopToolStripButton.Image = global::TTSSynthesizer.Properties.Resources.Stop;
            this.stopToolStripButton.Name = "stopToolStripButton";
            // 
            // recordToolStripButton
            // 
            this.recordToolStripButton.Image = global::TTSSynthesizer.Properties.Resources.Record;
            resources.ApplyResources(this.recordToolStripButton, "recordToolStripButton");
            this.recordToolStripButton.Name = "recordToolStripButton";
            // 
            // controlButtonToolStripSeparator
            // 
            this.controlButtonToolStripSeparator.Name = "controlButtonToolStripSeparator";
            resources.ApplyResources(this.controlButtonToolStripSeparator, "controlButtonToolStripSeparator");
            // 
            // aboutToolStripButton
            // 
            this.aboutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aboutToolStripButton.Image = global::TTSSynthesizer.Properties.Resources.About;
            resources.ApplyResources(this.aboutToolStripButton, "aboutToolStripButton");
            this.aboutToolStripButton.Name = "aboutToolStripButton";
            // 
            // lastToolStripSeparator
            // 
            this.lastToolStripSeparator.Name = "lastToolStripSeparator";
            resources.ApplyResources(this.lastToolStripSeparator, "lastToolStripSeparator");
            // 
            // speakingWordIndexToolStripLabel
            // 
            this.speakingWordIndexToolStripLabel.Name = "speakingWordIndexToolStripLabel";
            resources.ApplyResources(this.speakingWordIndexToolStripLabel, "speakingWordIndexToolStripLabel");
            // 
            // speakingWordIndexLabelToolStripSeparator
            // 
            this.speakingWordIndexLabelToolStripSeparator.Name = "speakingWordIndexLabelToolStripSeparator";
            resources.ApplyResources(this.speakingWordIndexLabelToolStripSeparator, "speakingWordIndexLabelToolStripSeparator");
            // 
            // speakingStateToolStripSeparator
            // 
            this.speakingStateToolStripSeparator.Name = "speakingStateToolStripSeparator";
            resources.ApplyResources(this.speakingStateToolStripSeparator, "speakingStateToolStripSeparator");
            // 
            // speakingStateToolStripLabel
            // 
            this.speakingStateToolStripLabel.Name = "speakingStateToolStripLabel";
            resources.ApplyResources(this.speakingStateToolStripLabel, "speakingStateToolStripLabel");
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainToolStripContainer);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.mainToolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.mainToolStripContainer.BottomToolStripPanel.PerformLayout();
            this.mainToolStripContainer.ContentPanel.ResumeLayout(false);
            this.mainToolStripContainer.ContentPanel.PerformLayout();
            this.mainToolStripContainer.ResumeLayout(false);
            this.mainToolStripContainer.PerformLayout();
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripSeparator fileButtonToolStripSeparator;
        private System.Windows.Forms.ToolStripButton aboutToolStripButton;
        private System.Windows.Forms.ToolStripButton playToolStripButton;
        private System.Windows.Forms.ToolStripButton stopToolStripButton;
        private System.Windows.Forms.ToolStripButton recordToolStripButton;
        private System.Windows.Forms.ToolStripSeparator controlButtonToolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator lastToolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator firstToolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator voiceFormToolStripSeparator;
        private System.Windows.Forms.ToolStripButton voiceFormToolStripButton;
        private System.Windows.Forms.TextBox contentTextBox;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripContainer mainToolStripContainer;
        private System.Windows.Forms.ToolStripLabel speakingWordIndexToolStripLabel;
        private System.Windows.Forms.ToolStripSeparator speakingWordIndexLabelToolStripSeparator;
        private System.Windows.Forms.ToolStripLabel speakingStateToolStripLabel;
        private System.Windows.Forms.ToolStripSeparator speakingStateToolStripSeparator;
    }
}

