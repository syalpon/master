using System.Collections.Generic;

class ClassModel : Model
{
    /*プロパティ*/
    public string _className { get; set; }

    internal Class Class
    {
        get => default;
        set
        {
        }
    }

    /// <summary>
    /// クラス生成メソッド
    /// </summary>
    /// <param name="className"></param>
    /// <returns></returns>
    public Class CreateClass(string className, List<Field> fieldList, List<Method> methodList)
    {
        return new Class(className, fieldList, methodList);
    }
}

