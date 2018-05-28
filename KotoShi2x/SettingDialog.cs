using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using NAudio.Wave;

namespace KotoShi2x {
    public partial class SettingDialog : Form {
        public SettingDialog() {
            InitializeComponent();
            textBoxExVoiceDirectory.Text = Properties.Settings.Default.exVoicesBaseDirectory;
            listViewExVoices.Columns.Add("ファイル名");
            listViewExVoices.Columns.Add("フレーズ名");
            listViewExVoices.Columns.Add("長さ");

        }

        private void buttonSelectExVoiceDirectory_Click(object sender, EventArgs e) {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = textBoxExVoiceDirectory.Text;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok) {
                textBoxExVoiceDirectory.Text =  dialog.FileName;
            }
        }

        private void textBoxExVoiceDirectory_DragDrop(object sender, DragEventArgs e) {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length != 0) {
                textBoxExVoiceDirectory.Text = files[0];
            }
        }

        private void textBoxExVoiceDirectory_DragOver(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                string path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                if (Directory.Exists(path)) {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }
            e.Effect = DragDropEffects.None;
        }

        private void buttonCreateExVoiceList_Click(object sender, EventArgs e) {
            if (!Directory.Exists(textBoxExVoiceDirectory.Text)) {
                MessageBox.Show("exVoiceの参照先ディレクトリが存在しません", "", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            Dictionary<string, string> dictOfExVoices = PhraseNameGenerator.GenerateDictionary(textBoxExVoiceDirectory.Text);
            listViewExVoices.Items.Clear();

            foreach (KeyValuePair<string, string> item in dictOfExVoices) {
                Debug.WriteLine(textBoxExVoiceDirectory.Text + "\\" + item.Value.Replace("/","\\"));
                uint duration = (uint)new MediaFoundationReader(textBoxExVoiceDirectory.Text + "\\" + item.Value.Replace("/", "\\")).TotalTime.TotalMilliseconds;
                listViewExVoices.Items.Add(new ListViewItem(new string[] { item.Value, item.Key, duration.ToString() }));
            }


            foreach (ColumnHeader columnHeader in listViewExVoices.Columns) {
                columnHeader.Width = -2;
            }

            buttonExecuteUpdate.Enabled = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void buttonExecuteUpdate_Click(object sender, EventArgs e) {
            if (! (Owner as MainForm).v2EProxy.IsValid) {
                MessageBox.Show("VOICEROID2を起動してください。", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            UpdateExVoiceList();
            SaveExVoicePhrases();
            MessageBox.Show("exVoiceリストを更新しました。", "更新完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void UpdateExVoiceList() {
            Properties.Settings.Default.exVoicesBaseDirectory = textBoxExVoiceDirectory.Text;
            Properties.Settings.Default.Save();

            (Owner as MainForm).UpdateExVoicesList();
        }

        private void SaveExVoicePhrases() {
            (Owner as MainForm).v2EProxy.MergePdicToCurrent(GeneratePdicToMerge());
        }

        private string GeneratePdicToMerge() {
            string path = Path.GetFullPath("kotoshi2x_temp.pdic");
            using (StreamWriter w = new StreamWriter(path, false, System.Text.Encoding.GetEncoding("shift_jis"))) {
                w.WriteLine(
                    "# ComponentName=\"AITalk SDK\" ComponentVersion=\"1.0.0.1\" UpdateDateTime=\"" + DateTime.Now.ToString("yyyy/mm/dd hh:mm:ss.fff") + "\" Type=\"Phrase\" Version=\"3.3\" Language=\"Japanese\" Dialect=\"Kansai\" Count=\"" + listViewExVoices.Items.Count.ToString() + "\"");
                for (int i = 0; i < listViewExVoices.Items.Count; ++i) {
                    w.WriteLine("num:" + i.ToString());
                    ListViewItem item = listViewExVoices.Items[i];
                    w.WriteLine(item.SubItems[1].Text);
                    w.WriteLine("$2_2^ッ|0(Pau MSEC=" + item.SubItems[2].Text + ")<F>");
                }
            }
            return path;
        }

        private void SettingDialog_Shown(object sender, EventArgs e) {
            buttonExecuteUpdate.Enabled = false;
        }

    }
}
