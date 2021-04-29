class Field
{
    private AccessType _accessType;
    private DataType _dataType;
    private string  _fieldName;

    public Field (AccessType accessType, DataType dataType, string fieldName)
    {
        _accessType = accessType;
        _dataType  = dataType;
        _fieldName = fieldName;
    }

    public AccessType GetAccessType()
    {
        return _accessType;
    }

    public DataType GetDataType()
    {
        return _dataType;
    }

    public string GetFieldName()
    {
        return _fieldName;
    }
}
