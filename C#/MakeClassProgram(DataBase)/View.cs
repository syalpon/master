using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// MVCモデルにおけるV:View
/// </summary>
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
    /// ユーザからの入力を受け取る
    /// </summary>
    /// <returns></returns>
    public string GetMessege()
    {
        return System.Console.ReadLine();
    }

    /// <summary>
    /// 数値のみの入力を受け取る
    /// </summary>
    /// <param name="min">受け取る値の最小値</param>
    /// <param name="max">受け取る値の最大値</param>
    /// <returns></returns>
    public int GetNumberOnly(int min,int max)
    {
        string msg = "";
        int returnValue;
        while(true)
        {
            msg = System.Console.ReadLine();   
            if (msg != "" && msg.All(char.IsDigit) == true)
            {
                returnValue = int.Parse(msg);
                if (min <= returnValue && returnValue <= max)
                {
                    break;
                }
                else
                {
                    Show("選択肢内の範囲を指定してください\n>");
                }
            }
            else
            {
                Show("数値で入力してください\n>");
            }
        }

        return returnValue;
    }


    /// <summary>
    /// クラス名を入力してもらう際の入力
    /// </summary>
    /// <returns></returns>
    public string GetClassNameMessege(List<string> classNameList)
    {
        string msg;
        while (true) 
        {
            msg = this.GetMessege();

            if ( (msg=="") || ('A' <= msg[0] && msg[0] <= 'Z') || msg[0] == '_')
            {
                // クラス名重複チェック
                if( classNameList.Contains(msg) == true)
                {
                    this.Show(msg + "というクラス名はすでに使われています\n>");
                    continue;
                }
                               
                break;
            }

            else
            {
                this.Show("クラス名は大文字英字または_を先頭文字にしてください\n>");
            }
        }

        return msg;
    }


    /// <summary>
    /// 追加されたクラスの表示
    /// </summary>
    /// <param name="c"></param>
    public void ShowClass(Class c)
    {
        var symbol = new Dictionary<string, string>()
        {
            {"Public"    ,"+"},
            {"Protected" ,"#"},
            {"Private"   ,"-"},
            {"Internal"  ,"~"}
        };

        this.Show(c.GetClassName());        
        this.Show("\n----------------\n");

        foreach(Field field in c.GetAllFields())
        {
            // 追加したフィールドのアクセス修飾子
            this.Show(" " + symbol[Enum.GetName(typeof(FieldAccessType), field.GetAccessType())] + " ") ;
            
            // 追加したフィールド名
            this.Show(field.GetFieldName() + " : ");

            // 追加したフィールドの型
            this.Show(Enum.GetName(typeof(FieldDataType), field.GetDataType()) + "\n");

        }

        this.Show("----------------\n");

        foreach (Method method in c.GetAllMethods())
        {
            // 追加したメソッドのアクセス修飾子
            this.Show(" " + symbol[Enum.GetName(typeof(MethodAccessType), method.GetAccessType())] + " ");

            // 追加したメソッドの名前
            this.Show(method.GetMethodName() + "(");

            // 追加したメソッドの引数一覧
            var listLength = method.GetArgumentTypeList().Count();
            for (int i = 0; i < listLength - 1; i++)
            {
                this.Show(Enum.GetName(typeof(MethodArgumentType), (method.GetArgumentTypeList()[i]).GetMethodArgumentType()) + ",");
            }
            if (listLength != 0) 
            {
                this.Show(Enum.GetName(typeof(MethodArgumentType), (method.GetArgumentTypeList()[listLength - 1]).GetMethodArgumentType()));
            }
            this.Show( ") : ");

            // 追加したメソッドの戻り値の型
            this.Show(Enum.GetName(typeof(MethodDataType), method.GetDataType()) + "\n");
        }
        this.Show("----------------\n\n");

    }

    /// <summary>
    /// 引数の全てのクラスを表示する
    /// </summary>
    /// <param name="listClass"></param>
    public void ShowAllClass(List<Class> listClass)
    {
        foreach(Class c in listClass)
        {
            ShowClass(c);
        }

    }

    /// <summary>
    /// フィールドが追加されたときの表示
    /// </summary>
    /// <param name="c"></param>
    public void AddFieldShow(string makingClassName, Field field)
    {
        // Enum定義から逆参照しアクセス修飾子を文字列に変換する
        var accessType = Enum.GetName(typeof(FieldAccessType), field.GetAccessType());

        // Enum定義から逆参照しデータ型を文字列に変換する
        var dataType   = Enum.GetName(typeof(FieldDataType)  , field.GetDataType());

        // フィールド名を文字列として取得する。
        var fieldName  = field.GetFieldName();

        // 表示する
        this.Show( makingClassName + " に " + accessType + " " + dataType + " " + fieldName + " が追加されました\n\n");
    }

    /// <summary>
    /// メソッドが追加されたときの表示
    /// </summary>
    /// <param name="method"></param>
    public void AddMethodShow(string makingClassName, Method method)
    {
        // Enum定義から逆参照しアクセス修飾子を文字列に変換する
        var accessType = Enum.GetName(typeof(MethodAccessType), method.GetAccessType());

        // Enum定義から逆参照しデータ型を文字列に変換する
        var dataType   = Enum.GetName(typeof(MethodDataType)  , method.GetDataType());

        // 表示する
        this.Show(makingClassName + " に " + accessType + " " + dataType + " " + method.GetMethodName() +  "(" );

        // 引数の表示
                        
        var listLength =  method.GetArgumentTypeList().Count();
        // カンマ区切りで表示
        for(int i = 0 ; i < listLength - 1 ; i++ ){
            this.Show( Enum.GetName(typeof(MethodArgumentType), (method.GetArgumentTypeList()[i]).GetMethodArgumentType()) + ",");
        }
        // 最後の引数はカンマなし
        if( listLength != 0) 
        {
            this.Show(Enum.GetName(typeof(MethodArgumentType), (method.GetArgumentTypeList()[listLength - 1]).GetMethodArgumentType()));
        }        

        // 表示
        this.Show( ")" + " が追加されました\n\n");
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

        return this.GetNumberOnly(0, index - 1);

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

        return this.GetNumberOnly(1, index - 1);

    }

}
