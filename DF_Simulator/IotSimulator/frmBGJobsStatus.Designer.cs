namespace IOTSimulator
{
    partial class frmBGJobsStatus
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
            dataGridView1 = new DataGridView();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            sensor = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            timertype = new DataGridViewTextBoxColumn();
            currentjobstatus = new DataGridViewTextBoxColumn();
            Action = new DataGridViewButtonColumn();
            id = new DataGridViewTextBoxColumn();
            simulatorname = new DataGridViewTextBoxColumn();
            timestamp = new DataGridViewTextBoxColumn();
            timer = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn4, sensor, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn2, timertype, currentjobstatus, Action });
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(876, 176);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "id";
            dataGridViewTextBoxColumn5.HeaderText = "Id";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "simulatorname";
            dataGridViewTextBoxColumn4.HeaderText = "Simulator Name ";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // sensor
            // 
            sensor.DataPropertyName = "sensor";
            sensor.HeaderText = "Sensor";
            sensor.Name = "sensor";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "timestamp";
            dataGridViewTextBoxColumn3.HeaderText = "Timestamp";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "timer";
            dataGridViewTextBoxColumn2.HeaderText = "Timer";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // timertype
            // 
            timertype.DataPropertyName = "timertype";
            timertype.HeaderText = "Timer Type ";
            timertype.Name = "timertype";
            // 
            // currentjobstatus
            // 
            currentjobstatus.DataPropertyName = "currentjobstatus";
            currentjobstatus.HeaderText = "Current Status";
            currentjobstatus.Name = "currentjobstatus";
            // 
            // Action
            // 
            Action.DataPropertyName = "Action";
            Action.HeaderText = "Action";
            Action.Name = "Action";
            Action.Resizable = DataGridViewTriState.True;
            Action.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // id
            // 
            id.HeaderText = "Id";
            id.Name = "id";
            // 
            // simulatorname
            // 
            simulatorname.HeaderText = "Simulator Name";
            simulatorname.Name = "simulatorname";
            // 
            // timestamp
            // 
            timestamp.HeaderText = "Timestamp ";
            timestamp.Name = "timestamp";
            // 
            // timer
            // 
            timer.HeaderText = "Timer";
            timer.Name = "timer";
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Id";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // frmBGJobsStatus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 450);
            Controls.Add(dataGridView1);
            Name = "frmBGJobsStatus";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BG Jobs Status";
            Load += frmBGJobsStatus_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn simulatorname;
        private DataGridViewTextBoxColumn timestamp;
        private DataGridViewTextBoxColumn timer;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn sensor;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn timertype;
        private DataGridViewTextBoxColumn currentjobstatus;
        private DataGridViewButtonColumn Action;
    }
}