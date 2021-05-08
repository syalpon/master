using System;
using System.Collections.Generic;
using System.Collections;

class Method
{
    /*フィールド*/
    private List<MethodArgumentType> _argumentTypeList;
    private MethodAccessType _accessType;
    private MethodDataType _dataType;
    private string _methodName;

    /*プロパティ*/
    public int MethodId { get; set; }
    public List<MethodArgumentType> ArgumentTypeList 
    {
        get { return _argumentTypeList; }
        set { _argumentTypeList = value; }
    }
    public MethodAccessType AccessType
    {
        get { return _accessType; }
        set { _accessType = value; }
    }
    public MethodDataType DataType
    {
        get { return _dataType; }
        set { _dataType = value; }
    }
    public string MethodName
    {
        get { return _methodName; }
        set { _methodName = value; }
    }
    public virtual Class Class {get;set;}


    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="accessType"></param>
    /// <param name="dataType"></param>
    /// <param name="methodName"></param>
    /// <param name="argumentType"></param>
    public Method(MethodAccessType accessType, MethodDataType dataType, string methodName, List<MethodArgumentType> argumentTypeList)
    {
        _accessType   = accessType;
        _dataType     = dataType;
        _methodName   = methodName;
        _argumentTypeList = argumentTypeList;
    }

    /// <summary>
    /// メソッド名前を取得
    /// </summary>
    /// <returns></returns>
    public string GetMethodName()
    {
        return _methodName;
    }

    /// <summary>
    /// メソッドのアクセス修飾子の取得
    /// </summary>
    /// <returns></returns>
    public MethodAccessType GetAccessType()
    {
        return _accessType;
    }

    /// <summary>
    /// メソッドの返値型を取得
    /// </summary>
    /// <returns></returns>
    public MethodDataType GetDataType()
    {
        return  _dataType;
    }

    /// <summary>
    /// 引数を返す
    /// </summary>
    /// <returns></returns>
    public List<MethodArgumentType> GetArgumentTypeList()
    {
        return _argumentTypeList;
    }

}
