using MakeClassProgram_DataBase_;
using System.Collections.Generic;
using System.Data.Entity;
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
                var className = _view.GetClassNameMessege(existClassNameList);

                if (className == "")
                {
                    break;
                }

                var createClass = _model.CreateClass(className);

                // 監視
                new ClassHasElementDisplay(createClass);
                new ClassDisplay(createClass);

                while(true)
                {
                    bool flag = _model.Generator(_view.SelectNumberWithExit(_model.GetFieldAndMethodSelection()), createClass);
                    if (!flag)
                    {
                        break;
                    }
                }
                
                // 作成したクラスをDBに登録
                db.ClassDataBase.Add(new ClassData(createClass));
                db.SaveChanges();

                // 作成したクラスを表示
                _view.ShowClass(createClass);
            }

            // 作成済みのクラスをすべて表示
            AllShow(db);

        }

    }

    /// <summary>
    /// 全てのクラスをデータベースから表示する
    /// </summary>
    /// <param name="db"></param>
    private void AllShow(Classes db)
    {
        var classNameList = db.ClassDataBase.Select(row => row.ClassName);
        foreach (var nClass in classNameList)
        {
            // クラス名表示
            _view.Show(nClass+"\n");
            _view.Show("----------------------------------------------------------\n");

            // クラスに追加されているフィールドを検索
            foreach (var field in db.FieldDataBase.Where(row => row.ClassData.ClassName == nClass).ToList())
            {
                _view.Show($"{field.AccessType} {field.DataType} {field.FieldName}\n");
            }
            _view.Show("----------------------------------------------------------\n");

            // クラスに追加されているメソッドを検索
            foreach (var method in db.MethodDataBase.Where(row => row.ClassData.ClassName == nClass).ToList())
            {
                _view.Show($"{method.AccessType} {method.DataType} {method.MethodName}");
                _view.Show("( ");

                // メソッドの引き数を検索
                foreach (var hiki in db.ArgumentTypeListDataBase.Where(row => row.MethodData.MethodName == method.MethodName).ToList())
                {
                    _view.Show($"{hiki.MethodArgumentType} ");
                }
                _view.Show(") \n");
            }

            _view.Show("\n");
        }
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

    internal CommonModel Model
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

    internal Model Model1
    {
        get => default;
        set
        {
        }
    }
}
