using System;
namespace RPG
{
	class main
	{
		static void Main()
		{
			/*インスタンス化*/
			Brave brave = new Brave();
			Monster	monster	= new Monster("怪物");

			/*処理*/
			//brave.status.Show();
			//brave.Atk(monster);
			//monster.Atk(brave);
			//brave.Atk(monster);
			//brave.status.Show();

			//void FUNC(string s){ Console.WriteLine(s); }
			Action <string> show = s=>Console.WriteLine(s);
			show(brave.Name);
			show(monster.Name);
        }
	}
}	
