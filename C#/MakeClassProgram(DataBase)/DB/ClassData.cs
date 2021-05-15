using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 作成したクラスをデータベースに保存する形式に変換し保持するクラス
/// </summary>
class ClassData
{
    /*プロパティ*/
    public int Id { get; set; }
    public string ClassName { get; set; }
    public virtual ICollection<FieldData> FieldList { get; set; }
    public virtual ICollection<MethodData> MethodList { get; set; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="c"></param>
    public ClassData(Class c)
    {
        ClassName = c.GetClassName();

        // フィールドをDB用のデータに変換して保持
        var fieldlist = new List<FieldData>();
        foreach (Field field in c.GetAllFields())
        {
            fieldlist.Add(new FieldData(field));
        }
        FieldList = fieldlist;

        // メソッドをDB用のデータに変換して保持
        var methodlist = new List<MethodData>();
        foreach (Method method in c.GetAllMethods())
        {
            methodlist.Add(new MethodData(method));
        }
        MethodList = methodlist;

    }

    public ClassData() {}


}

