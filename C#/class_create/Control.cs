//アクセス修飾子
public enum AccessType
{
    Private   = 1,
    Protected = 2,
    Public    = 3
}

// 値型
public enum DataType
{
    Int = 1,
    String = 2,
    Double = 3
}

class Control
{
    //[System.Runtime.InteropServices.DllImport("user32.dll")]
    //private static extern short GetKeyState(int nVirtKey);
	private Model _model;
    private View _view;

    /*コンストラクタ*/
    public Control()
    {
        _model = new Model();
        _view  = new View();
    }

    public void Run()
    {
        // ユーザの入力
        string message;

        // 選択肢番号
        int selectNumber;

        // アクセス修飾子を受けとる変数
        AccessType accessType;

        // 型を受け取る変数
        DataType dataType;


        /* クラス図を作成をします(Escキーで終了) の表示 */
        _view.Show(_model.GetFirstContext());
        while(true)
        {
            // クラス名の入力を促す
            _view.Show(_model.GetClassNameContext());
            message = _view.GetMessege();
             
            if( message.CompareTo("") == 0 )
            {
                break;
            }

            else if( !('A' <= message[0] && message[0] <= 'Z') )
            {
                // 大文字英字始まりでなければ再度取得させる 
                // TODO : ERROR messege show
                continue;
            }
            
            /* クラスをインスタンス化してクラスネームの追加 */
            _model.AddClass(message);

            do{
                /* 選択肢の表示 */
                selectNumber = _view.SelectNumberWithExit("フィールド", "メソッド");
                switch(selectNumber)
                {
                    // 終了
                    case 0 :
                        break;

                    // フィールド
                    case 1 :
                        // アクセス修飾子 => accessType
                        _view.Show(_model.GetInputAccessor());
                        accessType = (AccessType)int.Parse(_view.GetMessege());

                        // 型　　　　　　 => dataType
                        _view.Show(_model.GetInputType());
                        dataType = (DataType)int.Parse(_view.GetMessege());

                        // フィールド名   => messege
                        _view.Show(_model.GetInputFieldName());
                        message = _view.GetMessege();

                        //フィールドの追加
                        _model.AddField(accessType,dataType,message);
                        _view.AddFieldShow(_model.GetField());
                        
                    break;

                    // メソッド
                    case 2 :
                        //TODO:
                    break;

                    default : break;
                }
            }while(selectNumber != 0);

            /*作成したクラスを表示*/
            _view.AddClassShow( _model.GetClassInstans() );
        }



    }


}
