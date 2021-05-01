using System.Collections.Generic;

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

    /// <summary>
    /// 実行
    /// </summary>
    public void Run()
    {
        int selectNumber;
        /* クラス図を作成をします(Escキーで終了) の表示 */
        _view.Show(_model.GetFirstContext());
        while(true)
        {
            // クラス名の入力を促す
            _view.Show(_model.GetClassNameContext());
            var message = _view.GetMessege();
             
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
            _model.CreateNewClass(message);

            do{
                /* 選択肢の表示 */
                selectNumber = _view.SelectNumberWithExit(_model.GetFieldAndMethodSelection());
                switch (selectNumber)
                {
                    // 終了
                    case 0:
                        break;

                    // フィールド
                    case 1:
                        // _modelを拡張した分身を作成
                        FieldModel fieldModel = _model.CreateFieldModel();

                        // アクセス修飾子 => accessType
                        _view.Show(fieldModel.GetInputAccessor());
                        var fieldAccessType = (FieldAccessType)_view.SelectNumber(fieldModel.GetAccessorSelection());

                        // 型　　　　　　 => dataType
                        _view.Show(fieldModel.GetInputType());
                        var dataType = (FieldDataType)_view.SelectNumber(fieldModel.GetFieldTypeSelection());

                        // フィールド名   => fieldName
                        _view.Show(fieldModel.GetInputFieldName());
                        var fieldName = _view.GetMessege();

                        // フィールドの追加
                        //fieldModel.AddField(fieldAccessType, dataType, fieldName);
                        _model.SetFieldToClass(fieldModel.CreateField(fieldAccessType, dataType, fieldName));
                        _view.AddFieldShow(_model.GetNowClass());

                        break;

                    // メソッド
                    case 2:
                        MethodModel methodModel = _model.CreateMethodModel();

                        // アクセス修飾子 => accessType
                        _view.Show(methodModel.GetInputAccessor());
                        var methodAccessType = (MethodAccessType)_view.SelectNumber(methodModel.GetAccessorSelection());

                        // 型　　　　　　 => dataType
                        _view.Show(methodModel.GetInputType());
                        var methodDataType = (MethodDataType)_view.SelectNumber(methodModel.GetMethodTypeSelection());

                        // メソッド名   => methodName
                        _view.Show(methodModel.GetInputMethodName());
                        var methodName = _view.GetMessege();

                        // 引数の個数 => argmentNumber
                        _view.Show(methodModel.GetInputArgumentNumber());
                        var argmentNumber = int.Parse(_view.GetMessege());
                        
                        // 結果を保持するリスト
                        var methodArgumentList = new List<MethodArgumentType>();

                        // 引数の型 => Listに追加していく
                        for (int i = 0; i < argmentNumber; i++ ) 
                        { 
                            _view.Show(methodModel.GetInputArgumentType());
                            methodArgumentList.Add(
                                (MethodArgumentType)_view.SelectNumber(methodModel.GetArgumentTypeSelection())
                            );  
                        }

                        // メソッドの追加
                        //methodModel.AddMethod(methodAccessType, methodDataType, methodName, methodArgumentList);
                        _model.SetMethodToClass(methodModel.CreateMethod(methodAccessType, methodDataType, methodName, methodArgumentList));
                        _view.AddMethodShow(_model.GetNowClass());

                        break;

                    default : break;
                }

            }while(selectNumber != 0);

            /*作成したクラスを表示*/
            _model.FinishedCreateClass();
            _view.AddClassShow( _model.GetClass() );
        }
    }
    







    internal View View
    {
        get => default;
        set
        {
        }
    }

    internal Model Model
    {
        get => default;
        set
        {
        }
    }
}
