using System;
using System.Collections.Generic;

/// <summary>
/// メソッドのデータをデータベースに保存する形式に変換し保持するクラス
/// </summary>
class MethodData
{
    /*プロパティ*/
    public int Id { get; set; }
    public virtual ICollection<ArgumentData> ArgumentTypeList { get; set; }
    public string AccessType { get; set; }
    public string DataType { get; set; }
    public string MethodName { get; set; }
    public virtual ClassData ClassData { get; set; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="method"></param>
    public MethodData(Method method)
    {
        //Methodからデータ変換
        AccessType = Enum.GetName(typeof(FieldAccessType), method.GetAccessType());
        DataType = Enum.GetName(typeof(FieldDataType), method.GetDataType());
        MethodName = method.GetMethodName();

        var argumentTypeList = new List<ArgumentData>();
        foreach (Argument argument in method.GetArgumentTypeList())
        {
            argumentTypeList.Add(new ArgumentData(argument));
        }
        ArgumentTypeList = argumentTypeList;

    }

    public MethodData() { }


}

