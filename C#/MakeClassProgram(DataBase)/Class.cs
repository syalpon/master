using MakeClassProgram_DataBase_;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 作成するクラスのデータを保持するクラス
/// </summary>
class Class : IObservable
{
    List<IObserver> _observers;

    /*プロパティ*/
    public string ClassName { get;  set; }
    public List<Field> FieldList { get; set; }
    public List<Method> MethodList { get; set; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="className"></param>
    public Class(string className)
    {
        ClassName  = className;
        FieldList  = new List<Field>();
        MethodList = new List<Method>(); 
        _observers = new List<IObserver>();
    }

    public void RegisterObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void NotifyObservers()
    {
        /*dummy*/
    }

    private void FieldNotifyObservers()
    {
        if(_observers != null)
        {
            foreach(IObserver observer in _observers)
            {
                observer.Update(FieldList.Last());
            }
        }
    }

    private void MethodNotifyObservers()
    {
        if(_observers != null)
        {
            foreach(IObserver observer in _observers)
            {
                observer.Update(MethodList.Last());
            }
        }
    }


    internal void AddMethodList(Method method)
    {
        MethodList.Add(method);
        MethodNotifyObservers();
    }

    internal void AddFieldList(Field field)
    {
        FieldList.Add(field);
        FieldNotifyObservers();
    }
}