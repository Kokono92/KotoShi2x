# KotoShi2x
ことしずく(KotoShi2x: Kotonoha Scripting Helper for Inline Integration of eX-voice) は、
VOICEROID2のエディタ上で、通常のフレーズと同様の操作によりexVOICEを再生/編集するためのツールです。
exVOICEに合わせたボイロの調声、またはボイロに合わせたexVOICEの調声が容易に行えるようにすることを目的としています。

動作のデモンストレーションとして、下記の動画をご参照ください。
動画で使用しているツールは試作段階のものであるため、リリース版とは一部挙動が異なる場合がありますが、
大まかなコンセプトを理解する助けにはなるはずです。
- https://twitter.com/Kokono92/status/995327316271104000

## 開発状況
現在リリースされている最新バージョンは「α1」です。
>α1は動作確認用のお試し版であり、不具合が残っている可能性があります（たぶん何かあります）。  
ご報告頂ければ可能な限りの不具合修正には努めますが、
万一データの破損などが生じた場合には、当方では責任を負いかねます。  
本ソフトをお試し頂ける場合、念のためVOICEROID2のフレーズ辞書やプリセットのバックアップを取るなど、あらかじめ対策を取ってくださいますようお願い致します。

本ツールへの搭載を予定している機能と、現状の実装状況は下記のとおりです。
- [x] exVOICEの挿入、再生機能
- [x] exVOICEのフレーズ登録機能
- [ ] exVOICEをVOICEROID2の出力音声に埋め込む機能
- [ ] exVOICEを調声する機能(音量、話速、高さ、抑揚)

## 導入と初期設定
1. [本リポジトリのリリース](https://github.com/Kokono92/KotoShi2x/releases/)から、最新版のアーカイブを入手してください。
1. 入手したアーカイブを、任意のディレクトリに展開してください。
1. "KotoShi2x.exe"を実行し、ことしずくを起動します。また、併せてVOICEROID2を起動します。
1. 初回、またはexVOICEのファイル構成を変更した場合は、下記の手順によりexVOICEリストの更新を行います。
    1. ことしずくのメイン画面右下にある「設定...」ボタンを押し、設定ダイアログを開きます。
    1. ダイアログ上段の入力欄に、exVOICEの参照先ディレクトリを指定します。
    1. ダイアログ中段の「作成」ボタンを押し、exVOICEのリストを作成します。
    1. ダイアログ下段の「更新実行」ボタンを押し、現在のフレーズ辞書にexVOICE用のフレーズを登録します。

以上で、ことしずくを使用するための準備は終了です。

なお、本ツールの実行には .Net Framework4.x が必要です。
お使いの環境によっては、別途インストールが必要となる場合があります。  
(https://www.microsoft.com/ja-jp/download/details.aspx?id=55170)

## 使用方法
1. VOICEROID2のエディタ上で、exVOICEを挿入したい箇所にキャレット(入力位置を示す縦棒)を移動します。
1. 挿入したいexVOICEをことしずくのリストから選択し、「exVOICE挿入」ボタンを押します。
    - リスト上の項目をダブルクリックすることでもexVOICEを挿入できます。
1. テキストを再生すると、挿入したフレーズの箇所でexVOICEが再生されます。
    - exVOICEとボイロの音声を聞き比べ、必要に応じて調声を行ってください。

## 開発環境
Windows10 Pro (64bit) + VOICEROID2 Version 2.0.4.0

## Licenses
This software is licensed under the MIT license.
This software is built using following libraries:
- Friendly.Windows, licensed under the Apache 2.0 License
- Friendly.Windows.Grasp, licensed under the Apache 2.0 License
- Friendly.Windows.NativeStandardControls, licensed under the Apache 2.0 License
- Friendly.WPFStandardControls (Modified by Kokono92), licensed under the Apache 2.0 License
	- For detail of the license, see: http://www.apache.org/licenses/LICENSE-2.0
- NAudio by Mark Heath (https://github.com/naudio/NAudio), licensed under the Microsoft Public License
