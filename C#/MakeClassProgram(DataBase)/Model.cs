using System;
using System.Collections.Generic;

/// <summary>
/// MVCモデルにおけるM:モデル
/// </summary>
class Model
{
    /*フィールド*/
    //protected ClassCreater _classCreater;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public Model()
    {
        //_classCreater = new ClassCreater();
    }

    /// <summary>
    /// クラスの追加(インスタンス化)
    /// </summary>
    /// <param name="msg"></param>
    public void CreateNewClass(string className)
    {
        //ClassCreater.CreateNewClass(className);
    }

    /// <summary>
    /// 作成したクラスをclassCreaterのインスタンスに追加
    /// </summary>
    public void SaveTheCreatedClass()
    {
        //_classCreater.SaveTheCreatedClass();
    }

    /// <summary>
    /// ジェネリックで各Enumの文字列を取得する
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    protected string[] GetSelection<T>()
    {
        string[] choices = new string[Enum.GetNames(typeof(T)).Length];
        foreach (int Value in Enum.GetValues(typeof(T)))
        {
            string name = Enum.GetName(typeof(T), Value);
            choices[Value - 1] = name;
        }
        return choices;
    }

    /// <summary>
    /// 「クラス図を作成をします。(Escキーで終了)」を返す
    /// </summary>
    /// <returns></returns>
    public string GetFirstContext()
    {
        return "クラス図を作成をします。\n";
    }

    /// <summary>
    /// フィールドとメソッドの選択肢を返す
    /// </summary>
    /// <returns></returns>
    public string[] GetFieldAndMethodSelection()
    {
        string[] choices = { "フィールド", "メソッド" };
        return choices;
    }

    /// <summary>
    /// 「描画したいクラス名を入力してください。」を返す
    /// </summary>
    /// <returns></returns>
    public string GetClassNameContext()
    {
        return "描画したいクラス名を入力してください。(入力なしで終了)\n>";
    }

    /// <summary>
    /// 「アクセス修飾子を入力してください。」を返す
    /// </summary>
    /// <returns></returns>
    public string GetInputAccessor()
    {
        return "アクセス修飾子を入力してください。\n";
    }

    /// <summary>
    /// 「型名を選択してください。」を返す
    /// </summary>
    /// <returns></returns>
    public string GetInputType()
    {
        return "型名を選択してください。\n";
    }

    /// <summary>
    /// フィールドモデルのインスタンス化
    /// </summary>
    /// <returns></returns>
    public FieldModel CreateFieldModel()
    {
        return new FieldModel();
    }

    /// <summary>
    /// メソッドモデルのインスタンス化
    /// </summary>
    /// <returns></returns>
    public MethodModel CreateMethodModel()
    {
        return new MethodModel();

    }
}