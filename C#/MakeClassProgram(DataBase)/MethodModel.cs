using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// モデルの中でもメソッドを扱う処理群クラス
/// </summary>
class MethodModel : Model
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
    public string[] GetMethodAccessorSelection()
    {
        return GetSelection<MethodAccessType>();
    }

    /// <summary>
    /// 型の選択肢を返す
    /// </summary>
    /// <returns></returns>
    public string[] GetMethodDataTypeSelection()
    {
        return GetSelection<MethodDataType>();
    }

    /// <summary>
    /// 引数の選択肢を返す
    /// </summary>
    /// <returns></returns>
    public string[] GetArgumentTypeSelection()
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

}
