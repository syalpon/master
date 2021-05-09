using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Argument
{
    /*フィールド*/
    private MethodArgumentType _methodArgumentType;

    public MethodArgumentType GetMethodArgumentType()
    {
        return _methodArgumentType;
    }

    public Argument(MethodArgumentType methodArgumentType)
    {
        _methodArgumentType = methodArgumentType;
    }
}

