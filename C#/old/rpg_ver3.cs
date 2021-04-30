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
			p.Show();
			p.hp -= 200;
			p.Show();
			p.hp += 110;
			p.Show();
			p.ex += 110;
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
		
		/* 仮想メソッド */
		protected virtual void Max_Update(int v){
			/* 上限が下限を下回らないようにする */
			if( _min <= v ){
				_max = v; 
				_now = v;
			}
		}
		protected virtual void Mid_Update(int v){
			if( _min < v && v <= _max ){
				_now = v;
			}else if( v <= _min ){
				Min_Over(v);
			}else if( _max < v ){
				Max_Over(v);
			}else{
				/* Do nothing */
			}
		}
		protected virtual void Min_Update(int v){
			/* 下限が上限を上回らないようにする */
			if( v <= _max ){
				_min = v;
			}
		}
		/* 現在値が上限/下限を超えた場合の処理：上限/下限でストップさせる */
		protected virtual void Max_Over(int v){_now = _max;}
		protected virtual void Min_Over(int v){_now = _min;}
		
		/* 表示 */
		public virtual void Show(string name,string m,string n){System.Console.Write( "{0}[{1}] : {2}/{3}{4}",m,name,_now,_max,n);}
	}
	
	
	
	/*------------*/
	/* 攻撃クラス */
	/*------------*/
	class Atk : Parameter{
		/* 表示メソッド */
		public void Show(string m,string n){
			System.Console.Write( "{0}攻撃 : {1}{2}",m,_now,n);
		}
	}
	
	
	
	/*------------*/
	/* 防御クラス */
	/*------------*/
	class Def : Parameter{
		/* 表示メソッド */
		public void Show(string m,string n){
			System.Console.Write( "{0}防御 : {1}{2}",m,_now,n);
		}
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
		
		/* 演算子のオーバーライド(加減乗除) */
		public static Hp operator+ (Hp x , int y) {x.now += y;return x;}
		public static Hp operator- (Hp x , int y) {x.now -= y;return x;}
		public static Hp operator* (Hp x , int y) {x.now *= y;return x;}
		public static Hp operator/ (Hp x , int y) {x.now /= y;return x;}
		
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
		public Lv lv;
		
		/* コンストラクタ */
		public Ex(ref Lv lv):this(ref lv,100,0,0){}
		public Ex(ref Lv lv,int top):this(ref lv,top,0,0){}
		public Ex(ref Lv lv,int top,int bot):this(ref lv,top,bot,bot){}
		public Ex(ref Lv lv,int top,int mid,int bot):base(top,mid,bot){this.lv = lv;}
		
		/* 経験値が溜まったときの処理処理 */
		protected override void Max_Over(int v){
			now = v - max;	/*超過分は持ち越し*/
			lv.now++;				/*1レベル上げる*/
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
		public Atk atk;
		public Def def;
		
		/* 設定値 */
		public int[] __dhp__ = {10,20,30};		/* レベルアップ時のhp伸びしろテーブル */
		public int[] __dmp__ = {50,150,300};	/* レベルアップ時のmp伸びしろテーブル */
		public int[] __datk__ = {1,2,3};		/* レベルアップ時のatk伸びしろテーブル */
		public int[] __ddef__ = {5,15,30};	/* レベルアップ時のdef伸びしろテーブル */
		
		public Lv(ref Hp hp,ref Mp mp,ref Atk atk,ref Def def):base(999,1,1){
			this.hp = hp;
			this.mp = mp;
			this.atk = atk;
			this.def = def;
		}
		
		/* レベルアップ処理(現在レベルが変わった時) */
		protected override void Mid_Update(int v){
			if(v > 0){ /* ただの呼び出しやマイナス時は無視 */
				/* レベルアップ時の表示 */
				System.Console.Write(" レベルアップ! ({0}Lv→{1}Lv)\n",_now,++_now);
				hp.max += __dhp__[now/100];
				mp.max += __dmp__[now/100];
				atk.max+= __datk__[now/100];
				def.max+= __ddef__[now/100];
			}
		}
		
		/* 表示メソッド */
		public void Show(string m,string n){base.Show("Lv",m,n);}
	}	
	
	
	
	/*------------*/
	/* 道具クラス */
	/*------------*/
	class Item{
		enum No{
			ShortSword,		//ショートソード
			NormalSword,	//
			LongSword,		//
			LittleShield,	//
			NormalShield,	//
			BigShield,		//
		}
		
		public Item(){
		}
		
	}
	
	
	
	/*------------*/
	/* 装備クラス */
	/*------------*/
	class Slot {
		/*マジックナンバー*/
		public static readonly int NUM = 8;
		
		/* インスタンス時の保存用クラス */
		public Hp hp;
		public Mp mp;
		public Atk atk;
		public Def def;	
		
		/* スロット */
		private int[] item;
		
		/* コンストラクタ */
		public Slot(ref Hp hp,ref Mp mp,ref Atk atk,ref Def def,params int[] slots){
			this.hp  = hp;
			this.mp  = mp;
			this.atk = atk;
			this.def = def;
			item = new int[NUM];
			/* 可変長引数でアイテムを取得 */
			int i=0;
			foreach(int s in slots){
				item[i]=s;
				i++;
			}
		}
		
		
	}
	
	
	
	/*------------------*/
	/* ステータスクラス */
	/*------------------*/
	class Status{
		public string name;
		public Atk atk;
		public Def def;
		public Hp hp;
		public Mp mp;
		public Ex ex;
		public Lv lv;
		public Slot slot;
		//public Item item;
		
		
		/* コンストラクタ */
		public Status(){
			name = "Alice";
			atk= new Atk();
			def= new Def();
			hp = new Hp();
			mp = new Mp();
			lv = new Lv(ref hp,ref mp,ref atk,ref def);
			ex = new Ex(ref lv);
			slot = new Slot(ref hp,ref mp,ref atk,ref def);
		}
		
		/* 表示 */
		public void Show(){
			System.Console.Write("------------------------------------------\n");
			System.Console.Write("[name] : {0}\n",name);
			lv.Show("","\t\t");
			ex.Show("","\n");
			hp.Show("","\t\t");
			mp.Show("","\n");
			atk.Show("","\t\t");
			def.Show("","\n");
			System.Console.Write("------------------------------------------\n\n");
		}
	}
}



































