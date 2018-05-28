namespace KotoShi2x {
    partial class MainForm {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonInsertPhrase = new System.Windows.Forms.Button();
            this.textBoxFilterQuery = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.listViewExVoices = new System.Windows.Forms.ListView();
            this.buttonSaveVoice = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 259);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(464, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // buttonInsertPhrase
            // 
            this.buttonInsertPhrase.Location = new System.Drawing.Point(14, 233);
            this.buttonInsertPhrase.Name = "buttonInsertPhrase";
            this.buttonInsertPhrase.Size = new System.Drawing.Size(96, 23);
            this.buttonInsertPhrase.TabIndex = 16;
            this.buttonInsertPhrase.Text = "exVoice挿入";
            this.toolTip1.SetToolTip(this.buttonInsertPhrase, "エディタのカーソル位置に、現在選択されているexVoice用のフレーズを挿入します。\r\nリスト上の項目をダブルクリックすることでもフレーズを挿入できます。");
            this.buttonInsertPhrase.UseVisualStyleBackColor = true;
            this.buttonInsertPhrase.Click += new System.EventHandler(this.buttonInsertPhrase_Click);
            // 
            // textBoxFilterQuery
            // 
            this.textBoxFilterQuery.Location = new System.Drawing.Point(52, 12);
            this.textBoxFilterQuery.Name = "textBoxFilterQuery";
            this.textBoxFilterQuery.Size = new System.Drawing.Size(400, 19);
            this.textBoxFilterQuery.TabIndex = 19;
            this.textBoxFilterQuery.TextChanged += new System.EventHandler(this.textBoxFilterQuery_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "フィルタ:";
            this.toolTip1.SetToolTip(this.label1, "ファイル名でexVoiceを絞り込みます。\r\n複数条件をスペースで区切ってAND検索できます。");
            // 
            // buttonSettings
            // 
            this.buttonSettings.Location = new System.Drawing.Point(377, 233);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(75, 23);
            this.buttonSettings.TabIndex = 21;
            this.buttonSettings.Text = "設定...";
            this.toolTip1.SetToolTip(this.buttonSettings, "exVoiceの参照元ディレクトリなどを設定します。\r\nVOICEROID2へのexVoice用フレーズ登録もここで行います。");
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // listViewExVoices
            // 
            this.listViewExVoices.FullRowSelect = true;
            this.listViewExVoices.GridLines = true;
            this.listViewExVoices.HideSelection = false;
            this.listViewExVoices.Location = new System.Drawing.Point(12, 37);
            this.listViewExVoices.MultiSelect = false;
            this.listViewExVoices.Name = "listViewExVoices";
            this.listViewExVoices.Size = new System.Drawing.Size(440, 190);
            this.listViewExVoices.TabIndex = 22;
            this.listViewExVoices.UseCompatibleStateImageBehavior = false;
            this.listViewExVoices.View = System.Windows.Forms.View.Details;
            this.listViewExVoices.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewExVoices_MouseDoubleClick);
            // 
            // buttonSaveVoice
            // 
            this.buttonSaveVoice.Enabled = false;
            this.buttonSaveVoice.Location = new System.Drawing.Point(296, 233);
            this.buttonSaveVoice.Name = "buttonSaveVoice";
            this.buttonSaveVoice.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveVoice.TabIndex = 24;
            this.buttonSaveVoice.Text = "音声保存";
            this.toolTip1.SetToolTip(this.buttonSaveVoice, "(未実装)");
            this.buttonSaveVoice.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 281);
            this.Controls.Add(this.buttonSaveVoice);
            this.Controls.Add(this.listViewExVoices);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFilterQuery);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonInsertPhrase);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "ことしずく  ver.α1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button buttonInsertPhrase;
        private System.Windows.Forms.TextBox textBoxFilterQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.ListView listViewExVoices;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonSaveVoice;
    }
}

