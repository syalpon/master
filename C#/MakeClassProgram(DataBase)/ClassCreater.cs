using System.Collections.Generic;
using System.Linq;

/// <summary>
/// �쐬�����N���X�Q��ێ�����N���X
/// </summary>
class ClassCreater
{
    /*�t�B�[���h*/
    private Class _class;
 
    /// <summary>
    /// �N���X�Ƀt�B�[���h��ǉ�����
    /// </summary>
    /// <param name="field"></param>
    public void SetFieldToClass(Field field)
    {
        _class.AddField(field);
    }

    /// <summary>
    /// �N���X�Ƀ��\�b�h��ǉ�����
    /// </summary>
    /// <param name="field"></param>
    public void SetMethodToClass(Method method)
    {
        _class.AddMethod(method);
    }

    /// <summary>
    /// �o�^���Ă���N���X�l�[�����擾����
    /// </summary>
    /// <returns></returns>
    public string GetTheLastAddedClassName()
    {
        return _class.GetClassName();
    }


    /// <summary>
    /// �쐬���̃N���X���擾����
    /// </summary>
    /// <returns></returns>
    public Class GetMakingClass()
    {
        return _class;
    }




    /*-----------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    /// �N���X�}�쐬�p
    /// </summary>
    internal Field Field
    {
        get => default;
        set
        {
        }
    }

    internal Method Method
    {
        get => default;
        set
        {
        }
    }
}