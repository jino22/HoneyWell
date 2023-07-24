namespace IOTSimulator
{
    partial class frmBuildSimulator
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
            label1 = new Label();
            dataTypeLabel = new Label();
            fieldNameLabel = new Label();
            minLengthLabel = new Label();
            maxLengthLabel = new Label();
            emptyLabel1 = new Label();
            emptyLabel2 = new Label();
            textField = new TextBox();
            dataTypeDropdown = new ComboBox();
            txtMin = new TextBox();
            txtMax = new TextBox();
            btnAdd = new Button();
            btnClear = new Button();
            dataGridView1 = new DataGridView();
            label8 = new Label();
            textBox4 = new TextBox();
            fileFormatlabel = new Label();
            label12 = new Label();
            fileFormatDatatype = new ComboBox();
            rowsLabel = new Label();
            label15 = new Label();
            label16 = new Label();
            rowsValue = new TextBox();
            errorMessageBox = new Label();
            btnExport = new Button();
            label11 = new Label();
            timeIntervalField = new Label();
            label17 = new Label();
            timeIntervalValue = new TextBox();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            label23 = new Label();
            label24 = new Label();
            label25 = new Label();
            btnSimulatorConfiguation = new Button();
            label26 = new Label();
            label27 = new Label();
            label28 = new Label();
            label29 = new Label();
            label30 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            label2 = new Label();
            txtSimulatorName = new TextBox();
            ddlTimerType = new ComboBox();
            lblErrorMsg = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.BackColor = Color.RoyalBlue;
            label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(14, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(881, 27);
            label1.TabIndex = 0;
            label1.Text = "IOT Simulator";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataTypeLabel
            // 
            dataTypeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataTypeLabel.BackColor = SystemColors.ActiveBorder;
            dataTypeLabel.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            dataTypeLabel.Location = new Point(14, 44);
            dataTypeLabel.Margin = new Padding(4, 0, 4, 0);
            dataTypeLabel.Name = "dataTypeLabel";
            dataTypeLabel.Size = new Size(144, 27);
            dataTypeLabel.TabIndex = 1;
            dataTypeLabel.Text = "Data Type";
            dataTypeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldNameLabel
            // 
            fieldNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            fieldNameLabel.BackColor = SystemColors.ActiveBorder;
            fieldNameLabel.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNameLabel.Location = new Point(162, 44);
            fieldNameLabel.Margin = new Padding(4, 0, 4, 0);
            fieldNameLabel.Name = "fieldNameLabel";
            fieldNameLabel.Size = new Size(144, 27);
            fieldNameLabel.TabIndex = 2;
            fieldNameLabel.Text = "Field Name";
            fieldNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // minLengthLabel
            // 
            minLengthLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            minLengthLabel.BackColor = SystemColors.ActiveBorder;
            minLengthLabel.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            minLengthLabel.Location = new Point(310, 44);
            minLengthLabel.Margin = new Padding(4, 0, 4, 0);
            minLengthLabel.Name = "minLengthLabel";
            minLengthLabel.Size = new Size(144, 27);
            minLengthLabel.TabIndex = 3;
            minLengthLabel.Text = "Min Length";
            minLengthLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // maxLengthLabel
            // 
            maxLengthLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            maxLengthLabel.BackColor = SystemColors.ActiveBorder;
            maxLengthLabel.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            maxLengthLabel.Location = new Point(458, 44);
            maxLengthLabel.Margin = new Padding(4, 0, 4, 0);
            maxLengthLabel.Name = "maxLengthLabel";
            maxLengthLabel.Size = new Size(144, 27);
            maxLengthLabel.TabIndex = 4;
            maxLengthLabel.Text = "Max Length";
            maxLengthLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // emptyLabel1
            // 
            emptyLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            emptyLabel1.BackColor = SystemColors.ActiveBorder;
            emptyLabel1.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            emptyLabel1.Location = new Point(607, 44);
            emptyLabel1.Margin = new Padding(4, 0, 4, 0);
            emptyLabel1.Name = "emptyLabel1";
            emptyLabel1.Size = new Size(144, 27);
            emptyLabel1.TabIndex = 5;
            emptyLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // emptyLabel2
            // 
            emptyLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            emptyLabel2.BackColor = SystemColors.ActiveBorder;
            emptyLabel2.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            emptyLabel2.Location = new Point(755, 44);
            emptyLabel2.Margin = new Padding(4, 0, 4, 0);
            emptyLabel2.Name = "emptyLabel2";
            emptyLabel2.Size = new Size(139, 27);
            emptyLabel2.TabIndex = 6;
            emptyLabel2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textField
            // 
            textField.Location = new Point(162, 76);
            textField.Margin = new Padding(4, 3, 4, 3);
            textField.Multiline = true;
            textField.Name = "textField";
            textField.Size = new Size(143, 25);
            textField.TabIndex = 7;
            // 
            // dataTypeDropdown
            // 
            dataTypeDropdown.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataTypeDropdown.FormattingEnabled = true;
            dataTypeDropdown.Items.AddRange(new object[] { "int", "decimal", "string", "datetime", "custom" });
            dataTypeDropdown.Location = new Point(15, 77);
            dataTypeDropdown.Margin = new Padding(4, 3, 4, 3);
            dataTypeDropdown.Name = "dataTypeDropdown";
            dataTypeDropdown.Size = new Size(143, 23);
            dataTypeDropdown.TabIndex = 8;
            dataTypeDropdown.Text = "Int";
            dataTypeDropdown.UseWaitCursor = true;
            dataTypeDropdown.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // txtMin
            // 
            txtMin.Location = new Point(310, 76);
            txtMin.Margin = new Padding(4, 3, 4, 3);
            txtMin.Multiline = true;
            txtMin.Name = "txtMin";
            txtMin.Size = new Size(143, 25);
            txtMin.TabIndex = 9;
            // 
            // txtMax
            // 
            txtMax.Location = new Point(458, 76);
            txtMax.Margin = new Padding(4, 3, 4, 3);
            txtMax.Multiline = true;
            txtMax.Name = "txtMax";
            txtMax.Size = new Size(143, 25);
            txtMax.TabIndex = 10;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.PeachPuff;
            btnAdd.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.Location = new Point(605, 75);
            btnAdd.Margin = new Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(146, 27);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Add";
            btnAdd.TextAlign = ContentAlignment.TopCenter;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(255, 224, 192);
            btnClear.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnClear.Location = new Point(754, 75);
            btnClear.Margin = new Padding(4, 3, 4, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(141, 27);
            btnClear.TabIndex = 12;
            btnClear.Text = "Clear";
            btnClear.TextAlign = ContentAlignment.TopCenter;
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(15, 139);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(879, 118);
            dataGridView1.TabIndex = 13;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label8.BackColor = SystemColors.ActiveBorder;
            label8.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(14, 260);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(880, 33);
            label8.TabIndex = 14;
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(689, 296);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(44, 21);
            textBox4.TabIndex = 16;
            textBox4.Text = "10";
            textBox4.TextAlign = HorizontalAlignment.Center;
            // 
            // fileFormatlabel
            // 
            fileFormatlabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            fileFormatlabel.BackColor = SystemColors.ActiveBorder;
            fileFormatlabel.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            fileFormatlabel.Location = new Point(14, 296);
            fileFormatlabel.Margin = new Padding(4, 0, 4, 0);
            fileFormatlabel.Name = "fileFormatlabel";
            fileFormatlabel.Size = new Size(292, 27);
            fileFormatlabel.TabIndex = 18;
            fileFormatlabel.Text = "File Output Format";
            fileFormatlabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label12.BackColor = SystemColors.ActiveBorder;
            label12.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(307, 296);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(147, 27);
            label12.TabIndex = 20;
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fileFormatDatatype
            // 
            fileFormatDatatype.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            fileFormatDatatype.FormattingEnabled = true;
            fileFormatDatatype.Items.AddRange(new object[] { "json", "txt", "xml", "csv", "tsv" });
            fileFormatDatatype.Location = new Point(310, 299);
            fileFormatDatatype.Margin = new Padding(4, 3, 4, 3);
            fileFormatDatatype.Name = "fileFormatDatatype";
            fileFormatDatatype.Size = new Size(140, 23);
            fileFormatDatatype.TabIndex = 21;
            fileFormatDatatype.Text = "JSON";
            fileFormatDatatype.UseWaitCursor = true;
            // 
            // rowsLabel
            // 
            rowsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rowsLabel.BackColor = SystemColors.ActiveBorder;
            rowsLabel.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            rowsLabel.Location = new Point(456, 296);
            rowsLabel.Margin = new Padding(4, 0, 4, 0);
            rowsLabel.Name = "rowsLabel";
            rowsLabel.Size = new Size(146, 27);
            rowsLabel.TabIndex = 23;
            rowsLabel.Text = "No of Rows";
            rowsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label15.BackColor = SystemColors.ActiveBorder;
            label15.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(605, 296);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(146, 27);
            label15.TabIndex = 24;
            label15.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label16.BackColor = SystemColors.ActiveBorder;
            label16.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(752, 295);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(142, 27);
            label16.TabIndex = 25;
            label16.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rowsValue
            // 
            rowsValue.Location = new Point(610, 297);
            rowsValue.Margin = new Padding(4, 3, 4, 3);
            rowsValue.Multiline = true;
            rowsValue.Name = "rowsValue";
            rowsValue.Size = new Size(52, 25);
            rowsValue.TabIndex = 26;
            rowsValue.Text = "0";
            rowsValue.TextAlign = HorizontalAlignment.Center;
            // 
            // errorMessageBox
            // 
            errorMessageBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            errorMessageBox.BackColor = SystemColors.ActiveBorder;
            errorMessageBox.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            errorMessageBox.Location = new Point(15, 103);
            errorMessageBox.Margin = new Padding(4, 0, 4, 0);
            errorMessageBox.Name = "errorMessageBox";
            errorMessageBox.Size = new Size(879, 33);
            errorMessageBox.TabIndex = 27;
            errorMessageBox.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.PeachPuff;
            btnExport.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnExport.Location = new Point(750, 296);
            btnExport.Margin = new Padding(4, 3, 4, 3);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(146, 27);
            btnExport.TabIndex = 28;
            btnExport.Text = "Export";
            btnExport.TextAlign = ContentAlignment.TopCenter;
            btnExport.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label11.BackColor = Color.RoyalBlue;
            label11.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = SystemColors.ButtonFace;
            label11.Location = new Point(12, 326);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(881, 56);
            label11.TabIndex = 29;
            label11.Text = "Simulator Configuration";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timeIntervalField
            // 
            timeIntervalField.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            timeIntervalField.BackColor = SystemColors.ActiveBorder;
            timeIntervalField.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            timeIntervalField.Location = new Point(12, 392);
            timeIntervalField.Margin = new Padding(4, 0, 4, 0);
            timeIntervalField.Name = "timeIntervalField";
            timeIntervalField.Size = new Size(292, 27);
            timeIntervalField.TabIndex = 30;
            timeIntervalField.Text = "Timer Interval";
            timeIntervalField.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label17.BackColor = SystemColors.ActiveBorder;
            label17.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            label17.Location = new Point(751, 392);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(144, 27);
            label17.TabIndex = 31;
            label17.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timeIntervalValue
            // 
            timeIntervalValue.Location = new Point(307, 392);
            timeIntervalValue.Margin = new Padding(4, 3, 4, 3);
            timeIntervalValue.Multiline = true;
            timeIntervalValue.Name = "timeIntervalValue";
            timeIntervalValue.Size = new Size(143, 27);
            timeIntervalValue.TabIndex = 32;
            timeIntervalValue.Text = "5";
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label19.BackColor = Color.LightGray;
            label19.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            label19.Location = new Point(12, 428);
            label19.Margin = new Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new Size(292, 27);
            label19.TabIndex = 34;
            label19.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            label20.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label20.BackColor = Color.LightGray;
            label20.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            label20.Location = new Point(306, 428);
            label20.Margin = new Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new Size(144, 27);
            label20.TabIndex = 35;
            label20.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            label21.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label21.BackColor = Color.LightGray;
            label21.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            label21.Location = new Point(455, 428);
            label21.Margin = new Padding(4, 0, 4, 0);
            label21.Name = "label21";
            label21.Size = new Size(144, 27);
            label21.TabIndex = 36;
            label21.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            label22.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label22.BackColor = Color.LightGray;
            label22.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            label22.Location = new Point(602, 428);
            label22.Margin = new Padding(4, 0, 4, 0);
            label22.Name = "label22";
            label22.Size = new Size(144, 27);
            label22.TabIndex = 37;
            label22.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            label23.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label23.BackColor = Color.LightGray;
            label23.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            label23.Location = new Point(750, 428);
            label23.Margin = new Padding(4, 0, 4, 0);
            label23.Name = "label23";
            label23.Size = new Size(144, 27);
            label23.TabIndex = 38;
            label23.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            label24.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label24.BackColor = SystemColors.ActiveBorder;
            label24.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            label24.Location = new Point(12, 464);
            label24.Margin = new Padding(4, 0, 4, 0);
            label24.Name = "label24";
            label24.Size = new Size(292, 27);
            label24.TabIndex = 39;
            label24.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            label25.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label25.BackColor = SystemColors.ActiveBorder;
            label25.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            label25.Location = new Point(306, 464);
            label25.Margin = new Padding(4, 0, 4, 0);
            label25.Name = "label25";
            label25.Size = new Size(590, 27);
            label25.TabIndex = 40;
            label25.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSimulatorConfiguation
            // 
            btnSimulatorConfiguation.BackColor = Color.PeachPuff;
            btnSimulatorConfiguation.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnSimulatorConfiguation.Location = new Point(307, 464);
            btnSimulatorConfiguation.Margin = new Padding(4, 3, 4, 3);
            btnSimulatorConfiguation.Name = "btnSimulatorConfiguation";
            btnSimulatorConfiguation.Size = new Size(261, 27);
            btnSimulatorConfiguation.TabIndex = 42;
            btnSimulatorConfiguation.Text = "Save Simulator Configuration";
            btnSimulatorConfiguation.TextAlign = ContentAlignment.TopCenter;
            btnSimulatorConfiguation.UseVisualStyleBackColor = false;
            btnSimulatorConfiguation.Click += btnSimulatorConfiguation_Click_1;
            // 
            // label26
            // 
            label26.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label26.BackColor = Color.LightGray;
            label26.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            label26.Location = new Point(13, 494);
            label26.Margin = new Padding(4, 0, 4, 0);
            label26.Name = "label26";
            label26.Size = new Size(292, 27);
            label26.TabIndex = 43;
            label26.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            label27.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label27.BackColor = Color.LightGray;
            label27.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            label27.Location = new Point(602, 494);
            label27.Margin = new Padding(4, 0, 4, 0);
            label27.Name = "label27";
            label27.Size = new Size(144, 27);
            label27.TabIndex = 44;
            label27.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            label28.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label28.BackColor = Color.LightGray;
            label28.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            label28.Location = new Point(749, 494);
            label28.Margin = new Padding(4, 0, 4, 0);
            label28.Name = "label28";
            label28.Size = new Size(144, 27);
            label28.TabIndex = 45;
            label28.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            label29.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label29.BackColor = Color.LightGray;
            label29.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            label29.Location = new Point(455, 494);
            label29.Margin = new Padding(4, 0, 4, 0);
            label29.Name = "label29";
            label29.Size = new Size(144, 27);
            label29.TabIndex = 46;
            label29.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label30
            // 
            label30.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label30.BackColor = Color.LightGray;
            label30.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            label30.Location = new Point(307, 494);
            label30.Margin = new Padding(4, 0, 4, 0);
            label30.Name = "label30";
            label30.Size = new Size(144, 27);
            label30.TabIndex = 47;
            label30.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(310, 77);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(144, 21);
            dateTimePicker1.TabIndex = 48;
            dateTimePicker1.Visible = false;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(458, 77);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(144, 21);
            dateTimePicker2.TabIndex = 49;
            dateTimePicker2.Visible = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.BackColor = SystemColors.ActiveBorder;
            label2.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(15, 428);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(292, 27);
            label2.TabIndex = 50;
            label2.Text = "Simulator Name";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSimulatorName
            // 
            txtSimulatorName.Location = new Point(308, 428);
            txtSimulatorName.Margin = new Padding(4, 3, 4, 3);
            txtSimulatorName.Multiline = true;
            txtSimulatorName.Name = "txtSimulatorName";
            txtSimulatorName.Size = new Size(143, 27);
            txtSimulatorName.TabIndex = 51;
            // 
            // ddlTimerType
            // 
            ddlTimerType.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ddlTimerType.FormattingEnabled = true;
            ddlTimerType.Items.AddRange(new object[] { "Milliseconds", "Seconds", "Minutes", "Hours" });
            ddlTimerType.Location = new Point(455, 392);
            ddlTimerType.Margin = new Padding(4, 3, 4, 3);
            ddlTimerType.Name = "ddlTimerType";
            ddlTimerType.Size = new Size(143, 23);
            ddlTimerType.TabIndex = 52;
            ddlTimerType.Tag = "";
            ddlTimerType.Text = "Milliseconds";
            ddlTimerType.UseWaitCursor = true;
            // 
            // lblErrorMsg
            // 
            lblErrorMsg.AutoSize = true;
            lblErrorMsg.ForeColor = Color.Red;
            lblErrorMsg.Location = new Point(598, 472);
            lblErrorMsg.Name = "lblErrorMsg";
            lblErrorMsg.Size = new Size(0, 15);
            lblErrorMsg.TabIndex = 53;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.BackColor = SystemColors.ActiveBorder;
            label3.Font = new Font("Microsoft Sans Serif", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(602, 392);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(144, 27);
            label3.TabIndex = 54;
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmBuildSimulator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(909, 519);
            Controls.Add(label3);
            Controls.Add(lblErrorMsg);
            Controls.Add(ddlTimerType);
            Controls.Add(txtSimulatorName);
            Controls.Add(label2);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label30);
            Controls.Add(label29);
            Controls.Add(label28);
            Controls.Add(label27);
            Controls.Add(label26);
            Controls.Add(btnSimulatorConfiguation);
            Controls.Add(label25);
            Controls.Add(label24);
            Controls.Add(label23);
            Controls.Add(label22);
            Controls.Add(label21);
            Controls.Add(label20);
            Controls.Add(label19);
            Controls.Add(timeIntervalValue);
            Controls.Add(label17);
            Controls.Add(timeIntervalField);
            Controls.Add(label11);
            Controls.Add(btnExport);
            Controls.Add(errorMessageBox);
            Controls.Add(rowsValue);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(rowsLabel);
            Controls.Add(fileFormatDatatype);
            Controls.Add(label12);
            Controls.Add(fileFormatlabel);
            Controls.Add(textBox4);
            Controls.Add(label8);
            Controls.Add(dataGridView1);
            Controls.Add(btnClear);
            Controls.Add(btnAdd);
            Controls.Add(txtMax);
            Controls.Add(txtMin);
            Controls.Add(dataTypeDropdown);
            Controls.Add(textField);
            Controls.Add(emptyLabel2);
            Controls.Add(emptyLabel1);
            Controls.Add(maxLengthLabel);
            Controls.Add(minLengthLabel);
            Controls.Add(fieldNameLabel);
            Controls.Add(dataTypeLabel);
            Controls.Add(label1);
            Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmBuildSimulator";
            Text = "IOTSimulator";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label dataTypeLabel;
        private System.Windows.Forms.Label fieldNameLabel;
        private System.Windows.Forms.Label minLengthLabel;
        private System.Windows.Forms.Label maxLengthLabel;
        private System.Windows.Forms.Label emptyLabel1;
        private System.Windows.Forms.Label emptyLabel2;
        private System.Windows.Forms.TextBox textField;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label fileFormatlabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox fileFormatDatatype;
        private System.Windows.Forms.Label rowsLabel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox rowsValue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label timeIntervalField;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox timeIntervalValue;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnSimulatorConfiguation;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        public System.Windows.Forms.ComboBox dataTypeDropdown;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label errorMessageBox;
        private Label label2;
        private TextBox txtSimulatorName;
        public ComboBox ddlTimerType;
        private Label lblErrorMsg;
        private Label label3;
    }
}

