using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeClassProgram_DataBase_
{
    // View
    // 監視者
    class ClassHasElementDisplay : IObserver
    {
        private IObservable context;

        /* プロパティ */
        private string ClassName { get; set; }
        private List<Field> FieldList{ get; set; }
        private List<Method> MethodList { get; set; }

        public ClassHasElementDisplay(Class context)
        {
            this.context = context;
            context.RegisterObserver(this);
        }

        public void Update(string className, List<Field> fieldList, List<Method> methodList)
        {
            ClassName = className;
            Field_Diff( fieldList );
            FieldList = new List<Field>(fieldList);
            Method_Diff( methodList );  
            MethodList = new List<Method>(methodList);
            
        }

        public void Dispaly()
        {           
            System.Console.WriteLine(ClassName + " に追加されました");
        }

        private void Field_Diff(List<Field> fieldList)
        {
            if(FieldList != null)
            {
                fieldList = fieldList.Except<Field>(FieldList).ToList();
            }
            
            foreach(Field field in fieldList)
            {
                System.Console.WriteLine(ClassName + " に "+ field.GetFieldName() +"が追加されました");
            }
        }

        private void Method_Diff(List<Method> methodList)
        {
            if(MethodList != null)
            {
                methodList = methodList.Except<Method>(MethodList).ToList();
            }
            foreach(Method method in methodList)
            {
                System.Console.WriteLine(ClassName + " に "+ method.GetMethodName() +"が追加されました");
            }    
        }
        /*デバッグ*/
        public void Update(Field field)
        {
            /*フィールド更新時の表示*/
            System.Console.WriteLine(((Class)context).FieldList.Last() + " が追加されました");
        }

        public void Update(Method method)
        {
            /*フィールド更新時の表示*/
            System.Console.WriteLine(((Class)context).MethodList.Last() + " が追加されました");
        }
        
    }
}
