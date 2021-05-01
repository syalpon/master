using System;
using System.Collections.Generic;
using System.Text;


class FieldModel : Model
{
    /// <summary>
    /// 型の選択肢を返す
    /// </summary>
    /// <returns></returns>
    public string[] GetFieldTypeSelection()
    {
        string[] choices = { "int", "double", "string" };
        return choices;
    }


    /// <summary>
    /// 「フィールド名を選択してください。」を返す
    /// </summary>
    /// <returns></returns>
    public string GetInputFieldName()
    {
        return "フィールド名を入力してください。\n>";
    }
}