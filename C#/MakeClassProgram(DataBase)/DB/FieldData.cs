using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
        DataType   = Enum.GetName(typeof(FieldDataType), field.GetDataType());
        FieldName  = field.GetFieldName();
    }
}

