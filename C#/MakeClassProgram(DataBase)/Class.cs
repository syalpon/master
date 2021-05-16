using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 作成するクラスのデータを保持するクラス
/// </summary>
class Class
{
    /*プロパティ*/
    public string ClassName { get;  set; }
    public List<Field> FieldList  { get; set; }
    public List<Method> MethodList { get;  set; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="className"></param>
    public Class(string className)
    {
        ClassName = className;
        FieldList = new List<Field>();
        MethodList = new List<Method>(); 
    }
}