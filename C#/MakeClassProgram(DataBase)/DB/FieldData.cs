using System;

/// <summary>
/// フィールドデータをデータベースに保存する形式に変換し保持するクラス
/// </summary>
class FieldData
{
    /*プロパティ*/
    public int Id { get; set; }
    public string AccessType { get; set; }
    public string DataType { get; set; }
    public string FieldName { get; set; }
    public virtual ClassData ClassData { get; set; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="field"></param>
    public FieldData(Field field)
    {
        //Fieldからデータ変換
        AccessType = Enum.GetName(typeof(FieldAccessType), field.GetAccessType());
        DataType = Enum.GetName(typeof(FieldDataType), field.GetDataType());
        FieldName = field.GetFieldName();
    }



}

