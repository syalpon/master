using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 引数の型データを扱うクラス
/// </summary>
class Argument
{
    /* フィールド */
    private MethodArgumentType _methodArgumentType;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="methodArgumentType"></param>
    public Argument(MethodArgumentType methodArgumentType)
    {
        _methodArgumentType = methodArgumentType;
    }

    /// <summary>
    /// フィールドの値を取得するメソッド
    /// </summary>
    /// <returns></returns>
    public MethodArgumentType GetMethodArgumentType()
    {
        return _methodArgumentType;
    }



    /*-----------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    /// クラス図作成用
    /// </summary>
    public MethodArgumentType MethodArgumentType
    {
        get => default;
        set
        {
        }
    }
}

