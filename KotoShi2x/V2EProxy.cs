using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using RM.Friendly.WPFStandardControls;
using Codeer.Friendly.Windows.NativeStandardControls;
using System.Linq;
using System.Runtime.InteropServices;

/// <summary>
/// VOICEROID2 Editorへのアクセスを提供するクラスです。
/// TODO: そろそろ分割を考えた方が良いかもしれない
/// </summary>
namespace KotoShi2x {
    public partial class V2EProxy {

        // 基本的に、FriendlyでVOICEROID2と遣り取りする処理には以下のどちらかを噛ませておくこと
        // (処理中にVOIDEROID2を落とすなどすると延々待ち続けるため。特にMainFormのタイマから呼ばれる奴は注意)

        /// <summary>
        /// 処理をタイムアウト付きで実行します。
        /// </summary>
        /// <param name="op">引数を持たない任意の処理</param>
        /// <param name="timeOut">処理のタイムアウト時間[ms] = 100</param>
        private void TimedAction(Action op, int timeOut = 500) {
            Task t = Task.Run(()=> {
                try {
                    op();
                } catch {

                }
            });
            if (t.Wait(timeOut)) {
                return;
            }
        }

        /// <summary>
        /// 処理をタイムアウト付きで実行します。
        /// </summary>
        /// <typeparam name="T">戻り値の型</typeparam>
        /// <param name="op">Tを返す、引数を持たない任意の処理</param>
        /// <param name="timeOut">処理のタイムアウト時間[ms] = 100</param>
        /// <returns>時間内に処理が終了した場合はopの結果。タイムアウトした場合はdefault(T)</returns>
        private T TimedFunc<T>(Func<T> op, int timeOut = 500) {
            Task<T> t = Task.Run(()=> {
                try {
                    return op();
                } catch {
                    return default(T);
                }
            });
            if (!t.Wait(timeOut)) {
                return default(T);
            }
            return t.Result;
        }

        /// <summary>
        /// VOICEROID2への接続を試みます。
        /// 既に接続されている場合でも再接続を試みます。
        /// 接続に成功していれば、IsValidがtrueを返すようになります。
        /// </summary>
        public void TryToAttach() {
                foreach (Process p in Process.GetProcessesByName("VoiceroidEditor")) {
                    if (p.MainWindowHandle == IntPtr.Zero) {
                        continue;
                    } else if (CheckIfIsValidWindowTitle(p.MainWindowTitle)) {
                    TimedAction(() => {
                        app = new WindowsAppFriend(p);
                        rootControl = new WindowControl(app, p.MainWindowHandle);

                        if (rootControl == null) {
                            Detach();
                            return;
                        }

                        wpfControls = new WPFControls(rootControl);
                    }, 5000);
                    }
                }
        }

        /// <summary>
        /// VOICEROID2との接続を断ちます。
        /// </summary>
        public void Detach() {
            wpfControls = null;
            rootControl = null;

            if (app != null) {
                app.Dispose();
                app = null;
                GC.Collect();
            }

        }

