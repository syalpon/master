using System;
class Test{
	static public void Main(){
		string s = "test";
		Function.show(() => s );
	}
}

class Function{
	static public void show(Func<string > f){
		Console.Write(f());
	}
}
