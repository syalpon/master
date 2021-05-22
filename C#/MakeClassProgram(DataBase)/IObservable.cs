using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeClassProgram_DataBase_
{
    interface IObservable
    {
        void RegisterObserver(IObserver observer);
    }
}
