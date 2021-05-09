using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ClassData
{
    /*プロパティ*/
    public int Id { get; set; }
    public string ClassName { get; set; }
    public virtual ICollection<FieldData> FieldList { get; set; }
    public virtual ICollection<MethodData> MethodList { get; set; }

    public ClassData(Class c) 
    {
        ClassName  = c.GetClassName();
        
        // フィールドをDB用のデータに変換して保持
        var fieldlist = new List<FieldData>();
        foreach (Field field in c.GetFieldList()) 
        {
            fieldlist.Add(new FieldData(field));
        }
        FieldList  = fieldlist;

        // メソッドをDB用のデータに変換して保持
        var methodlist = new List<MethodData>();
        foreach (Method method in c.GetMethodList())
        {
            methodlist.Add(new MethodData(method));
        }
        MethodList = methodlist;

    }

}

