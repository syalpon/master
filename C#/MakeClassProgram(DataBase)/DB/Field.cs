using System;

class Field
{
    /*フィールド*/
    private FieldAccessType _accessType;
    private FieldDataType _dataType;
    private string  _fieldName;

    /*プロパティ*/
    public int FieldId { get; set; }
    public FieldAccessType AccessType
    {
        get { return  _accessType; } 
        set { _accessType = value; }
    }
    public FieldDataType DataType
    {
        get { return _dataType; }
        set { _dataType = value; }
    }
    public string FieldName
    {
        get { return _fieldName; }
        set { _fieldName = value; }
    }
    public virtual Class Class { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="accessType"></param>
    /// <param name="dataType"></param>
    /// <param name="fieldName"></param>
    public Field (FieldAccessType accessType, FieldDataType dataType, string fieldName)
    {
        _accessType = accessType;
        _dataType  = dataType;
        _fieldName = fieldName;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public FieldAccessType GetAccessType()
    {
        return _accessType;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public FieldDataType GetDataType()
    {
        return _dataType;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string GetFieldName()
    {
        return _fieldName;
    }
}
