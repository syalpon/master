using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 作成したクラス群を保持するクラス
/// </summary>
class ClassCreater
{
    /*フィールド*/
    private Class _class;
 
    /// <summary>
    /// クラスにフィールドを追加する
    /// </summary>
    /// <param name="field"></param>
    public void SetFieldToClass(Field field)
    {
        _class.AddField(field);
    }

    /// <summary>
    /// クラスにメソッドを追加する
    /// </summary>
    /// <param name="field"></param>
    public void SetMethodToClass(Method method)
    {
        _class.AddMethod(method);
    }

    /// <summary>
    /// 登録しているクラスネームを取得する
    /// </summary>
    /// <returns></returns>
    public string GetTheLastAddedClassName()
    {
        return _class.GetClassName();
    }


    /// <summary>
    /// 作成中のクラスを取得する
    /// </summary>
    /// <returns></returns>
    public Class GetMakingClass()
    {
        return _class;
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