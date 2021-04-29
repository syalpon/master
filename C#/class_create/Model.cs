using System;
using System.Collections.Generic;
using System.Collections;

class Model
{
    ClassCreater _classCreater;
    
    /// <summary>
    /// クラスの追加(インスタンス化)
    /// </summary>
    /// <param name="msg"></param>
    public void AddClass(string classname)
    {
        _classCreater = new ClassCreater(classname);
    }

    public ClassCreater GetClassInstans()
    {
        return _classCreater;
    }

    /// <summary>
    /// 「クラス図を作成をします。(Escキーで終了)」を返す
    /// </summary>
    /// <returns></returns>
    public string GetFirstContext()
    {
       return  "クラス図を作成をします。(入力なしで終了)\n";
    }

    /// <summary>
    /// 「描画したいクラス名を入力してください。」を返す
    /// </summary>
    /// <returns></returns>
    public string GetClassNameContext()
    {
        return "描画したいクラス名を入力してください。\n";
    }

    /// <summary>
    /// 「アクセス修飾子を入力してください。」を返す
    /// </summary>
    /// <returns></returns>
    public string GetInputAccessor()
    {
        return "アクセス修飾子を入力してください。\n1.public  2.protected  3.private\n>";
    }

    /// <summary>
    /// 「型名を選択してください。」を返す
    /// </summary>
    /// <returns></returns>
    public string GetInputType()
    {
        return "型名を選択してください。\n1.int  2.double  3.string\n>";
    }

    /// <summary>
    /// 「フィールド名を選択してください。」を返す
    /// </summary>
    /// <returns></returns>
    public string GetInputFieldName()
    {
        return "フィールド名を入力してください。\n>";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="accessType"></param>
    /// <param name="dataType"></param>
    /// <param name="fieldName"></param>
    public void AddField(AccessType accessType, DataType dataType, string fieldName)
    {
        _classCreater.AddField(
            new Field(
                accessType,
                dataType,
                fieldName
            )
        );
    }
    
    public ClassCreater GetField()
    {
        return _classCreater;
    }

}

