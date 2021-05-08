using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

class Class
{
    /*フィールド*/
    private string _className;
    List<Field> _fieldList;
    List<Method> _methodList;

    /*プロパティ*/
    public int ClassId { get; set; }
    public string ClassName{
        get { return _className; }
        set { _className = value; }
    }
    public virtual ICollection<Field> FieldList
    {
        get { return _fieldList; }
        set { _fieldList = (List<Field>)value; }
    }
    public virtual ICollection<Method> MethodList 
    {
        get { return _methodList; }
        set { _methodList = (List<Method>)value; }
    }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="className"></param>
    public Class(string className)
    {
        _className = className;
        _fieldList  = new List<Field>();
        _methodList = new List<Method>(); 
    }

    /// <summary>
    /// Fieldを追加するメソッド
    /// </summary>
    /// <param name="field"></param>
    public void AddField(Field field)
    {
        _fieldList.Add(field);
    }

    /// <summary>
    /// Methodを追加するメソッド
    /// </summary>
    /// <param name="method"></param>
    public void AddMethod(Method method)
    {
        _methodList.Add(method);
    }

    /// <summary>
    /// クラスネームの取得
    /// </summary>
    /// <returns></returns>
    public string GetClassName()
    {
        return _className;
    }

    /// <summary>
    /// 最新で追加したフィールドを取得する
    /// </summary>
    /// <returns></returns>
    public Field GetField()
    {
        return _fieldList.Last();
    }

    /// <summary>
    /// 最新で追加したメソッドを取得する
    /// </summary>
    /// <returns></returns>
    public Method GetMethod()
    {
        return _methodList.Last();
    }


    /// <summary>
    /// リスト全体を返す
    /// </summary>
    /// <returns></returns>
    public List<Field> GetFieldList()
    {
        return _fieldList;
    }


    public List<Method> GetMethodList()
    {
        return _methodList;
    }
}