using System.Collections.Generic;
using System.Linq;

/// <summary>
/// MVCモデルにおけるC:コントロール
/// </summary>
class Control
{
    /*フィールド*/
	private Model _model;
    private View _view;

    /*コンストラクタ*/
    public Control()
    {
        _model = new Model();
        _view  = new View();
    }

    /// <summary>
    /// 実行処理
    /// </summary>
    public void Run()
    {
        using (var db = new Classes())
        {
            /* クラス図を作成をします(Escキーで終了) の表示 */
            _view.Show(_model.GetFirstContext());

            while (true)
            {
                // クラス名の入力を促す
                _view.Show(_model.GetClassNameContext());

                // DBからすでに登録されているクラスネームを取得
                var existClassNameList = db.ClassDataBase.Select(row => row.ClassName).ToList<string>();

                // すでに登録されていないクラスネームであり、
                // アンダースコア(_)または大文字英字始まりの文字列もしくはエンターのみで入力を貰う
                // エンターのみの場合空文字が受け取られる
                var message = _view.GetClassNameMessege(existClassNameList) ;

                if (message == "")
                {
                    break;
                }

                /* クラスをインスタンス化してクラスネームの追加 */
                _model.CreateNewClass(message);

                // ユーザの選択した選択肢番号を宣言
                int selectNumber;

                do {
                    /* 選択肢の表示 */
                    selectNumber = _view.SelectNumberWithExit(_model.GetFieldAndMethodSelection());
                    switch (selectNumber)
                    {
                        // 終了
                        case 0:
                            break;

                        // フィールド
                        case 1:
                            // フィールドの作成
                            var createdField = FieldGenerationProcess();

                            // フィールドの追加
                            _model.SetFieldToClass(createdField);

                            // 作成したフィールドがどこに追加されたかを表示する
                            _view.AddFieldShow(_model.GetMakingClass().GetClassName(), createdField);

                            break;

                        // メソッド
                        case 2:
                            // メソッドの作成
                            var createdMethod = MethodGenerationProcess();

                            // メソッドの追加
                            _model.SetMethodToClass(createdMethod);

                            // 作成したメソッドがどこに追加されたかを表示する
                            _view.AddMethodShow(_model.GetMakingClass().GetClassName(), createdMethod);

                            break;

                        // その他
                        default: break;
                    }

                } while (selectNumber != 0);

                // 作成したクラスをインスタンスに追加
                _model.SaveTheCreatedClass();

                // 作成したクラスをDBに登録
                db.ClassDataBase.Add(new ClassData(_model.GetClass()));
                db.SaveChanges();

                // 作成したクラスを表示
                _view.ShowClass(_model.GetClass());
            }

            // 作成した全てのクラスを表示する
            _view.ShowAllClass(_model.GetAllClass());
        }
        
    }
    
    /// <summary>
    /// フィールド生成処理
    /// </summary>
    /// <returns></returns>
    private Field FieldGenerationProcess() 
    {
        // フィールドモデルのインスタンス化
        var fieldModel = _model.CreateFieldModel();

        // アクセス修飾子  => accessType
        _view.Show(fieldModel.GetInputAccessor());
        var accessTypeSelectNumber = _view.SelectNumber(fieldModel.GetFieldAccessorSelection());

        // 型　　　　　　  => dataType
        _view.Show(fieldModel.GetInputType());
        var dataTypeSelectNumber = _view.SelectNumber(fieldModel.GetFieldTypeSelection());

        // フィールド名    => fieldName
        _view.Show(fieldModel.GetInputFieldName());
        var fieldName = _view.GetMessege();

        // フィールドを生成 => createdField
        return fieldModel.CreateField(accessTypeSelectNumber, dataTypeSelectNumber, fieldName);
    }

    /// <summary>
    /// メソッド生成処理
    /// </summary>
    /// <returns></returns>
    private Method MethodGenerationProcess()
    {
        // メソッドモデルのインスタンス化
        var methodModel = _model.CreateMethodModel();

        // アクセス修飾子 => accessType
        _view.Show(methodModel.GetInputAccessor());
        var methodAccessTypeSelectNumber = _view.SelectNumber(methodModel.GetMethodAccessorSelection());

        // 型　　　　　　 => dataType
        _view.Show(methodModel.GetInputType());
        var methodDataTypeSelectNumber = _view.SelectNumber(methodModel.GetMethodDataTypeSelection());

        // メソッド名   => methodName
        _view.Show(methodModel.GetInputMethodName());
        var methodName = _view.GetMessege();

        // 引数の個数 => argmentNumber
        _view.Show(methodModel.GetInputArgumentNumber());
        var argumentNumber = int.Parse(_view.GetMessege());

        // 結果を保持するリスト
        var methodArgumentList = new List<int>();

        // 引数の型 => Listに追加していく
        for (int i = 0; i < argumentNumber; i++)
        {
            _view.Show(methodModel.GetInputArgumentType());
            methodArgumentList.Add(_view.SelectNumber(methodModel.GetArgumentTypeSelection()));
        }

        // メソッドを生成 => createdField
        return methodModel.CreateMethod(methodAccessTypeSelectNumber, methodDataTypeSelectNumber, methodName, methodArgumentList);
    }


    /*-----------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    /// クラス図作成用
    /// </summary>
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

    internal Classes Classes
    {
        get => default;
        set
        {
        }
    }
}
