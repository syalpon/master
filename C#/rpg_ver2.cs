using System.Collections.Generic;

namespace main_frame{
	
	/*------------*/
	/* 初期クラス */
	/*------------*/
	class Initializer{
		/* メイン関数 */
		public static void Main(){
			Status p = new Status();
			p.Show();
			p.ex += 160;
			p.hp += 110;
			p.Show();
			
		}
	}
	
	
	
	/*--------------*/
	/* ゲームクラス */
	/*--------------*/
	class Game{
		/* ゲームオーバー時処理 */
		public static void Game_Over(){
			System.Console.Write("\t|>>力尽きた。\n\t|>>目の前が真っ白になった。\n");
		}
	}
	
	
	
	/*--------------------*/
	/* パラメータークラス */
	/*--------------------*/
	class Parameter{
		/* フィールド */
		protected int _max;
		protected int _now;
		protected int _min;
		
		
		/* プロパティ */
		public int max{
			set{Max_Update(value);}
			get{return _max;}
		}
		
		public int now{
			set{Mid_Update(value);}
			get{return _now;}
		}
		
		public int min{
			set{Min_Update(value);}
			get{return _min;}
		}
		
		/*------------- 以下コンストラクタ -------------*/
		public Parameter():this(100,100,0){}									/* デフォルトコンストラクタ */
		public Parameter(int top):this(top,top,0){}						/* 1引数コンストラクタ */
		public Parameter(int top,int bot):this(top,top,bot){}	/* 2引数コンストラクタ */
		public Parameter(int top,int mid,int bot){						/* 3引数コンストラクタ */
			_max	= top;
			_now	= mid;
			_min	= bot;
		}
		/*------------- 以上コンストラクタ -------------*/
		
		/*------------- 以下演算子多重定義 -------------*/
		public static object operator+ (Parameter x , int y) {x.now += y;return x;}
		public static object operator- (Parameter x , int y) {x.now -= y;return x;}
		public static object operator* (Parameter x , int y) {x.now *= y;return x;}
		public static object operator/ (Parameter x , int y) {x.now /= y;return x;}
		public static implicit operator object(int x) {return x;}
		/*------------- 以上演算子多重定義 -------------*/
		
		/* 仮想メソッド */
		protected virtual void Max_Update(int v){
			/* 上限が下限を下回らないようにする */
			if( _min <= v ){_max = v;}
		}
		protected virtual void Mid_Update(int v){
		
			if			( _min < v && v <= _max )		{_now = v;}
			else	if( v <= _min )								{Min_Over(v);}
			else	if( _max < v )								{Max_Over(v);}
			else																{/* Do nothing */}
		}
		protected virtual void Min_Update(int v){
			/* 下限が上限を上回らないようにする */
			if( v <= _max ){_min = v;}
		}
		
		/* 現在値が上限/下限を超えた場合の処理：上限/下限でストップさせる */
		protected virtual void Max_Over(int v){_now = _max;}
		protected virtual void Min_Over(int v){_now = _min;}
		
		/* 表示 */
		public virtual void Show(string name,string m,string n){System.Console.Write( "{0}[{1}] : {2}/{3}{4}",m, name,_now,_max,n);}
	}
	
	
	
	/*----------*/
	/* HPクラス */
	/*----------*/
	class Hp : Parameter{
		
		/* オーバーライドメソッド */
		protected override void Min_Over(int v){
			_now = _min;
			Game.Game_Over();
		}
		
		protected override void Max_Update(int v){
			/* 上限が下限を下回らないようにする */
			if( _min <= v ){
				_max = v;
				_now = v;
			}
		}
		
		/* 表示メソッド */
		public void Show(string m,string n){base.Show("HP",m,n);}
	}
	
	
	/*------------*/
	/* 魔力クラス */
	/*------------*/
	class Mp : Parameter{
		public void Magic(){
			now -= 10;
			System.Console.Write("\t[魔法名] : \n");
		}
		
