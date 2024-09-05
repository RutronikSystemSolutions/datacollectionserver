namespace datacollectionserver
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comPortLabel = new Label();
            comPortComboBox = new ComboBox();
            refreshButton = new Button();
            collectDataButton = new Button();
            baudRateLabel = new Label();
            baudRateTextBox = new TextBox();
            outputFormatLabel = new Label();
            outputFormatComboBox = new ComboBox();
            dataTypeLabel = new Label();
            dataTypeComboBox = new ComboBox();
            samplesPerPacketLabel = new Label();
            samplesPerPacketTextBox = new TextBox();
            featuresLabel = new Label();
            featuresTextBox = new TextBox();
            sampleRateLabel = new Label();
            sampleRateTextBox = new TextBox();
            statusTextBox = new TextBox();
            liveSignalView = new LiveSignalView();
            outputDirectoryLabel = new Label();
            outputDirectoryTextBox = new TextBox();
            selectOutputDirectoryButton = new Button();
            filePrefixLabel = new Label();
            filePrefixTextBox = new TextBox();
            currentCounterLabel = new Label();
            counterTextBox = new TextBox();
            stopButton = new Button();
            statusLabel = new Label();
            statisticsLabel = new Label();
            statisticsTextBox = new TextBox();
            playWavButton = new Button();
            eraseLastButton = new Button();
            SuspendLayout();
            // 
            // comPortLabel
            // 
            comPortLabel.AutoSize = true;
            comPortLabel.Location = new Point(108, 15);
            comPortLabel.Name = "comPortLabel";
            comPortLabel.Size = new Size(75, 20);
            comPortLabel.TabIndex = 0;
            comPortLabel.Text = "COM Port:";
            // 
            // comPortComboBox
            // 
            comPortComboBox.FormattingEnabled = true;
            comPortComboBox.Location = new Point(189, 12);
            comPortComboBox.Name = "comPortComboBox";
            comPortComboBox.Size = new Size(151, 28);
            comPortComboBox.TabIndex = 1;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(346, 11);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(94, 29);
            refreshButton.TabIndex = 2;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // collectDataButton
            // 
            collectDataButton.Location = new Point(364, 147);
            collectDataButton.Name = "collectDataButton";
            collectDataButton.Size = new Size(131, 29);
            collectDataButton.TabIndex = 3;
            collectDataButton.Text = "Collect data";
            collectDataButton.UseVisualStyleBackColor = true;
            collectDataButton.Click += collectDataButton_Click;
            // 
            // baudRateLabel
            // 
            baudRateLabel.AutoSize = true;
            baudRateLabel.Location = new Point(107, 49);
            baudRateLabel.Name = "baudRateLabel";
            baudRateLabel.Size = new Size(76, 20);
            baudRateLabel.TabIndex = 4;
            baudRateLabel.Text = "Baud rate:";
            // 
            // baudRateTextBox
            // 
            baudRateTextBox.Location = new Point(189, 46);
            baudRateTextBox.Name = "baudRateTextBox";
            baudRateTextBox.Size = new Size(151, 27);
            baudRateTextBox.TabIndex = 5;
            baudRateTextBox.Text = "1000000";
            // 
            // outputFormatLabel
            // 
            outputFormatLabel.AutoSize = true;
            outputFormatLabel.Location = new Point(76, 82);
            outputFormatLabel.Name = "outputFormatLabel";
            outputFormatLabel.Size = new Size(107, 20);
            outputFormatLabel.TabIndex = 6;
            outputFormatLabel.Text = "Output format:";
            // 
            // outputFormatComboBox
            // 
            outputFormatComboBox.FormattingEnabled = true;
            outputFormatComboBox.Items.AddRange(new object[] { ".wav", ".data" });
            outputFormatComboBox.Location = new Point(189, 79);
            outputFormatComboBox.Name = "outputFormatComboBox";
            outputFormatComboBox.Size = new Size(151, 28);
            outputFormatComboBox.TabIndex = 7;
            // 
            // dataTypeLabel
            // 
            dataTypeLabel.AutoSize = true;
            dataTypeLabel.Location = new Point(106, 116);
            dataTypeLabel.Name = "dataTypeLabel";
            dataTypeLabel.Size = new Size(77, 20);
            dataTypeLabel.TabIndex = 8;
            dataTypeLabel.Text = "Data type:";
            // 
            // dataTypeComboBox
            // 
            dataTypeComboBox.FormattingEnabled = true;
            dataTypeComboBox.Items.AddRange(new object[] { "Short", "Float" });
            dataTypeComboBox.Location = new Point(189, 113);
            dataTypeComboBox.Name = "dataTypeComboBox";
            dataTypeComboBox.Size = new Size(151, 28);
            dataTypeComboBox.TabIndex = 9;
            // 
            // samplesPerPacketLabel
            // 
            samplesPerPacketLabel.AutoSize = true;
            samplesPerPacketLabel.Location = new Point(41, 150);
            samplesPerPacketLabel.Name = "samplesPerPacketLabel";
            samplesPerPacketLabel.Size = new Size(142, 20);
            samplesPerPacketLabel.TabIndex = 10;
            samplesPerPacketLabel.Text = "Samples per packet:";
            // 
            // samplesPerPacketTextBox
            // 
            samplesPerPacketTextBox.Location = new Point(189, 147);
            samplesPerPacketTextBox.Name = "samplesPerPacketTextBox";
            samplesPerPacketTextBox.Size = new Size(151, 27);
            samplesPerPacketTextBox.TabIndex = 11;
            samplesPerPacketTextBox.Text = "1024";
            // 
            // featuresLabel
            // 
            featuresLabel.AutoSize = true;
            featuresLabel.Location = new Point(116, 183);
            featuresLabel.Name = "featuresLabel";
            featuresLabel.Size = new Size(67, 20);
            featuresLabel.TabIndex = 12;
            featuresLabel.Text = "Features:";
            // 
            // featuresTextBox
            // 
            featuresTextBox.Location = new Point(189, 180);
            featuresTextBox.Name = "featuresTextBox";
            featuresTextBox.Size = new Size(151, 27);
            featuresTextBox.TabIndex = 13;
            featuresTextBox.Text = "1";
            // 
            // sampleRateLabel
            // 
            sampleRateLabel.AutoSize = true;
            sampleRateLabel.Location = new Point(59, 216);
            sampleRateLabel.Name = "sampleRateLabel";
            sampleRateLabel.Size = new Size(124, 20);
            sampleRateLabel.TabIndex = 14;
            sampleRateLabel.Text = "Sample rate (Hz):";
            // 
            // sampleRateTextBox
            // 
            sampleRateTextBox.Location = new Point(189, 213);
            sampleRateTextBox.Name = "sampleRateTextBox";
            sampleRateTextBox.Size = new Size(151, 27);
            sampleRateTextBox.TabIndex = 15;
            sampleRateTextBox.Text = "16000";
            // 
            // statusTextBox
            // 
            statusTextBox.Location = new Point(731, 148);
            statusTextBox.Name = "statusTextBox";
            statusTextBox.ReadOnly = true;
            statusTextBox.Size = new Size(228, 27);
            statusTextBox.TabIndex = 16;
            // 
            // liveSignalView
            // 
            liveSignalView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            liveSignalView.BorderStyle = BorderStyle.FixedSingle;
            liveSignalView.Location = new Point(12, 246);
            liveSignalView.Name = "liveSignalView";
            liveSignalView.Size = new Size(1202, 377);
            liveSignalView.TabIndex = 17;
            // 
            // outputDirectoryLabel
            // 
            outputDirectoryLabel.AutoSize = true;
            outputDirectoryLabel.Location = new Point(604, 15);
            outputDirectoryLabel.Name = "outputDirectoryLabel";
            outputDirectoryLabel.Size = new Size(121, 20);
            outputDirectoryLabel.TabIndex = 18;
            outputDirectoryLabel.Text = "Output directory:";
            // 
            // outputDirectoryTextBox
            // 
            outputDirectoryTextBox.Location = new Point(731, 12);
            outputDirectoryTextBox.Name = "outputDirectoryTextBox";
            outputDirectoryTextBox.ReadOnly = true;
            outputDirectoryTextBox.Size = new Size(191, 27);
            outputDirectoryTextBox.TabIndex = 19;
            // 
            // selectOutputDirectoryButton
            // 
            selectOutputDirectoryButton.Location = new Point(928, 11);
            selectOutputDirectoryButton.Name = "selectOutputDirectoryButton";
            selectOutputDirectoryButton.Size = new Size(35, 29);
            selectOutputDirectoryButton.TabIndex = 20;
            selectOutputDirectoryButton.Text = "...";
            selectOutputDirectoryButton.UseVisualStyleBackColor = true;
            selectOutputDirectoryButton.Click += selectOutputDirectoryButton_Click;
            // 
            // filePrefixLabel
            // 
            filePrefixLabel.AutoSize = true;
            filePrefixLabel.Location = new Point(648, 49);
            filePrefixLabel.Name = "filePrefixLabel";
            filePrefixLabel.Size = new Size(77, 20);
            filePrefixLabel.TabIndex = 21;
            filePrefixLabel.Text = "File prefix:";
            // 
            // filePrefixTextBox
            // 
            filePrefixTextBox.Location = new Point(731, 46);
            filePrefixTextBox.Name = "filePrefixTextBox";
            filePrefixTextBox.Size = new Size(191, 27);
            filePrefixTextBox.TabIndex = 22;
            // 
            // currentCounterLabel
            // 
            currentCounterLabel.AutoSize = true;
            currentCounterLabel.Location = new Point(371, 185);
            currentCounterLabel.Name = "currentCounterLabel";
            currentCounterLabel.Size = new Size(64, 20);
            currentCounterLabel.TabIndex = 23;
            currentCounterLabel.Text = "Counter:";
            // 
            // counterTextBox
            // 
            counterTextBox.Location = new Point(441, 182);
            counterTextBox.Name = "counterTextBox";
            counterTextBox.ReadOnly = true;
            counterTextBox.Size = new Size(191, 27);
            counterTextBox.TabIndex = 24;
            counterTextBox.Text = "0";
            // 
            // stopButton
            // 
            stopButton.Enabled = false;
            stopButton.Location = new Point(501, 146);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(131, 29);
            stopButton.TabIndex = 25;
            stopButton.Text = "Stop";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(676, 151);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(49, 20);
            statusLabel.TabIndex = 26;
            statusLabel.Text = "Status";
            // 
            // statisticsLabel
            // 
            statisticsLabel.AutoSize = true;
            statisticsLabel.Location = new Point(658, 184);
            statisticsLabel.Name = "statisticsLabel";
            statisticsLabel.Size = new Size(67, 20);
            statisticsLabel.TabIndex = 27;
            statisticsLabel.Text = "Statistics";
            // 
            // statisticsTextBox
            // 
            statisticsTextBox.Location = new Point(731, 181);
            statisticsTextBox.Name = "statisticsTextBox";
            statisticsTextBox.ReadOnly = true;
            statisticsTextBox.Size = new Size(228, 27);
            statisticsTextBox.TabIndex = 28;
            // 
            // playWavButton
            // 
            playWavButton.Location = new Point(1027, 146);
            playWavButton.Name = "playWavButton";
            playWavButton.Size = new Size(94, 29);
            playWavButton.TabIndex = 29;
            playWavButton.Text = "Play WAV";
            playWavButton.UseVisualStyleBackColor = true;
            playWavButton.Click += playWavButton_Click;
            // 
            // eraseLastButton
            // 
            eraseLastButton.Location = new Point(1027, 180);
            eraseLastButton.Name = "eraseLastButton";
            eraseLastButton.Size = new Size(94, 29);
            eraseLastButton.TabIndex = 30;
            eraseLastButton.Text = "Erase last";
            eraseLastButton.UseVisualStyleBackColor = true;
            eraseLastButton.Click += eraseLastButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1226, 635);
            Controls.Add(eraseLastButton);
            Controls.Add(playWavButton);
            Controls.Add(statisticsTextBox);
            Controls.Add(statisticsLabel);
            Controls.Add(statusLabel);
            Controls.Add(stopButton);
            Controls.Add(counterTextBox);
            Controls.Add(currentCounterLabel);
            Controls.Add(filePrefixTextBox);
            Controls.Add(filePrefixLabel);
            Controls.Add(selectOutputDirectoryButton);
            Controls.Add(outputDirectoryTextBox);
            Controls.Add(outputDirectoryLabel);
            Controls.Add(liveSignalView);
            Controls.Add(statusTextBox);
            Controls.Add(sampleRateTextBox);
            Controls.Add(sampleRateLabel);
            Controls.Add(featuresTextBox);
            Controls.Add(featuresLabel);
            Controls.Add(samplesPerPacketTextBox);
            Controls.Add(samplesPerPacketLabel);
            Controls.Add(dataTypeComboBox);
            Controls.Add(dataTypeLabel);
            Controls.Add(outputFormatComboBox);
            Controls.Add(outputFormatLabel);
            Controls.Add(baudRateTextBox);
            Controls.Add(baudRateLabel);
            Controls.Add(collectDataButton);
            Controls.Add(refreshButton);
            Controls.Add(comPortComboBox);
            Controls.Add(comPortLabel);
            Name = "MainForm";
            Text = "Data collection server";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label comPortLabel;
        private ComboBox comPortComboBox;
        private Button refreshButton;
        private Button collectDataButton;
        private Label baudRateLabel;
        private TextBox baudRateTextBox;
        private Label outputFormatLabel;
        private ComboBox outputFormatComboBox;
        private Label dataTypeLabel;
        private ComboBox dataTypeComboBox;
        private Label samplesPerPacketLabel;
        private TextBox samplesPerPacketTextBox;
        private Label featuresLabel;
        private TextBox featuresTextBox;
        private Label sampleRateLabel;
        private TextBox sampleRateTextBox;
        private TextBox statusTextBox;
        private LiveSignalView liveSignalView;
        private Label outputDirectoryLabel;
        private TextBox outputDirectoryTextBox;
        private Button selectOutputDirectoryButton;
        private Label filePrefixLabel;
        private TextBox filePrefixTextBox;
        private Label currentCounterLabel;
        private TextBox counterTextBox;
        private Button stopButton;
        private Label statusLabel;
        private Label statisticsLabel;
        private TextBox statisticsTextBox;
        private Button playWavButton;
        private Button eraseLastButton;
    }
}
