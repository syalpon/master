using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

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

    /// <summary>
    /// 追加されたクラスの表示
    /// </summary>
    /// <param name="c"></param>
    public void AddClassShow(Class c)
    {
        var symbol = new Dictionary<string, string>()
        {
            {"Public","+"},
            {"Protected","#"},
            {"Private","-"},
            {"Internal","~"}
        };

        this.Show(c.GetClassName());        
        this.Show("\n----------------\n");

        foreach(Field f in c.GetFieldList())
        {
            // 追加したフィールドのアクセス修飾子
            this.Show(" " + symbol[Enum.GetName(typeof(FieldAccessType), f.GetAccessType())] + " ") ;
            
            // 追加したフィールド名
            this.Show(f.GetFieldName() + " : ");

            // 追加したフィールドの型
            this.Show(Enum.GetName(typeof(FieldDataType), f.GetDataType()) + "\n");

        }

        this.Show("----------------\n");
        
        foreach(Method m in c.GetMethodList())
        {
            // 追加したメソッドのアクセス修飾子
            this.Show(" " + symbol[Enum.GetName(typeof(MethodAccessType), m.GetAccessType())] + " ");

            // 追加したメソッドの名前
            this.Show(m.GetMethodName() + "(" );

            // 追加したメソッドの引数一覧
            var listLength =  m.GetArgumentTypeList().Count();
            for(int i = 0 ; i < listLength - 1 ; i++ ){
                this.Show( Enum.GetName(typeof(MethodArgumentType), m.GetArgumentTypeList()[i]) + ",");
            }
            this.Show( Enum.GetName(typeof(MethodArgumentType), m.GetArgumentTypeList()[listLength - 1]));
            this.Show( ") : ");

            // 追加したメソッドの戻り値の型
            this.Show(Enum.GetName(typeof(MethodDataType), m.GetDataType()) + "\n");
        }

    }

    /// <summary>
    /// フィールドが追加されたときの表示
    /// </summary>
    /// <param name="c"></param>
    public void AddFieldShow(Class c)
    {
        var f = c.GetField();
        this.Show(c.GetClassName() + " に ");
        var accessType = Enum.GetName(typeof(FieldAccessType), f.GetAccessType());
        var dataType = Enum.GetName(typeof(FieldDataType), f.GetDataType());
        this.Show(accessType+ " " + dataType + " " + f.GetFieldName() + " が追加されました\n\n");
    }

    /// <summary>
    /// メソッドが追加されたときの表示
    /// </summary>
    /// <param name="c"></param>
    public void AddMethodShow(Class c)
    {
        var m = c.GetMethod();
        this.Show(c.GetClassName() + " に ");
        var accessType = Enum.GetName(typeof(MethodAccessType), m.GetAccessType());
        var dataType = Enum.GetName(typeof(MethodDataType), m.GetDataType());
        this.Show(accessType+ " " + dataType + " " + m.GetMethodName() +  "(" );
        var listLength =  m.GetArgumentTypeList().Count();
        for(int i = 0 ; i < listLength - 1 ; i++ ){
            this.Show( Enum.GetName(typeof(MethodArgumentType), m.GetArgumentTypeList()[i]) + ",");
        }
        this.Show( Enum.GetName(typeof(MethodArgumentType), m.GetArgumentTypeList()[listLength - 1]));
        this.Show( ")" + " が追加されました\n\n");
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
    public int SelectNumberWithExit(string[] stringlist)
    {   
        var index = 1;
        foreach(string messages in stringlist)
        {
            System.Console.Write(index + "."+ messages + " 　" );
            index++;
        }
        System.Console.Write("0.終了\n>");

        return int.Parse(this.GetMessege());

    }

    /// <summary>
    /// 選択肢(1,2,3,...ParamNum)を表示して選択された選択肢番号を返す
    /// </summary>
    /// <param name="stringlist">1から順番に表示する文字列</param>
    /// <returns> 選択肢番号 </returns>
    public int SelectNumber(string[] stringlist)
    {   
        int index = 1;
        foreach(string messages in stringlist)
        {
            System.Console.Write(index + "."+ messages + " 　" );
            index++;
        }
        System.Console.Write("\n>");

        return int.Parse(this.GetMessege());

    }

}
