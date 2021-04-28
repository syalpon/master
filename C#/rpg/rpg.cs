namespace RPG{
	class main{
		static void Main(){
			/*インスタンス化*/
			Brave brave = new Brave();
			Monster	monster	= new Monster();
			
			brave.character.Show();
			/*処理*/
			brave.character.Atk(monster.character);
			monster.character.Atk(brave.character);
			brave.character.Atk(monster.character);
			
			brave.character.Show();
			
		}
	}
}	
