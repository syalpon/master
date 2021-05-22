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

        public void Update(string className, List<Field> fieldList, List<Method> methodList)
        {
            ClassName = className;
            FieldList = new List<Field>(fieldList);
            MethodList = new List<Method>(methodList);

        }

        public void Dispaly()
        {
            System.Console.WriteLine(ClassName + " に追加されました");
        }

        private void Field_Diff(List<Field> fieldList)
        {
            if (FieldList != null)
            {
                fieldList = fieldList.Except<Field>(FieldList).ToList();
            }

            foreach (Field field in fieldList)
            {
                System.Console.WriteLine(ClassName + " に " + field.GetFieldName() + "が追加されました");
            }
        }

        private void Method_Diff(List<Method> methodList)
        {
            if (MethodList != null)
            {
                methodList = methodList.Except<Method>(MethodList).ToList();
            }
            foreach (Method method in methodList)
            {
                System.Console.WriteLine(ClassName + " に " + method.GetMethodName() + "が追加されました");
            }
        }
    }
}