        /// <summary>
        /// VOICEROID2と正常に接続されているかどうか
        /// </summary>
        public bool IsValid {
            get {
                if (app == null) {
                    return false;

                } else if (!CheckIfIsValidWindowTitle( TimedFunc(()=> { return Process.GetProcessById(app.ProcessId).MainWindowTitle; }))) {
                    Detach();
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// ダイアログが開いているかどうか
        /// (最前面のウィンドウはVOICEROID2のメインウィンドウかどうか)
        /// </summary>
        public bool IsDialogOpening => TimedFunc(() => {
            try {
                return !CheckIfIsValidWindowTitle(TimedFunc(app.FromZTop().GetWindowText));
            } catch {
                return false;
            }
        });

        /// <summary>
        /// VOICEROID2テキスト編集欄の現在キャレット位置に文字列を挿入します。
        /// </summary>
        /// <param name="text">挿入する文字列</param>
        public void InsertText(string text) => TimedAction(() => {
            int initialCaretIndex = wpfControls.textBox.CaretIndex;
            wpfControls.textBox.EmulateChangeText(wpfControls.textBox.Text.Insert(initialCaretIndex, text));
            wpfControls.textBox.EmulateChangeCaretIndex(initialCaretIndex + text.Length);
        });

        /// <summary>
        /// VOICEROID2がテキスト or フレーズの読み上げを実行中かどうか
        /// </summary>
        public bool IsPlaying => TimedFunc(() => {
            try {
                return wpfControls.statusBarItem.Text == "テキストを読み上げています。" || wpfControls.statusBarItem.Text == "フレーズを読み上げています。";
            } catch {
                return false;
            }
        });

        /// <summary>
        /// フレーズタブで現在表示されているフレーズ文字列
        /// </summary>
        public string CurrentPhrase => TimedFunc(() => {
            return wpfControls.phraseField.Text;
        });

        /// <summary>
        /// 文字列がVOICEROID2のメインウィンドウタイトルとして妥当かどうか調べます。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool CheckIfIsValidWindowTitle(string str) {
            if (str == null) {
                return false;
            }
            return Regex.IsMatch(str, "^VOICEROID2.*$", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 指定パスにあるフレーズ辞書を現在使用されているフレーズ辞書に統合します。
        /// 統合は後勝ちで実行されます。
        /// </summary>
        /// <param name="srcPdicPath"></param>
        public void MergePdicToCurrent(string srcPdicPath) {
            Async async = new Async();
            Async async1 = new Async();
            WPFMenuItem mi = new WPFMenuItem(rootControl.LogicalTree().ByType<MenuItem>().ByBinding("OptionsCommand").Single());
            mi.EmulateClick(async);
            WindowControl settingsWindow = rootControl.WaitForNextModal();
            WPFButtonBase mergePhraseDicButton = new WPFButtonBase(settingsWindow.LogicalTree().ByType<Button>().ByBinding("MergePhraseDicCommand").Single());
            mergePhraseDicButton.EmulateClick(async1);
            WindowControl selectDialog = rootControl.WaitForNextModal();
            MergeFile(selectDialog, srcPdicPath);

            WindowControl resultDialog = settingsWindow.WaitForNextModal().WaitForNextModal();
            new NativeButton(resultDialog.IdentifyFromWindowText("OK")).EmulateClick();
            new WPFButtonBase(settingsWindow.LogicalTree().ByType<Button>().ByBinding("OkCommand").Single()).EmulateClick();
            async1.WaitForCompletion();
            async.WaitForCompletion();
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        private void MergeFile(WindowControl fileDialog, string path) {
            var buttonOpen = new NativeButton(fileDialog.IdentifyFromWindowText("開く(&O)"));

            var comboBoxMergeOrderSrc = fileDialog.GetFromWindowClass("ComboBox").OrderBy(e =>
            {
                RECT rc;
                GetWindowRect(e.Handle, out rc);
                return rc.Top;
            }).Last();
            var comboBoxMergeOrder = new NativeComboBox(comboBoxMergeOrderSrc);
            comboBoxMergeOrder.EmulateSelectItem(1);


            var editPathSrc = fileDialog.GetFromWindowClass("Edit").OrderBy(e =>
            {
                RECT rc;
                GetWindowRect(e.Handle, out rc);
                return rc.Left;
            }).Last();
            var editPath = new NativeEdit(editPathSrc);

            editPath.EmulateChangeText(path);

            buttonOpen.EmulateClick();
        }

        private WindowsAppFriend app;
        private WindowControl rootControl;
        private WPFControls wpfControls;

        /// <summary>
        /// メインウィンドウのコントロールをまとめたクラス
        /// </summary>
        private class WPFControls {
            public WPFControls(WindowControl rootControl) {
                textBox = new WPFTextBox(rootControl.IdentifyFromLogicalTreeIndex(0, 4, 3, 5, 3, 0, 2));
                phraseField = new WPFTextBox(rootControl.GetFromTypeFullName("AI.Talk.Editor.PhraseEditView").Single().LogicalTree().ByType<TextBox>().Single());
                statusBarItem = new WPFTextBlock(rootControl.IdentifyFromVisualTreeIndex(0, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0));

            }

            public WPFTextBox textBox;
            public WPFTextBox phraseField;
            public WPFTextBlock statusBarItem;
        }

    }

}
