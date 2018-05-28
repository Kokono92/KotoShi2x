using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace KotoShi2x {
    class PhraseNameGenerator {
        /// <summary>
        /// exVOICEの相対パスを、括弧で括った全角のフレーズ名に変換します。
        /// ただし、フレーズが途中で切れてしまうのを防ぐため、
        /// ファイル名に含まれる句点・感嘆符・疑問符は削除されます。
        /// 呼び出し側では、異なるファイルが同じフレーズ名に変換される可能性に留意してください。
        /// </summary>
        /// <param name="relPath">exVOICE参照先ディレクトリに対する音声ファイルの相対パス</param>
        /// <returns></returns>
        private static string Generate(string relPath) {

            string ret = relPath;

            ret = Regex.Replace(ret, ".wav", "", RegexOptions.IgnoreCase); // wavファイル以外は渡されない…はず
            ret = Microsoft.VisualBasic.Strings.StrConv(ret, Microsoft.VisualBasic.VbStrConv.Wide);

            // フレーズ末尾の文字を決める。
            // デフォルトは句点を使い、ファイル名末尾(番号を除く)が感嘆符or疑問符ならそれを使う
            // e.g. はい１.wav -> ［はい１］。
            // e.g. はい！２.wav -> ［はい２］！。
            string terminator = "。";
            if (Regex.IsMatch(ret,"^.*([！？])+([０-９])*$")) {
                terminator = Regex.Match(ret, "^.*([！？])([０-９])*$").Groups[1].Value;
            }

            ret = Regex.Replace(ret, "[！？。]", "", RegexOptions.IgnoreCase);
            ret = "［" + ret + "］" + terminator;
            
            return ret;
        }

        /// <summary>
        /// 指定したディレクトリ以下にあるwavファイルについて、
        /// フレーズ名をKey、指定ディレクトリに対する相対パスをValueとしたDictionaryを作成します。
        /// wavファイルの相対パスから生成したフレーズ名が重複した場合、（１）, （２）, ... のようにサフィックスを追加します。
        /// </summary>
        /// <param name="baseDirectoryPath">exVOICE参照先ディレクトリ</param>
        /// <returns></returns>
        public static Dictionary<string, string> GenerateDictionary(string baseDirectoryPath) {
            Dictionary<string, string> dict =  new Dictionary<string, string>();

            Uri baseDirectoryUri = new Uri(baseDirectoryPath + "\\");
            List<string> exVoices = Directory.EnumerateFiles(baseDirectoryPath, "*.wav", SearchOption.AllDirectories).ToList();
            foreach (string exVoice in exVoices) {
                string relPath = baseDirectoryUri.MakeRelativeUri(new Uri(exVoice)).ToString();

                string phraseName = Generate(relPath);
                if (dict.ContainsKey(phraseName)) {
                    int suffix_cnt = 1;
                    do {
                        string suffix = Microsoft.VisualBasic.Strings.StrConv("(" + suffix_cnt.ToString() + "）", Microsoft.VisualBasic.VbStrConv.Wide);
                        phraseName = phraseName.Insert(phraseName.Length - 2, suffix); // 末尾の閉じ括弧と句点/感嘆符/疑問符の分だけ2文字オフセット
                    } while (dict.ContainsKey(phraseName));
                }
                dict.Add(phraseName, relPath);
            }

            return dict;
        }


    }
}
