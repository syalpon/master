using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

class ClassCreater
{
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
    /// �N���X�쐬�����������B���X�g�Ɋ��������N���X��ۑ�����
    /// </summary>
    public void FinishedCreateClass()
    {
        _classList.Add( _class );
    }

    /// <summary>
    /// �o�^���Ă���N���X�l�[�����擾����
    /// </summary>
    /// <returns></returns>
    public string GetClassName()
    {
        return _class.GetClassName();
    }

    /// <summary>
    /// �ŐV�̒ǉ����ꂽ�N���X���擾����
    /// </summary>
    /// <returns></returns>
    public Class GetClass()
    {
        return _classList.Last();
    }

    /// <summary>
    /// �쐬���̃N���X���擾����
    /// </summary>
    /// <returns></returns>
    public Class GetNowClass()
    {
        return _class;
    }



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