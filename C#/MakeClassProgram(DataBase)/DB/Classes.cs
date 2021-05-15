using System.Data.Entity;

/// <summary>
/// データベース登録用のクラス
/// </summary>
class Classes : DbContext
{
    /*プロパティ*/
    public DbSet<ClassData> ClassDataBase { set; get; }
    public DbSet<MethodData> MethodDataBase { set; get; }
    public DbSet<FieldData> FieldDataBase { set; get; }
    public DbSet<ArgumentData> ArgumentTypeListDataBase { set; get; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public Classes()
        : base("name=Classes")
    {
    }


}
