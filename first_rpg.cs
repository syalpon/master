namespace main_frame{

	class Initializer{
		public static void Main(){
			Character player1 = new Character();
			player1.show();
			//player1.exp += 500;
			//player1.show();
			//player1.level += 1;
			//player1.damage = 10;
			//player1.show();
			Map map1 = new Map();
			//map1.show();
			
		}
	}
	
	class Character{
		/* フィールド */
		private string 	_name;
		private int 	_age;
		private int 	_level;
		private int		_exp;
		private	int		_max_hp;
		private	int		_hp;
		private	int		_min_hp;
		private	int		_max_mp;
		private	int 	_mp;
		private	int 	_min_mp;
		private int 	_location_x;
		private int 	_location_y;
		
		/* 経験値プロパティー */
		public int exp{
			set{ 
				_exp += value;
				for( /*nothing*/ ; _exp >= 100 ; _exp -= 100 ){
					level += 1;
				}
			}
			get{return _exp;}
		}
		/* レベルアッププロパティ */
		public int level{
			set{ 
				/* 受け取ったレベルまでレベルアップ */
				for(int i = _level; i < value ; i++ ){
					_level++;
					_max_hp += 5;
					_hp = _max_hp;
					_max_mp += 10;
					_mp = _max_mp;
				}
			}
			get{ return _level; }
		}
		/* HPプロパティ */
		public int hp{
			set{
				if( value == _min_hp ){
					System.Console.WriteLine( ">>死んだ<<" );
					/* TODO gameover() */
				}else{
					_hp = value;
				}	
			}
			get{return _hp;}
		}
		
		
		/* ダメージプロパティ */
		public int damage{
			set{
				System.Console.WriteLine( value + "のダメージを受けた!");
				if( value >= _hp ){
					hp = _min_hp;
				}else{
					hp -= value; 
				}
			}
			get{return 0;}
		}
		
		/* コンストラクタ */
		public Character(){
			_name 	= "hogehoge";
			_age	= 20;
			_level	= 1;
			_max_hp	= 10;
			_hp 	= _max_hp;
			_min_hp = 0;
			_max_mp	= 50;
			_mp 	= _max_mp;
			_min_mp = 0;
		 	_location_x = 0;
		 	_location_y = 0;
		}
		
		public void show(){
			System.Console.WriteLine("------------------------------------");
			System.Console.WriteLine("名前 : " + _name );
			System.Console.WriteLine("年齢 : " + _age  );
			System.Console.WriteLine("level: " + _level );
			System.Console.WriteLine("体力 : " + _hp +"/" + _max_hp );
			System.Console.WriteLine("魔力 : " + _mp +"/" + _max_mp );
			System.Console.WriteLine("------------------------------------");
		}
	}
	
	class Map{
		private int _x_size;
		private int _y_size;
		
		
		/* コンストラクタ */
		public Map(){
			_x_size = 20;
			_y_size = 10;
		}
		
		public void show(){
			for(int j = 0 ; j<_y_size ; j++){
				for(int i = 0 ; i<_x_size ; i++){
					System.Console.Write("□");
				}
				System.Console.Write("\n");
			}
			System.Console.Write("\n");
		}
	}
}


