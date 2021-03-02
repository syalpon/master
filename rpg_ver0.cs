using System.Collections.Generic;

namespace main_frame{
	
	class Initializer{
		/* メイン関数 */
		public static void Main(){
			Character player1 = new Character();
			player1.name = "player1";
			player1.show();
			player1.exp += 500;
			player1.show();
			player1.level += 1;
			player1.damage = 10;
			player1.show();
			Map map1 = new Map();
			map1.add_char(player1,10,20);
			map1.show_char_list();
		}
	}
	
	class Character{
		/* フィールド */
		private string 	_name;
		private int 	_age;
		private int 	_level;
		private int 	_exp;
		private	int 	_max_hp;
		private	int 	_hp;
		private	int 	_min_hp;
		private	int 	_max_mp;
		private	int 	_mp;
		private	int 	_min_mp;
		
		/* 名前プロパティ */
		public string name{
			set{ _name = value; }
			get{ return _name; }
		}
		
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
		
		/* 魔法プロパティ */
		public int use_magic{
			set{
				if( value > _mp ){
					_mp = _min_mp;
				}else{
					_mp -= value;
				}
			}
			get{return _mp;}
		}
		
		/* コンストラクタ */
		public Character(){
			_name 	= "player";
			_age	= 20;
			_level	= 1;
			_max_hp	= 10;
			_hp 	= _max_hp;
			_min_hp = 0;
			_max_mp	= 50;
			_mp 	= _max_mp;
			_min_mp = 0;
		}
		
		/* ステータス表示 */
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
	
	/* 二次元ベクトル */
	struct Vector{
		public int x;
		public int y;
	}
	
	class Map{
		/* map size */
		private Vector _Size;
		
		/* マップにいるキャラリスト */
		private Dictionary <Character ,Vector> _List;
		
		/* コンストラクタ */
		public Map(){
			_Size = new Vector(){ x=1 , y=1 };
			_List = new Dictionary <Character ,Vector>();
		}
		
		/* キャラ情報追加 : 座標なし */
		public void add_char(Character c){
			add_char( c , 0 , 0 );
		}
		
		/* キャラ情報追加 : 座標あり */
		public void add_char(Character c , int X , int Y ){
			_List.Add( c , new Vector{ x=X , y=Y } );
		}
		
		/* マップ表示 */
		public void show(){
			for( int j = 0 ; j< _Size.y ; j++ ){
				for( int i = 0 ; i< _Size.x ; i++ ){
					System.Console.Write("□");
				}
				System.Console.Write("\n");
			}
			System.Console.Write("\n");
		}
		
		/* キャラリスト表示 */
		public void show_char_list(){
			foreach( KeyValuePair<Character , Vector> item in _List){
				System.Console.WriteLine("[ {0} : (x,y) = ({1},{2})]", item.Key.name , item.Value.x , item.Value.y );
			}
		}
	}
}


