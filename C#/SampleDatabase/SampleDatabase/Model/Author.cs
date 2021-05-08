using System;
using System.Collections.Generic;

namespace SampleDatabase.Model
{
    public class Author
    {
        // ＊　主キーの指定　＊
        // Entity Frameworkでは"Id"という名前のプロパティ、
        // またはクラス名と"Id"を組み合わせた名前のプロパティを主キーとして扱う

        // 主キーとはデータベースの中からそのオブジェクトを一意に識別できる項目のこと
        // このId列にはIDENTITY属性が付与され、行が追加されるごとに列の値が自動採番される。

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }

        // AuthorクラスにはICollection<Book>プロパティを作成する
        // 著者からその著者が書いた書籍情報にアクセスできるようにする
        public virtual ICollection<Book> Books { get; set; }
    }
}