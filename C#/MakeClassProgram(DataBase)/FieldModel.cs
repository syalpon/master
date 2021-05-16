/// <summary>
/// モデルの中でもフィールドのみを扱う処理群クラス
/// </summary>
class FieldModel : CommonModel
{
    internal Field Field
    {
        get => default;
        set
        {
        }
    }

    /// <summary>
    /// アクセス修飾子の選択肢を返す
    /// </summary>
    /// <returns></returns>
    private string[] GetFieldAccessorSelection()
    {
        return GetSelection<FieldAccessType>();
    }

    /// <summary>
    /// 型の選択肢を返す
    /// </summary>
    /// <returns></returns>
    private string[] GetFieldTypeSelection()
    {
        return GetSelection<FieldDataType>();
    }

    /// <summary>
    /// 「フィールド名を選択してください。」を返す
    /// </summary>
    /// <returns></returns>
    private string GetInputFieldName()
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

    /// <summary>
    /// フィールド生成処理
    /// </summary>
    /// <returns></returns>
    public Field FieldGenerationProcess()
    {
        // アクセス修飾子  => accessType
        _view.Show(this.GetInputAccessor());
        var accessTypeSelectNumber = _view.SelectNumber(this.GetFieldAccessorSelection());

        // 型　　　　　　  => dataType
        _view.Show(this.GetInputType());
        var dataTypeSelectNumber = _view.SelectNumber(this.GetFieldTypeSelection());

        // フィールド名    => fieldName
        _view.Show(this.GetInputFieldName());
        var fieldName = _view.GetMessege();

        // フィールドを生成 => createdField
        return this.CreateField(accessTypeSelectNumber, dataTypeSelectNumber, fieldName);
    }

    /// <summary>
    /// クラスにフィードを追加する処理
    /// </summary>
    /// <param name="field"></param>
    /// <param name="c"></param>
    public void AddToClass(Field field,Class c)
    {
        c.FieldList.Add(field);
    }
}