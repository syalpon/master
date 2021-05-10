using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 作成するクラスのデータを保持するクラス
/// </summary>
class Class
{
    /*フィールド*/
    private string _className;
    List<Field> _fieldList;
    List<Method> _methodList;

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
    /// 追加した最新フィールドを取得する
    /// </summary>
    /// <returns></returns>
    public Field GetTheLastAddedField()
    {
        return _fieldList.Last();
    }

    /// <summary>
    /// 追加した最新のメソッドを取得する
    /// </summary>
    /// <returns></returns>
    public Method GetTheLastAddedMethod()
    {
        return _methodList.Last();
    }

    /// <summary>
    /// 作成したフィールド全てを取得する
    /// </summary>
    /// <returns></returns>
    public List<Field> GetAllFields()
    {
        return _fieldList;
    }

    /// <summary>
    /// 作成したメソッド全てを取得する
    /// </summary>
    /// <returns></returns>
    public List<Method> GetAllMethods()
    {
        return _methodList;
    }



    /*-----------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    /// クラス図作成用
    /// </summary>
    internal Field Field
    {
        get => default;
        set
        {
        }
    }

    internal Method Method
    {
        get => default;
        set
        {
        }
    }
}