		/* オーバーライドメソッド */
		protected override void Max_Update(int v){
			/* 上限が下限を下回らないようにする */
			if( _min <= v ){
				_max = v;
				_now = v;
			}
		}
		
		/* 演算子のオーバーライド(加減乗除) */
		public static Mp operator+ (Mp x , int y) {x.now += y;return x;}
		public static Mp operator- (Mp x , int y) {x.now -= y;return x;}
		public static Mp operator* (Mp x , int y) {x.now *= y;return x;}
		public static Mp operator/ (Mp x , int y) {x.now /= y;return x;}
		
		/* 表示メソッド */
		public void Show(string m,string n){base.Show("MP",m,n);}
	}
	
	
	
	/*--------------*/
	/* 経験値クラス */
	/*--------------*/
	class Ex : Parameter{
		/* コンストラクタ */
		public Ex():this(100,0,0){}
		public Ex(int top):this(top,0,0){}
		public Ex(int top,int bot):this(top,bot,bot){}
		public Ex(int top,int mid,int bot):base(top,mid,bot){}
		
		/* 経験値が溜まったときの処理 */
		protected override void Max_Over(int v){
			now = v - max;	/*超過分は持ち越し*/
		}
		/* 現在値が最大値になった時レベルアップさせるように修正 */
		protected override void Mid_Update(int v){
			if( _min < v && v < _max ){
				_now = v;
			}else if( v <= _min ){
				Min_Over(v);
			}else if( _max <= v ){
				Max_Over(v);
			}else{
				/* Do nothing */
			}
		}
		/* 演算子のオーバーライド(加減乗除) */
		public static Ex operator+ (Ex x , int y) {x.now += y;return x;}
		public static Ex operator- (Ex x , int y) {x.now -= y;return x;}
		public static Ex operator* (Ex x , int y) {x.now *= y;return x;}
		public static Ex operator/ (Ex x , int y) {x.now /= y;return x;}
		
		/* 表示メソッド */
		public void Show(string m,string n){base.Show("Ex",m,n);}
	}
	
	
	/*--------------*/
	/* レベルクラス */
	/*--------------*/
	class Lv : Parameter {
    
		/* インスタンス時の保存用クラス */
		public Hp hp;
		public Mp mp;

		/* 設定値 */
		public int[] __dhp__ = {10,20,30};		/* レベルアップ時のhp伸びしろテーブル */
		public int[] __dmp__ = {50,150,300};	/* レベルアップ時のhp伸びしろテーブル */
		
		public Lv():base(999,1,1){}
		
		/* 表示メソッド */
		public void Show(string m,string n){base.Show("Lv",m,n);}
	}	
	
	
	/*------------*/
	/* 攻撃クラス */
	/*------------*/
	class Atk : Parameter {
		public Atk():base(999,10,0){}
		public void Damege(Character c){
			System.Console.WriteLine( now+"のダメージ!");
			c.hp -= now;
		}
	}
	
	
	
	/*------------------*/
	/* ステータスクラス */
	/*------------------*/
	class Status{
		public string name;
		public Hp hp;
		public Mp mp;
		public Ex ex;
		public Lv lv;
		public Atk atk;
		
		/* コンストラクタ */
		public Status(){
			name = "Alice";
			hp = new Hp();
			mp = new Mp();
			lv = new Lv();
			ex = new Ex();
			atk= new Atk();
		}
		
		/* 表示 */
		public void Show(){
			System.Console.Write("------------------------------------------\n");
			System.Console.Write("[name] : {0}\n",name);
			lv.Show("","\t\t");
			ex.Show("","\n");
			hp.Show("","\t\t");
			mp.Show("","\n");
			System.Console.Write("------------------------------------------\n\n");
		}
	}
	
	/*キャラクタークラス*/
	class Character : Status {
		/*コンストラクタ*/
		public Character(){}
		public Character(string n){name = n;}
		
		public static Character operator+ (Character x , Character y) { x.hp -= y.atk.now; return x;}
	}
}











