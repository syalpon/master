using System.Collections.Generic;

namespace main_frame{
	
	class Initializer{
		/* メイン関数 */
		public static void Main(){
			Character player1 = new Character();
			player1.name = "player1";
			player1.show();
			Map map1 = new Map();
			map1.add_char(player1,10,20);
			map1.show_char_list();
			map1.show();
		}
	}
	
	class Character{
		/* フィールド */
		private string 	_name;
		private int 	_age;
		private Status	_status;
		private string 	_icon;
		
		/* 名前プロパティ : name */
		public string name{
			set{ _name = value; }
			get{ return _name; }
		}
		
		/* 年齢プロパティ : age */
		public int age{
			set{ _age = value;}
			get{return _age;}
		}
		
		/* アイコンプロパティ : icon */
		public string icon{
			set{_icon = value;}
			get{return _icon;}
		}
		
		
		/* コンストラクタ */
		public Character(){
			_name 	= "player";
			_age	= 20;
			_status = new Status();
			_icon	= "〇";
		}
		
		/* ステータス表示 */
		public void show(){
			System.Console.WriteLine("------------------------------------");
			System.Console.WriteLine("名前 : " + _name );
			System.Console.WriteLine("年齢 : " + _age  );
			System.Console.WriteLine("------------------------------------");
		}
	}
	
	
	
	/* パラメータ抽象クラス（体力や魔力のゲージを表現） */
	abstract class parameter{
		private	int 	_max;
		private	int 	_now;
		private	int 	_min;
		
		/*------------- 以下コンストラクタ -------------*/
		/* デフォルトコンストラクタ */
		public parameter(){
			_max	= 100;
			_now	= 100;
			_min	= 0;
		}
		
		/* 1引数コンストラクタ */
		public parameter( int top ){
			_max	= top;
			_now	= top;
			_min	= 0;
		}
		
		/* 2引数コンストラクタ */
		public parameter( int top , int bot ){
			_max	= top;
			_now	= top;
			_min	= bot;
		}
		/* 3引数コンストラクタ */
		public parameter( int top , int mid , int bot ){
			_max	= top;
			_now	= mid;
			_min	= bot;
		}
		/*------------- 以上コンストラクタ -------------*/
		
		/* 上限プロパティ : max */
		protected int max{
			set{
				/* 最小値より大きい場合更新*/
				if( _min <= value ){
					_max = value;
				}
			}
			get{return _max;}
		}
		
		/* 現在プロパティ */
		protected int now{
			set{
				/* 現在値が最小値を下回った場合の処理 */
				if( value <= _min ){
					_Bot_Func();
				}else if( value >= _max ){
					_Top_Func();
				}else{
					_now = value;
				}	
			}
			get{return _now;}
		}
		
		/* 下限プロパティ : min */
		protected int min{
			set{
				if( _max >= value ){
					_min = value;
				}
			}
			get{return _min;}
		}
		
		/* 継承用に仮想関数で定義 */
		protected abstract void _Bot_Func();
		protected abstract void _Top_Func();
	}
	
	
	
	/* Hp parameter抽象クラスを継承して実装 */
	class Hp : parameter {
	
		/*------------- 以下コンストラクタ -------------*/
		/* デフォルトコンストラクタ */
		public Hp(){}
		/* 1引数コンストラクタ */
		public Hp(int top) : base (top){}
		/* 2引数コンストラクタ */
		public Hp(int top,int mid) : base (top,mid){}
		/* 3引数コンストラクタ */
		public Hp(int top,int mid,int bot) : base (top,mid,bot){}
		/*------------- 以上コンストラクタ -------------*/
		
		
		/* 最大HP値更新 */
		/* 更新時true : 非更新時(更新値がmax未満の場合)false*/
		public bool Max_Hp_Update(int val){
		
			if( max < val ){
				max = val;
				return true;
			}else{
				return false;
			}
		}
		
		/* Bot:オーバーライド */
		protected override void _Bot_Func(){
			System.Console.WriteLine("力尽きた。目の前が真っ白になった");
		}
		/* Top:オーバーライド */
		protected override void _Top_Func(){}
		
	}
	
	
	
	/* Mp parameter抽象クラスを継承して実装 */
	class Mp : parameter {
	
		/*------------- 以下コンストラクタ -------------*/
		/* デフォルトコンストラクタ */
		public Mp(){}
		/* 1引数コンストラクタ */
		public Mp(int top) : base (top){}
		/* 2引数コンストラクタ */
		public Mp(int top,int mid) : base (top,mid){}
		/* 3引数コンストラクタ */
		public Mp(int top,int mid,int bot) : base (top,mid,bot){}
		/*------------- 以上コンストラクタ -------------*/
		
		/* 最大MP値更新 */
		/* 更新時true : 非更新時(更新値がmax未満の場合)false*/
		public bool Max_Mp_Update(int val){
		
			if( max < val ){
				max = val;
				return true;
			}else{
				return false;
			}
		}		
		/* Bot:オーバーライド */
		protected override void _Bot_Func(){}
		/* Top:オーバーライド */
		protected override void _Top_Func(){}
		
	}
	
	
	
	/* Exp parameter抽象クラスを継承して実装 */
	class Exp : parameter {
		
		/*------------- 以下コンストラクタ -------------*/
		/* デフォルトコンストラクタ */
		public Exp(){}
		/* 1引数コンストラクタ */
		public Exp(int top) : base (top){}
		/* 2引数コンストラクタ */
		public Exp(int top,int mid) : base (top,mid){}
		/* 3引数コンストラクタ */
		public Exp(int top,int mid,int bot) : base (top,mid,bot){}
		/*------------- 以上コンストラクタ -------------*/
		
		/* Bot:オーバーライド */
		protected override void _Bot_Func(){}
		/* Top:オーバーライド */
		protected override void _Top_Func(){
			/* 経験値が100以上の状態であれば */
			for( ; now >= 100 ; now -= 100 ){
				System.Console.WriteLine("レベルアップ!");
				//p.level.LevelUp();
			}
		}
		
	}
	
	
	
	/* Eevel parameter抽象クラスを継承して実装 */
	class Level : parameter {
		/* フィールド */
		private int _level;
		
		/* プロパティ */
		public  int level{
			set{_level = value;}
			get{return _level;}
		}
		
		/*------------- 以下コンストラクタ -------------*/
		/* デフォルトコンストラクタ */
		public Level(){}
		/* 1引数コンストラクタ */
		public Level(int top) : base (top){}
		/* 2引数コンストラクタ */
		public Level(int top,int mid) : base (top,mid){}
		/* 3引数コンストラクタ */
		public Level(int top,int mid,int bot) : base (top,mid,bot){}
		/*------------- 以上コンストラクタ -------------*/
		
		/* レベルアップ */
		public void LevelUp(){
			_level++;
			//p.hp.Max_Hp_Update(10);
			//p.mp.Max_Mp_Update(20);
		}
		
		/* Bot:オーバーライド */
		protected override void _Bot_Func(){}
		/* Top:オーバーライド */
		protected override void _Top_Func(){}
		
	}
	
	
	
	/* ステータスクラス */
	class Status {
		public Hp hp;
		public Mp mp;
		public Exp exp;
		public Level level;
		
		public Status(){
			hp = new Hp();
			mp = new Mp();
			exp = new Exp();
			level = new Level();
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
			_Size = new Vector(){ x=21 , y=11 };
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


