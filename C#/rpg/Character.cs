namespace RPG{
	class Character : Status{
		
		/*コンストラクタ*/
		public Character(string name):base(name){}
		public Character():this("Unknown"){}
		
		public void Atk(Character c){
			System.Console.Write("{0}が{1}に攻撃\n",name,c.name);
			System.Console.Write("{0}はダメージを受けた({1}→{2})\n",c.name,c.hp.now,System.Math.Max(c.hp.min,c.hp.now-atc.now));
			c.hp.now -= atc.now;
			
			if( c.IsDead(c) ){
				System.Console.WriteLine("{0}は経験値を得た({1}→{2})",name,exp.now,exp.now+120);
				exp.now += 120;
			}
		}
		
		public bool IsDead(Character c){
			if( c.hp.now <= c.hp.min){
				return true;
			}
			return false;
		}
		
		public void Die(){
			System.Console.WriteLine("{0}は死んだ",this.name);
		}
	}
}	
