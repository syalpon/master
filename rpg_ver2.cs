using System.Collections.Generic;

namespace main_frame{
	
	/* 初期クラス */
	class Initializer{
		/* メイン関数 */
		public static void Main(){
			Status p = new Status();
			p.Show();
			p.ex.now += 60;
			p.ex.now += 60;
			p.hp.now += 10;
			p.Show();
		}
	}
	
	
	
	/* イベントクラス */
	class Game_Event{
		public static void Game_Over(){
			System.Console.Write("\t力尽きた。\n\t目の前が真っ白になった。\n");
		}
	}
	
	
	
	/* パラメータークラス */
	class Parameter{
		/* フィールド */
		private int _max;
		private int _now;
		private int _min;
		
		
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
		/* デフォルトコンストラクタ */
		public Parameter(){
			_max	= 100;
			_now	= 100;
			_min	= 0;
		}
		
		/* 1引数コンストラクタ */
		public Parameter( int top ){
			_max	= top;
			_now	= top;
			_min	= 0;
		}
		
		/* 2引数コンストラクタ */
		public Parameter( int top , int bot ){
			_max	= top;
			_now	= top;
			_min	= bot;
		}
		/* 3引数コンストラクタ */
		public Parameter( int top , int mid , int bot ){
			_max	= top;
			_now	= mid;
			_min	= bot;
		}
		/*------------- 以上コンストラクタ -------------*/
		
		/* 仮想メソッド */
		protected virtual void Max_Update(int v){
			/* 上限が下限を下回らないようにする */
			if( _min <= v ){_max = v;}
		}
		protected virtual void Mid_Update(int v){
			if( _min <= v && v <= _max ){
				_now = v;
			}else if( v < _min ){
				Min_Over(v);
			}else if( _max < v ){
				Max_Over(v);
			}else{
				/* Do nothing */
			}
		}
		protected virtual void Min_Update(int v){
			/* 下限が上限を上回らないようにする */
			if( v <= _max ){_min = v;}
		}
		/* 現在値が上限/下限を超えた場合の処理：上限/下限でストップさせる */
		protected virtual void Max_Over(int v){_now = _max;}
		protected virtual void Min_Over(int v){_now = _min;}
		/* 表示 */
		public virtual void Show(string name){
			System.Console.Write( "[{0}] : {1}/{2}\n",name,_now,_max);
		}
	}
	
	
	
	/* HPクラス */
	class Hp : Parameter{
	
		/* コンストラクタ */
		public Hp(){}
		
		/* オーバーライドメソッド */
		protected override void Min_Over(int v){
			now = min;
			Game_Event.Game_Over();
		}
		protected override void Max_Over(int v){
			now = max;
		}
		
		/* 表示メソッド */
		public void Show(){base.Show("HP");}
	}
	
	
	
	/* 魔力クラス */
	class Mp : Parameter{
		public void Magic(){
			now -= 10;
			System.Console.Write("\t[魔法名] : \n");
		}
		/* 表示メソッド */
		public void Show(){base.Show("MP");}
	}
	
	
	
	/* 経験値クラス */
	class Ex : Parameter{
		public Lv lvp;
		public Ex(ref Lv lv):base(100,0,0){lvp = lv;}
		
		/* レベルアップ */
		public void LevelUp(Lv lv){Max_Over(0);}
		
		/* レベルアップ処理 */
		protected override void Max_Over(int v){
			now -= max;
			lvp.now++;
		}
		
		/* 表示メソッド */
		public void Show(){
			base.Show("Ex");
		}		
	}
	
	
	
	/* レベルクラス */
	class Lv : Parameter {
		public Hp hpp;
		public Mp mpp;
		public Lv(ref Hp hp,ref Mp mp):base(999,1,1){
			hpp = hp;
			mpp = mp;
		}
		
		/* レベルアップ */
		protected override void Max_Over(int v){
			now++;
			hpp.max += 10;
			mpp.max += 50;
		}
		
		/* 表示メソッド */
		public void Show(){
			base.Show("Lv");
		}
	}	
	
	
	
	/* ステータスクラス */
	class Status{
		public Hp hp;
		public Mp mp;
		public Ex ex;
		public Lv lv;
		
		/* コンストラクタ */
		public Status(){
			hp = new Hp();
			mp = new Mp();
			lv = new Lv(ref hp,ref mp);
			ex = new Ex(ref lv);
		}
		
		/* 表示 */
		public void Show(){
			hp.Show();
			mp.Show();
			ex.Show();
			lv.Show();
		}
		
	}
}



































