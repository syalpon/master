using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

class ClassCreater
{
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
    /// クラス作成完了時処理。リストに完成したクラスを保存する
    /// </summary>
    public void FinishedCreateClass()
    {
        _classList.Add( _class );
    }

    /// <summary>
    /// 登録しているクラスネームを取得する
    /// </summary>
    /// <returns></returns>
    public string GetClassName()
    {
        return _class.GetClassName();
    }

    /// <summary>
    /// 最新の追加されたクラスを取得する
    /// </summary>
    /// <returns></returns>
    public Class GetClass()
    {
        return _classList.Last();
    }

    /// <summary>
    /// 作成中のクラスを取得する
    /// </summary>
    /// <returns></returns>
    public Class GetNowClass()
    {
        return _class;
    }



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