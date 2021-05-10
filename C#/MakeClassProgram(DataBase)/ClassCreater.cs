using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 作成したクラス群を保持するクラス
/// </summary>
class ClassCreater
{
    /*フィールド*/
    private Class _class;
    private List<Class> _classList;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="classname"></param>
    public ClassCreater()
    {
        _classList = new List<Class>();
    }

    /// <summary>
    /// 新しいクラスを追加する
    /// </summary>
    /// <param name="classname"></param>
    public void CreateNewClass(string classname)
    {
        _class = new Class(classname);
    }

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
    /// インスタンスのクラスリストに作成完了したクラスを保存する
    /// </summary>
    public void SaveTheCreatedClass()
    {
        _classList.Add(_class);
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
    /// 最新の追加されたクラスを取得する
    /// </summary>
    /// <returns></returns>
    public Class GetLastAddedClass()
    {
        return _classList.Last();
    }

    /// <summary>
    /// 作成中のクラスを取得する
    /// </summary>
    /// <returns></returns>
    public Class GetMakingClass()
    {
        return _class;
    }

    /// <summary>
    /// 作成した全てのクラスを返す
    /// </summary>
    /// <returns></returns>
    public List<Class> GetAllClass()
    {
        return _classList;
    }

    /// <summary>
    /// 作成した全てのクラス名を返す
    /// </summary>
    /// <returns></returns>
    public List<string> GetAllClassName()
    {
        var nameList = new List<string>();
        foreach(Class c in _classList)
        {
            nameList.Add(c.GetClassName());
        }
        return nameList;
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

    internal Class Class
    {
        get => default;
        set
        {
        }
    }
}