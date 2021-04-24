namespace RPG{
	class Brave{
		/*フィールド*/
		public Character character;
		
		/*コンストラクタ*/
		public Brave(){
			character = new Character("勇者");
			character.atc.now = 60;
			character.hp.Reference(ref character);
			character.atc.Reference(ref character);
			character.exp.Reference(ref character);
			character.lv.Reference(ref character);
		}
		
	}
}	
