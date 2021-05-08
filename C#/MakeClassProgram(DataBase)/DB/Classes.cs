using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

class Classes : DbContext
{
    // コンテキストは、アプリケーションの構成ファイル (App.config または Web.config) から 'Model1' 
    // 接続文字列を使用するように構成されています。既定では、この接続文字列は LocalDb インスタンス上
    // の 'MakeClassProgram_DataBase_.DB.Model1' データベースを対象としています。 
    // 
    // 別のデータベースとデータベース プロバイダーまたはそのいずれかを対象とする場合は、
    // アプリケーション構成ファイルで 'Model1' 接続文字列を変更してください。
    public Classes()
        : base("name=Classes")
    {
    }

    public DbSet<Class> ClassDataBase { set; get; }
    public DbSet<Method> MethodDataBase { set; get; }
    public DbSet<Field> FieldDataBase { set; get; }

    // モデルに含めるエンティティ型ごとに DbSet を追加します。Code First モデルの構成および使用の
    // 詳細については、http://go.microsoft.com/fwlink/?LinkId=390109 を参照してください。

    // public virtual DbSet<MyEntity> MyEntities { get; set; }
}

//public class MyEntity
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//}
