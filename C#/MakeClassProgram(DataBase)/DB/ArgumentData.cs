using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ArgumentData
{
    /*プロパティ*/
    public int Id { get; set; }

    public string MethodArgumentType { get; set; }


    public ArgumentData(Argument argument)
    {
        MethodArgumentType = Enum.GetName(typeof(MethodArgumentType), argument.GetMethodArgumentType());
    }
}

