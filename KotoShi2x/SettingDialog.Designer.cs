namespace KotoShi2x {
    partial class SettingDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingDialog));
            this.textBoxExVoiceDirectory = new System.Windows.Forms.TextBox();
            this.buttonSelectExVoiceDirectory = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewExVoices = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCreateExVoiceList = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonExecuteUpdate = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxExVoiceDirectory
            // 
            this.textBoxExVoiceDirectory.AllowDrop = true;
            this.textBoxExVoiceDirectory.Location = new System.Drawing.Point(6, 18);
            this.textBoxExVoiceDirectory.Name = "textBoxExVoiceDirectory";
            this.textBoxExVoiceDirectory.Size = new System.Drawing.Size(507, 19);
            this.textBoxExVoiceDirectory.TabIndex = 1;
            this.textBoxExVoiceDirectory.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxExVoiceDirectory_DragDrop);
            this.textBoxExVoiceDirectory.DragOver += new System.Windows.Forms.DragEventHandler(this.textBoxExVoiceDirectory_DragOver);
            // 
            // buttonSelectExVoiceDirectory
            // 
            this.buttonSelectExVoiceDirectory.Location = new System.Drawing.Point(519, 16);
            this.buttonSelectExVoiceDirectory.Name = "buttonSelectExVoiceDirectory";
            this.buttonSelectExVoiceDirectory.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectExVoiceDirectory.TabIndex = 2;
            this.buttonSelectExVoiceDirectory.Text = "参照...";
            this.buttonSelectExVoiceDirectory.UseVisualStyleBackColor = true;
            this.buttonSelectExVoiceDirectory.Click += new System.EventHandler(this.buttonSelectExVoiceDirectory_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxExVoiceDirectory);
            this.groupBox1.Controls.Add(this.buttonSelectExVoiceDirectory);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 48);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "①exVoiceの参照先ディレクトリを指定します。";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listViewExVoices);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.buttonCreateExVoiceList);
            this.groupBox2.Location = new System.Drawing.Point(12, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 189);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "②exVoiceリストを作成します。";
            // 
            // listViewExVoices
            // 
            this.listViewExVoices.FullRowSelect = true;
            this.listViewExVoices.GridLines = true;
            this.listViewExVoices.HideSelection = false;
            this.listViewExVoices.Location = new System.Drawing.Point(7, 48);
            this.listViewExVoices.MultiSelect = false;
            this.listViewExVoices.Name = "listViewExVoices";
            this.listViewExVoices.Size = new System.Drawing.Size(587, 135);
            this.listViewExVoices.TabIndex = 3;
            this.listViewExVoices.UseCompatibleStateImageBehavior = false;
            this.listViewExVoices.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(447, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "※wavファイル以外の音声ファイルには非対応です。サブフォルダ以下のファイルも検索されます。";
            // 
            // buttonCreateExVoiceList
            // 
            this.buttonCreateExVoiceList.Location = new System.Drawing.Point(6, 18);
            this.buttonCreateExVoiceList.Name = "buttonCreateExVoiceList";
            this.buttonCreateExVoiceList.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateExVoiceList.TabIndex = 0;
            this.buttonCreateExVoiceList.Text = "作成";
            this.buttonCreateExVoiceList.UseVisualStyleBackColor = true;
            this.buttonCreateExVoiceList.Click += new System.EventHandler(this.buttonCreateExVoiceList_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonExecuteUpdate);
            this.groupBox3.Controls.Add(this.buttonCancel);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(12, 261);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(600, 48);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "③exVoiceリストを更新します。";
            // 
            // buttonExecuteUpdate
            // 
            this.buttonExecuteUpdate.Location = new System.Drawing.Point(438, 19);
            this.buttonExecuteUpdate.Name = "buttonExecuteUpdate";
            this.buttonExecuteUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonExecuteUpdate.TabIndex = 7;
            this.buttonExecuteUpdate.Text = "更新実行";
            this.buttonExecuteUpdate.UseVisualStyleBackColor = true;
            this.buttonExecuteUpdate.Click += new System.EventHandler(this.buttonExecuteUpdate_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(519, 19);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(360, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "同時に、現在使用しているフレーズ辞書にexVoice用フレーズを登録します。\r\nあらかじめVOICEROID2を起動しておいてください。";
            // 
            // SettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 321);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingDialog";
            this.Text = "設定";
            this.Shown += new System.EventHandler(this.SettingDialog_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxExVoiceDirectory;
        private System.Windows.Forms.Button buttonSelectExVoiceDirectory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCreateExVoiceList;
        private System.Windows.Forms.ListView listViewExVoices;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonExecuteUpdate;
    }
}