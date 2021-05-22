using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeClassProgram_DataBase_
{
    class ClassDisplay : IObserver
    {
        private IObservable context;

        public ClassDisplay(Class context)
        {
            this.context = context;
            context.RegisterObserver(this);
        }

        public void Update(Field field)
        {
            string className = ((Class)context).ClassName;
            /*フィールド更新時の表示*/
            System.Console.WriteLine(className + "に" + ((Class)context).FieldList.Last().GetFieldName() + " が追加されました");
        }

        public void Update(Method method)
        {
            string className = ((Class)context).ClassName;
            /*フィールド更新時の表示*/
            System.Console.WriteLine(className + "に" + ((Class)context).MethodList.Last().GetMethodName() + " が追加されました");
        }
    }
}
