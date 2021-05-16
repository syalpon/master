using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// モデルの中でもメソッドを扱う処理群クラス
/// </summary>
class MethodModel : CommonModel
{
    internal Method Method
    {
        get => default;
        set
        {
        }
    }

    /// <summary>
    /// アクセス修飾子の選択肢を返す
    /// </summary>
    /// <returns></returns>
    private string[] GetMethodAccessorSelection()
    {
        return GetSelection<MethodAccessType>();
    }

    /// <summary>
    /// 型の選択肢を返す
    /// </summary>
    /// <returns></returns>
    private string[] GetMethodDataTypeSelection()
    {
        return GetSelection<MethodDataType>();
    }

    /// <summary>
    /// 引数の選択肢を返す
    /// </summary>
    /// <returns></returns>
    private string[] GetArgumentTypeSelection()
    {
        return GetSelection<MethodArgumentType>();
    }

    /// <summary>
    /// 「引数の個数を入力してください」の表示
    /// </summary>
    /// <returns>string </returns>
    public string GetInputArgumentNumber()
    {
        return "引数の個数を入力してください。\n>";
    }

    /// <summary>
    /// 「メソッド名を選択してください。」を返す
    /// </summary>
    /// <returns></returns>
    public string GetInputMethodName()
    {
        return "メソッド名を入力してください。\n>";
    }

    /// <summary>
    /// 「引数の型を入力してください」の表示
    /// </summary>
    /// <returns>string</returns>
    public string GetInputArgumentType()
    {
        return "引数の型を入力してください。\n";
    }

    /// <summary>
    /// メソッドを生成する
    /// </summary>
    /// <param name="accessTypeSelectNumber">アクセス修飾子</param>
    /// <param name="methodDataTypeSelectNumber">メソッドの戻り値の型</param>
    /// <param name="methodName">メソッド名</param>
    /// <param name="methodArgumentListSelectNumbers">メソッド引数</param>
    /// <returns>メソッド<returns>
    public Method CreateMethod(int accessTypeSelectNumber, int methodDataTypeSelectNumber, string methodName, List<int> methodArgumentListSelectNumbers)
    {
        // List<MethodArgumentType>からList<Argument>へ変換
        var methodArgumentList = new  List<Argument>();
        foreach (int methodArgumentListSelectNumber in methodArgumentListSelectNumbers)
        {
            var argument = new Argument((MethodArgumentType)methodArgumentListSelectNumber);
            methodArgumentList.Add(argument);
        }

        // メソッドクラスのインスタンス生成
        return new Method((MethodAccessType)accessTypeSelectNumber, (MethodDataType) methodDataTypeSelectNumber, methodName, methodArgumentList);
    }

    /// <summary>
    /// メソッド生成処理
    /// </summary>
    /// <returns></returns>
    public Method MethodGenerationProcess()
    {
        // アクセス修飾子 => accessType
        View.Display(this.GetInputAccessor());
        var methodAccessTypeSelectNumber = _view.SelectNumber(this.GetMethodAccessorSelection());

        // 型　　　　　　 => dataType
        View.Display(this.GetInputType());
        var methodDataTypeSelectNumber = _view.SelectNumber(this.GetMethodDataTypeSelection());

        // メソッド名   => methodName
        View.Display(this.GetInputMethodName());
        var methodName = _view.GetMessege();

        // 引数の個数 => argmentNumber
        View.Display(this.GetInputArgumentNumber());
        var argumentNumber = int.Parse(_view.GetMessege());

        // 結果を保持するリスト
        var methodArgumentList = new List<int>();

        // 引数の型 => Listに追加していく
        for (int i = 0; i < argumentNumber; i++)
        {
            View.Display(this.GetInputArgumentType());
            methodArgumentList.Add(_view.SelectNumber(this.GetArgumentTypeSelection()));
        }

        // メソッドを生成 => createdField
        return this.CreateMethod(methodAccessTypeSelectNumber, methodDataTypeSelectNumber, methodName, methodArgumentList);
    }

    /// <summary>
    /// クラスにメソッドを追加する処理
    /// </summary>
    /// <param name="field"></param>
    /// <param name="c"></param>
    public void AddToClass(Method field,Class c)
    {
        c.MethodList.Add(field);
    }
}
