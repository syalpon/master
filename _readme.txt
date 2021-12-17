使い方
⓪init.batをダブルクリックで立ち上げる
①csc position.csでコンパイル
②position.exeをダブルクリックで立ち上げる
③position.exeからクリックしたい座標3か所をメモる。
④続いてcsc click.csコマンドを実行しコンパイル
⑤CLIから
>click.exe [ループ回数] [1回目X座標] [1回目Y座標] [2回目X座標] [2回目Y座標] [3回目X座標] [3回目Y座標] 
として実行
➅放置する。

※クリック速度はclick.csの115,123,131行目で調整可能