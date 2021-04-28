namespace RPG{
	/*キャラクタークラスはステータスをインスタンスに持つ*/
	class Character{
		/*プロパティ*/
		public string name{get;private set;}
		public Status status{get;private set;}

		/*コンストラクタ*/
		public Character(string Name="Unknown"){
			name = Name;
			status = new Status();
		}

		
	}
}	
