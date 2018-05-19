# KotoShi2x
ことしずく(KotoShi2x: Kotonoha Scripting Helper for Inline Integration of eX-voice) は、
VOICEROID2のエディタ上で、通常のフレーズと同様の操作によりexVOICEを再生/編集するためのツールです。
exVOICEに合わせたボイロの調声、またはボイロに合わせたexVOICEの調声を容易に行うことを目的としています。

## 開発状況
現在の状況は「未リリース」です。
2018/5月末にテスト版のリリースを予定しています。

本ツールへの搭載を予定している機能と、現状の実装状況は下記のとおりです。
- [x] exVOICEの挿入、再生機能
- [x] exVOICEのフレーズ登録機能
- [ ] exVOICEをVOICEROID2の出力音声に埋め込む機能
- [ ] exVOICEを調声する機能(音量、話速、高さ、抑揚)

## 導入と初期設定
1. 本リポジトリのリリースから、最新版のアーカイブを入手してください。
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