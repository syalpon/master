/// <summary>
/// �t�B�[���h�̏���ێ�����N���X
/// </summary>
class Field
{
    /*�t�B�[���h*/
    private FieldAccessType _accessType;
    private FieldDataType _dataType;
    private string  _fieldName;

    /// <summary>
    /// �R���X�g���N�^
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
    /// �t�B�[���h�̃A�N�Z�X�C���q���擾����
    /// </summary>
    /// <returns></returns>
    public FieldAccessType GetAccessType()
    {
        return _accessType;
    }

    /// <summary>
    /// �t�B�[���h�̌^���擾����
    /// </summary>
    /// <returns></returns>
    public FieldDataType GetDataType()
    {
        return _dataType;
    }

    /// <summary>
    /// �t�B�[���h�̖��O���擾����
    /// </summary>
    /// <returns></returns>
    public string GetFieldName()
    {
        return _fieldName;
    }


    /*-----------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    /// �N���X�}�쐬�p
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
