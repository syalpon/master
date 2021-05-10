/// <summary>
/// フィールドの情報を保持するクラス
/// </summary>
class Field
{
    /*フィールド*/
    private FieldAccessType _accessType;
    private FieldDataType _dataType;
    private string  _fieldName;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="accessType"></param>
    /// <param name="dataType"></param>
    /// <param name="fieldName"></param>
    public Field (FieldAccessType accessType, FieldDataType dataType, string fieldName)
    {
        _accessType = accessType;
        _dataType   = dataType;
        _fieldName  = fieldName;
    }

    /// <summary>
    /// フィールドのアクセス修飾子を取得する
    /// </summary>
    /// <returns></returns>
    public FieldAccessType GetAccessType()
    {
        return _accessType;
    }

    /// <summary>
    /// フィールドの型を取得する
    /// </summary>
    /// <returns></returns>
    public FieldDataType GetDataType()
    {
        return _dataType;
    }

    /// <summary>
    /// フィールドの名前を取得する
    /// </summary>
    /// <returns></returns>
    public string GetFieldName()
    {
        return _fieldName;
    }


    /*-----------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    /// クラス図作成用
    /// </summary>
    public FieldAccessType FieldAccessType
    {
        get => default;
        set
        {
        }
    }

    public FieldDataType FieldDataType
    {
        get => default;
        set
        {
        }
    }

}
