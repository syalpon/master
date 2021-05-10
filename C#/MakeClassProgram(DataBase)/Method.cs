using System.Collections.Generic;

/// <summary>
/// メソッドのデータを保持するクラス
/// </summary>
class Method
{
    /*フィールド*/
    private List<Argument> _argumentTypeList;
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
    public Method(MethodAccessType accessType, MethodDataType dataType, string methodName, List<Argument> argumentTypeList)
    {
        _accessType       = accessType;
        _dataType         = dataType;
        _methodName       = methodName;
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
        return _dataType;
    }

    /// <summary>
    /// 引数を返す
    /// </summary>
    /// <returns></returns>
    public List<Argument> GetArgumentTypeList()
    {
        return _argumentTypeList;
    }




    /*-----------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    /// クラス図作成用
    /// </summary>
    internal Argument Argument
    {
        get => default;
        set
        {
        }
    }

    public MethodDataType MethodDataType
    {
        get => default;
        set
        {
        }
    }

    public MethodAccessType MethodAccessType
    {
        get => default;
        set
        {
        }
    }
}
