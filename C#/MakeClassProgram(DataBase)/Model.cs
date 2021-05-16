

class Model
{ 
    /// <summary>
    /// 「クラス図を作成をします。(Escキーで終了)」を返す
    /// </summary>
    /// <returns></returns>
    public string GetFirstContext()
    {
        return "クラス図を作成をします。\n";
    }

    /// <summary>
    /// フィールドとメソッドの選択肢を返す
    /// </summary>
    /// <returns></returns>
    public string[] GetFieldAndMethodSelection()
    {
        string[] choices = { "フィールド", "メソッド" };
        return choices;
    }

    /// <summary>
    /// 「描画したいクラス名を入力してください。」を返す
    /// </summary>
    /// <returns></returns>
    public string GetClassNameContext()
    {
        return "描画したいクラス名を入力してください。(入力なしで終了)\n>";
    }

    /// <summary>
    /// 各モデルへのスイッチング
    /// </summary>
    /// <param name="selectNumber"></param>
    public bool Generator(int selectNumber, Class createClass)
    {
        bool flag = true;
        switch (selectNumber)
        {
            // 終了
            case 0:
                flag = false;
                break;

            // フィールド
            case 1:
                var fieldModel = new FieldModel();
                var field = fieldModel.FieldGenerationProcess();
                fieldModel.AddToClass(field, createClass);

                break;

            // メソッド
            case 2:
                var methodModel = new MethodModel();
                var method = methodModel.MethodGenerationProcess();
                methodModel.AddToClass(method, createClass);

                break;

            // その他
            default: 
                // Not Reached
                break;
        }

        return flag;
    }

    /// <summary>
    /// クラスのインスタンス化
    /// </summary>
    /// <param name="className"></param>
    /// <returns></returns>
    public Class CreateClass(string className)
    {
        var classModel = new ClassModel();
        return classModel.CreateClass(className);
    }

}

