using System;
using System.Collections.Generic;
using System.Collections;

class Model
{
    ClassCreater _classCreater;

    ClassCreater ClassCreater
    {
        get => default;
        set
        {
        }
    }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public Model()
    {
        _classCreater = new ClassCreater();
    }

    /// <summary>
    /// クラスの追加(インスタンス化)
    /// </summary>
    /// <param name="msg"></param>
    public void CreateNewClass(string classname)
    {
        _classCreater.CreateNewClass(classname);
    }

    /// <summary>
    /// クラスの決定通知
    /// </summary>
    public void FinishedCreateClass()
    {
        _classCreater.FinishedCreateClass();
    }

    /// <summary>
    /// 作成中のクラスを取得する
    /// </summary>
    /// <returns></returns>
    public Class GetNowClass()
    {
        return _classCreater.GetNowClass();
    }

    /// <summary>
    /// クラスを取得する
    /// </summary>
    /// <returns></returns>
    public Class GetClass()
    {
        return _classCreater.GetClass();
    }


    /// <summary>
    /// 「クラス図を作成をします。(Escキーで終了)」を返す
    /// </summary>
    /// <returns></returns>
    public string GetFirstContext()
    {
       return  "クラス図を作成をします。(入力なしで終了)\n";
    }

    /// <summary>
    /// フィールドとメソッドの選択肢を返す
    /// </summary>
    /// <returns></returns>
    public string[] GetFieldAndMethodSelection()
    {
        string[] choices = {"フィールド", "メソッド"};
        return choices;
    }

    /// <summary>
    /// アクセス修飾子の選択肢を返す
    /// </summary>
    /// <returns></returns>
    public string[] GetAccessorSelection()
    {
        string[] choices = {"private", "protected", "public"};
        return choices;
    }

    /// <summary>
    /// 型の選択肢を返す
    /// </summary>
    /// <returns></returns>
    public string[] GetFieldTypeSelection()
    {
        string[] choices = {"int", "double", "string"};
        return choices;
    }

    /// <summary>
    /// 型の選択肢を返す
    /// </summary>
    /// <returns></returns>
    public string[] GetArgumentTypeSelection()
    {
        string[] choices = {"int", "double", "string"};
        return choices;
    }


    /// <summary>
    /// 型の選択肢を返す
    /// </summary>
    /// <returns></returns>
    public string[] GetMethodTypeSelection()
    {
        string[] choices = {"void","int", "double", "string"};
        return choices;
    }



    /// <summary>
    /// 「描画したいクラス名を入力してください。」を返す
    /// </summary>
    /// <returns></returns>
    public string GetClassNameContext()
    {
        return "描画したいクラス名を入力してください。\n";
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
    /// 「フィールド名を選択してください。」を返す
    /// </summary>
    /// <returns></returns>
    public string GetInputFieldName()
    {
        return "フィールド名を入力してください。\n>";
    }

    /// <summary>
    /// 「引数の個数を入力してください」の表示
    /// </summary>
    /// <returns></returns>
    public string GetInputArgumentNumber()
    {
        return "引数の個数を入力してください。\n>";
    }

    /// <summary>
    /// 「引数の型を入力してください」の表示
    /// </summary>
    /// <returns></returns>
    public string GetInputArgumentType()
    {
        return "引数の型を入力してください。\n";
    }

    /// <summary>
    /// 決定したフィールドを追加する
    /// </summary>
    /// <param name="accessType"></param>
    /// <param name="dataType"></param>
    /// <param name="fieldName"></param>
    public void AddField(FieldAccessType accessType, FieldDataType dataType, string fieldName)
    {
        _classCreater.SetFieldToClass(
            new Field(
                accessType,
                dataType,
                fieldName
            )
        );
    }

    public void AddMethod(MethodAccessType accessType, MethodDataType dataType, string methodName,List<MethodArgumentType> methodArgumentList )
    {
        _classCreater.SetMethodToClass(
            new Method(
                accessType,
                dataType,
                methodName,
                methodArgumentList
            )
        );
    }


}

