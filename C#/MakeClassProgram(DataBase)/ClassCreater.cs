using System.Collections.Generic;
using System.Linq;

/// <summary>
/// �쐬�����N���X�Q��ێ�����N���X
/// </summary>
class ClassCreater
{
    /*�t�B�[���h*/
    private Class _class;
    private List<Class> _classList;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param name="classname"></param>
    public ClassCreater()
    {
        _classList = new List<Class>();
    }

    /// <summary>
    /// �V�����N���X��ǉ�����
    /// </summary>
    /// <param name="classname"></param>
    public void CreateNewClass(string classname)
    {
        _class = new Class(classname);
    }

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
    /// �C���X�^���X�̃N���X���X�g�ɍ쐬���������N���X��ۑ�����
    /// </summary>
    public void SaveTheCreatedClass()
    {
        _classList.Add(_class);
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
    /// �ŐV�̒ǉ����ꂽ�N���X���擾����
    /// </summary>
    /// <returns></returns>
    public Class GetLastAddedClass()
    {
        return _classList.Last();
    }

    /// <summary>
    /// �쐬���̃N���X���擾����
    /// </summary>
    /// <returns></returns>
    public Class GetMakingClass()
    {
        return _class;
    }

    /// <summary>
    /// �쐬�����S�ẴN���X��Ԃ�
    /// </summary>
    /// <returns></returns>
    public List<Class> GetAllClass()
    {
        return _classList;
    }

    /// <summary>
    /// �쐬�����S�ẴN���X����Ԃ�
    /// </summary>
    /// <returns></returns>
    public List<string> GetAllClassName()
    {
        var nameList = new List<string>();
        foreach(Class c in _classList)
        {
            nameList.Add(c.GetClassName());
        }
        return nameList;
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

    internal Class Class
    {
        get => default;
        set
        {
        }
    }
}