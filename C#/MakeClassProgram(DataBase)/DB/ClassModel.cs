using System.Collections.Generic;

class ClassModel : CommonModel
{
    /// <summary>
    /// クラス生成メソッド
    /// </summary>
    /// <param name="className"></param>
    /// <returns></returns>
    public Class CreateClass(string className)
    {
        return new Class(className);
    }




    /*-----------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    /// クラス図作成用
    /// </summary>
    internal Class Class
    {
        get => default;
        set
        {
        }
    }
}

