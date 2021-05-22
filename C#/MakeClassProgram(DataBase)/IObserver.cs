using System.Collections.Generic;

namespace MakeClassProgram_DataBase_
{
    interface IObserver
    {
        void Update(Field field);
        void Update(Method method);
    }
}