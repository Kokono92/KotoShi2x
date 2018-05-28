using System;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using NAudio.Wave;

namespace KotoShi2x {
    public partial class MainForm : Form {

        public V2EProxy v2EProxy;

        private Multimedia.Timer timer;
        private Dictionary<string, string> dictOfExVoices;

        public MainForm() {
            InitializeComponent();

            v2EProxy = new V2EProxy();
            timer = new Multimedia.Timer();
            dictOfExVoices = new Dictionary<string, string>();

            InitializeTimer();
            EnumerateExVoices();
        }

        private void InitializeTimer() {
            timer.Resolution = 0;
            timer.Period = 1;
            timer.Tick += new EventHandler(TimerTick); ;
        }

        private void EnumerateExVoices() {
            listViewExVoices.Columns.Add("ファイル名");
            listViewExVoices.Columns.Add("フレーズ名");

            if (Properties.Settings.Default.exVoicesBaseDirectory != "") {
                UpdateExVoicesList();
            }

            foreach (ColumnHeader columnHeader in listViewExVoices.Columns) {
                columnHeader.Width = -2;
            }
        }

        private void DisableButtons() {
            SetButtonsEnabled(false);
        }

        private void EnableButtons() {
            SetButtonsEnabled(true);
        }

        private void SetButtonsEnabled(bool enabled = true) {
            buttonInsertPhrase.Enabled = enabled;
            buttonSaveVoice.Enabled = enabled;
            buttonSettings.Enabled = enabled;
        }



        private void TimerTick(object sender, EventArgs e) {
            try {
                timer.Stop();
                if (!v2EProxy.IsValid) {
                    Invoke(new Action(DisableButtons));
                    toolStripStatusLabel1.Text = "VOICEROID2が起動していません";
                    Thread.Sleep(500);
                    v2EProxy.TryToAttach();

                } else if (v2EProxy.IsDialogOpening){
                    Invoke(new Action(DisableButtons));
                    toolStripStatusLabel1.Text = "ダイアログが開いています";
                } else if (v2EProxy.IsPlaying) {
                    Invoke(new Action(DisableButtons));
                    string currentPhrase = v2EProxy.CurrentPhrase;
                    Invoke(new Action<string>((str) => { toolStripStatusLabel1.Text = str; }), currentPhrase);
                    string exVoicePath;
                    if (dictOfExVoices.TryGetValue(currentPhrase, out exVoicePath)) {
                        using (WaveOut waveOut = new WaveOut())
                        using (AudioFileReader audioFileReader = new AudioFileReader(Properties.Settings.Default.exVoicesBaseDirectory + "\\" + exVoicePath)) {
                            waveOut.Init(audioFileReader);
                            waveOut.Play();
                            while (waveOut.PlaybackState == NAudio.Wave.PlaybackState.Playing) {
                                Thread.Sleep(1);
                            }
                        }
                    }
                } else {
                    Invoke(new Action(EnableButtons));
                    toolStripStatusLabel1.Text = "Ready";
                }
                timer.Start();
            } catch(ObjectDisposedException ex) {
                // 窓を閉じるタイミングによっては
                // Formが先に破棄されてしまい例外が飛んでくる
                Debug.WriteLine(ex.Message);
            }
            return;
        }

        private void buttonInsertPhrase_Click(object sender, EventArgs e) {
            InsertPhrase();
        }

        private void listViewExVoices_MouseDoubleClick(object sender, MouseEventArgs e) {
            InsertPhrase();
        }

        private void InsertPhrase() {
            if (v2EProxy.IsValid && !v2EProxy.IsPlaying) {
                v2EProxy.InsertText(listViewExVoices.SelectedItems[0].SubItems[1].Text);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            timer.Stop();
        }

        private void buttonSettings_Click(object sender, EventArgs e) {
            new SettingDialog().ShowDialog(this);
        }

        public void UpdateExVoicesList() {
            if (!Directory.Exists(Properties.Settings.Default.exVoicesBaseDirectory)) {
                MessageBox.Show("exVoiceの参照先ディレクトリが存在しません", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            listViewExVoices.Items.Clear();

            dictOfExVoices = PhraseNameGenerator.GenerateDictionary(Properties.Settings.Default.exVoicesBaseDirectory);

            foreach (KeyValuePair<string,string> item in dictOfExVoices) {
                listViewExVoices.Items.Add(new ListViewItem(new string[] { item.Value, item.Key }));
            }

            listViewExVoices.Items[0].Selected = true;
        }

        private void textBoxFilterQuery_TextChanged(object sender, EventArgs e) {
            listViewExVoices.Items.Clear();
            foreach(var item in dictOfExVoices) {
                string[] queries = textBoxFilterQuery.Text.Replace('　', ' ').Split(' ');
                bool matched = true;
                foreach (string query in queries) {
                    if (! item.Value.Contains(query)) {
                        matched = false;
                        break;
                    }
                }
                if (matched) {
                    listViewExVoices.Items.Add(new ListViewItem(new string[] { item.Value, item.Key }));
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e) {
            timer.Start();
        }
    }

    

}



