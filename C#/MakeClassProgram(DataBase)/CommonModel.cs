using MakeClassProgram_DataBase_;
using System;
using System.Collections.Generic;

/// <summary>
/// MVCモデルにおけるM:モデル
/// </summary>
class CommonModel
{
    protected View _view;
    private List<IObserver> _observers;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public CommonModel()
    {
        _view = new View();
         _observers = new List<IObserver>();
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

   
}