class Main_Class{
	/* オブジェクト指向 */
	/* ①継承 : Inheritance */
	/*クラスを継承して使うことができる*/
	static void Main(){
		Class_A A = new Class_A();
		System.Console.WriteLine("");
		Class_B B = new Class_B();
		System.Console.WriteLine("");
		Class_C C = new Class_C();
		System.Console.WriteLine("");
		Class_D D = new Class_D();
	}
}

class Class_A{
	public Class_A(){
		System.Console.WriteLine("コンストラクタA");
	}
}

class Class_B:Class_A{
	public Class_B(){
		System.Console.WriteLine("コンストラクタB");
	}
}

class Class_C:Class_B{
	public Class_C(){
		System.Console.WriteLine("コンストラクタC");
	}
}

class Class_D:Class_C{
	public Class_D(){
		System.Console.WriteLine("コンストラクタD");
	}
}


