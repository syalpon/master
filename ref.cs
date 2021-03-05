namespace main_frame{
	
	class Initializer{
		/* 参照型練習 */
		public static void Main(){
			int a = 10;
			int b = 20;
			System.Console.WriteLine("変更前");
			System.Console.WriteLine("a:" + a);
			System.Console.WriteLine("b:" + b);
			
			f(a);
			g(ref b);
			
			System.Console.WriteLine("変更後");
			System.Console.WriteLine("a:" + a);
			System.Console.WriteLine("b:" + b);
		}
		
		public static void f(int x){
			x = 50;
		}
		
		public static void g(ref int y){
			y = 200;
		}
	}
}


