/// <summary>
/// モデルの中でもフィールドのみを扱う処理群クラス
/// </summary>
class FieldModel : Model
{
    /// <summary>
    /// アクセス修飾子の選択肢を返す
    /// </summary>
    /// <returns></returns>
    public string[] GetFieldAccessorSelection()
    {
        return GetSelection<FieldAccessType>();
    }

    /// <summary>
    /// 型の選択肢を返す
    /// </summary>
    /// <returns></returns>
    public string[] GetFieldTypeSelection()
    {
        return GetSelection<FieldDataType>();
    }

    /// <summary>
    /// 「フィールド名を選択してください。」を返す
    /// </summary>
    /// <returns></returns>
    public string GetInputFieldName()
    {
        return "フィールド名を入力してください。\n>";
    }

    /// <summary>
    /// フィールドを生成する
    /// </summary>
    /// <param name="accessTypeSelectNumber">アクセス修飾子</param>
    /// <param name="dataTypeSelectNumber">型</param>
    /// <param name="fieldName">フィールド名</param>
    /// <returns>フィールド</returns>
    public Field CreateField(int accessTypeSelectNumber, int dataTypeSelectNumber, string fieldName)
    {
        return new Field( (FieldAccessType)accessTypeSelectNumber, (FieldDataType)dataTypeSelectNumber, fieldName);
    }
}