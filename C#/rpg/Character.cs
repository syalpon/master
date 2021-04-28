namespace RPG
{
	/*キャラクタークラスはステータスをインスタンスに持つ*/
	class Characte
	{

		/*フィールド*/
		private string _name = "unknwon";

		/*プロパティ*/
		public string Name 
		{ 
			private set{_name = value;}
			get{return _name;}
		}
		
		//public Status status{get;protected set;}
		
		/*コンストラクタ*/
		public Character(string name)
		{
			_name = name;
			//status = new Status();
		}
	}
}	
