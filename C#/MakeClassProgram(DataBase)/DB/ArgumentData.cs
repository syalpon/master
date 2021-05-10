using System;


/// <summary>
/// メソッドの引数の型データをデータベースに保存する形式に変換し保持するクラス
/// </summary>
class ArgumentData
{
    /*プロパティ*/
    public int Id { get; set; }
    public string MethodArgumentType { get; set; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="argument"></param>
    public ArgumentData(Argument argument)
    {
        MethodArgumentType = Enum.GetName(typeof(MethodArgumentType), argument.GetMethodArgumentType());
    }


}

