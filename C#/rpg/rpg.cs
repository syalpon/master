namespace RPG{
	class main{
		static void Main(){
			/*インスタンス化*/
			Brave brave = new Brave();
			Monster	monster	= new Monster();

			/*処理*/
			brave.status.Show();
			brave.Atk(monster);
			monster.Atk(brave);
			brave.Atk(monster);
			brave.status.Show();

            /* Hero : Character とする */
            /*アップキャスト*/
            Character character =  new Brave();

            Character character1;

            /*ダウンキャスト*/
            ((Brave)character1).Atk(monster);
        }
	}
}	
