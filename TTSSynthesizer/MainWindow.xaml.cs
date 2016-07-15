using System;
using System.ComponentModel;
using System.Speech.Synthesis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TTSSynthesizer
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new SpeechState();

            SpeechState.Current.PropertyChanged += SpeechState_PropertyChanged;
        }

        // Use preview drag and drop events to override the default behaviors of the control

        private void MainWindow_PreviewDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
                e.Handled = true; // Only stop handling after a file drop
            }
        }

        private void MainWindow_Drop(object sender, DragEventArgs e)
        {
            String[] files = e.Data.GetData(DataFormats.FileDrop) as String[];

            if (files != null && files.Length > 0)
            {
                SpeechState.Current.Text = TextHelper.LoadTextFile(files[0]);
            }
        }

        private void VoiceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SpeechState.Current.Voice = (e.AddedItems[0] as InstalledVoice).VoiceInfo;
        }

        private void SpeechState_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (ContentTextBox.IsReadOnly && e.PropertyName == nameof(SpeechState.SpeakingTextIndex))
            {
                // A fix to simulate TextBox.HideSelection = False in Windows Forms
                // Set FocusManager.IsFocusScope = true on StackPanel
                // Then, the following Keyboard.Focus() statements can set logical focus on TextBox, but actual focus on StackPanel
                Keyboard.Focus(ContentTextBox);
                Keyboard.Focus(VoiceControlStackPanel);

                ContentTextBox.Select(SpeechState.Current.SpeakingTextIndex, SpeechState.Current.SpeakingText.Length);
            }
        }
    }
}