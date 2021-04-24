namespace RPG{
	class LV : Param {
		/*コンストラクタ*/
		public LV(){}
		public LV(int x):base(x,x,0){}
		public LV(int x,int y):base(x,x,y){}
		public LV(int x,int y,int z):base(x,y,z){}
		
		/*レベルアップ処理*/
		public void LevelUp(int old){
			int old_hp;
			rc.lv.now++;
			rc.hp.max += 5;
			old_hp = rc.hp.now;
			rc.hp.now = rc.hp.max;
			rc.atc.now += 10;
			System.Console.WriteLine("{0}はレベルアップした({1}→{2})",rc.name,rc.lv.now-1,rc.lv.now);
			System.Console.WriteLine("{0}のステータスが上がった",rc.name);
			System.Console.WriteLine("HP :{0}→{1}",rc.hp.now-5,rc.hp.now);
			System.Console.WriteLine("ATC:{0}→{1}",rc.atc.now-10,rc.atc.now);
			System.Console.WriteLine("EXP:{0}→{1}",old,rc.exp.now);
			System.Console.WriteLine("LV :{0}→{1}",rc.lv.now-1,rc.lv.now);
		}
	}
}	
