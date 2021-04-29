using System;
using System.Collections.Generic;
using System.Collections;

class View 
{
    /*コンストラクタ*/
    public View()
    {

    }

    /// <summary>
    /// 文字列を出力する
    /// </summary>
    /// <param name="msg">出力する文字列</param>
    public void Show(string msg)
    {
        System.Console.Write(msg);
    }


    public void AddClassShow(ClassCreater c)
    {
        this.Show(c.GetClassName());
        //System.Console.Write(c.GetFieldName()); TODO
        this.Show("クラスが追加されました\n");
    }

    public void AddFieldShow(ClassCreater c)
    {
        var f = c.GetField();
        this.Show(c.GetClassName() + " に ");
        string accessType = Enum.GetName(typeof(AccessType), f.GetAccessType());
        string dataType = Enum.GetName(typeof(DataType), f.GetDataType());
        this.Show(accessType+ " " + dataType + " " + f.GetFieldName() + " が追加されました\n\n");
    }

    /// <summary>
    /// ユーザからの入力を受け取る
    /// </summary>
    /// <returns></returns>
    public string GetMessege()
    {
        return System.Console.ReadLine();
    }

    /// <summary>
    /// 選択肢(1,2,3,...ParamNum-1,0)を表示して選択された選択肢番号を返す
    /// </summary>
    /// <param name="stringlist">1から順番に表示する文字列</param>
    /// <returns> 選択肢番号 </returns>
    public int SelectNumberWithExit(params string[] stringlist)
    {   
        int index = 1;
        foreach(string messages in stringlist)
        {
            System.Console.Write(index + "."+ messages + " 　" );
            index++;
        }
        System.Console.Write("0.終了\n>");

        return int.Parse(this.GetMessege());

    }
}
