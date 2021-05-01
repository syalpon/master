using System;
using System.Collections.Generic;
using System.Collections;

class Method
{
    private List<MethodArgumentType> _argumentTypeList;
    private MethodAccessType _accessType;
    private MethodDataType _dataType;
    private string _methodName;

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
