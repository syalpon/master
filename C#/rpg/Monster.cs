namespace RPG{
	class Monster{
		/*フィールド*/
		public Character character;
		
		/*コンストラクタ*/
		public Monster(){
			character = new Character("モンスター");
			character.atc.now = 30;
			character.hp.Reference(ref character);
			character.atc.Reference(ref character);
			character.exp.Reference(ref character);
			character.lv.Reference(ref character);
		}
		
	}
}	
