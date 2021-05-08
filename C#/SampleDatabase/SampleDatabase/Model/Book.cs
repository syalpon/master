using System;
using System.Collections.Generic;
using System.Text;

namespace SampleDatabase.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PublishedYear { get; set; }

        // エンティティクラスの中でほかのエンティティクラスをプロパティにもつ場合
        // virtualを指定する必要がある。なぜかはわからん
        public virtual Author Author { get; set; }
    }
}
