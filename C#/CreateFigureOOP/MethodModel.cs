using System;
using System.Collections.Generic;
using System.Text;

class MethodModel : Model
{
    /// <summary>
    /// 型の選択肢を返す
    /// </summary>
    /// <returns></returns>
    public string[] GetMethodTypeSelection()
    {
        string[] choices = { "void", "int", "double", "string" };
        return choices;
    }

    /// <summary>
    /// 型の選択肢を返す
    /// </summary>
    /// <returns></returns>
    public string[] GetArgumentTypeSelection()
    {
        string[] choices = { "int", "double", "string" };
        return choices;
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
    /// <returns></returns>
    public string GetInputArgumentType()
    {
        return "引数の型を入力してください。\n";
    }
}
