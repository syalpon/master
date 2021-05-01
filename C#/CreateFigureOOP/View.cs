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

        foreach(Field field in c.GetFieldList())
        {
            // 追加したフィールドのアクセス修飾子
            this.Show(" " + symbol[Enum.GetName(typeof(FieldAccessType), field.GetAccessType())] + " ") ;
            
            // 追加したフィールド名
            this.Show(field.GetFieldName() + " : ");

            // 追加したフィールドの型
            this.Show(Enum.GetName(typeof(FieldDataType), field.GetDataType()) + "\n");

        }

        this.Show("----------------\n");
        
        foreach(Method method in c.GetMethodList())
        {
            // 追加したメソッドのアクセス修飾子
            this.Show(" " + symbol[Enum.GetName(typeof(MethodAccessType), method.GetAccessType())] + " ");

            // 追加したメソッドの名前
            this.Show(method.GetMethodName() + "(" );

            // 追加したメソッドの引数一覧
            var listLength =  method.GetArgumentTypeList().Count();
            for(int i = 0 ; i < listLength - 1 ; i++ ){
                this.Show( Enum.GetName(typeof(MethodArgumentType), method.GetArgumentTypeList()[i]) + ",");
            }
            this.Show( Enum.GetName(typeof(MethodArgumentType), method.GetArgumentTypeList()[listLength - 1]));
            this.Show( ") : ");

            // 追加したメソッドの戻り値の型
            this.Show(Enum.GetName(typeof(MethodDataType), method.GetDataType()) + "\n");
        }

    }

    /// <summary>
    /// フィールドが追加されたときの表示
    /// </summary>
    /// <param name="c"></param>
    public void AddFieldShow(string makingClassName, Field field)
    {
        this.Show(makingClassName + " に ");
        var accessType = Enum.GetName(typeof(FieldAccessType), field.GetAccessType());
        var dataType = Enum.GetName(typeof(FieldDataType), field.GetDataType());
        this.Show(accessType+ " " + dataType + " " + field.GetFieldName() + " が追加されました\n\n");
    }

    /// <summary>
    /// メソッドが追加されたときの表示
    /// </summary>
    /// <param name="method"></param>
    public void AddMethodShow(string makingClassName, Method method)
    {
        this.Show( makingClassName + " に ");
        var accessType = Enum.GetName(typeof(MethodAccessType), method.GetAccessType());
        var dataType = Enum.GetName(typeof(MethodDataType), method.GetDataType());
        this.Show(accessType+ " " + dataType + " " + method.GetMethodName() +  "(" );
        var listLength =  method.GetArgumentTypeList().Count();
        for(int i = 0 ; i < listLength - 1 ; i++ ){
            this.Show( Enum.GetName(typeof(MethodArgumentType), method.GetArgumentTypeList()[i]) + ",");
        }
        this.Show( Enum.GetName(typeof(MethodArgumentType), method.GetArgumentTypeList()[listLength - 1]));
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
    /// <param name="stringList">1から順番に表示する文字列</param>
    /// <returns> 選択肢番号 </returns>
    public int SelectNumberWithExit(string[] stringList)
    {   
        var index = 1;
        foreach(string messages in stringList)
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
