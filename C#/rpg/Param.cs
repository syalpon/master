namespace RPG{
	class Param {
		/*フィールド*/
		private Character _rc;
		private int _max;
		private int _now;
		private int _min;
		
		/*プロパティ*/
		public virtual int max{
			set{_max = Update_max(value);}
			get{return _max ;}
		}
		
		public virtual int now{
			set{
				/*現在値が増える場合*/
				if( _now < value ){
					_now = Exceed_now(value);
				/*現在値が減る場合*/
				}else if( value < _now ){
					_now = Below_now(value);
				}else{
					/*変化しない場合*/
				}
			}
			get{return _now ;}
		}
		
		public virtual int min{
			set{_min = Update_min(value);}
			get{return _min ;}
		}
		
		/*各プロパティの更新処理*/
		/*最大値が更新される場合*/
		protected virtual int Update_max(int val){
			return val;
		}
		
		/*現在値が上限値を上回る場合*/
		protected virtual int Exceed_now(int val){
			if(	_max < val ){
				return _max;
			}else{
				return val;
			}
		}
		/*現在値が下限値を下回る場合*/
		protected virtual int Below_now(int val){
			if( val <= _min ){
				return _min;
			}else{
				return val;
			}
		}
		
		/*最小値が更新される場合*/
		protected virtual int Update_min(int val){
			return val;
		}
		
		/*参照プロパティ*/
		public virtual Character rc{
			set{_rc = value;}
			get{return _rc;}
		}
		
		/*コンストラクタ*/
		public Param()									:this(100,100,0){}
		public Param(int x)							:this(x  ,x  ,0){}
		public Param(int x,int y)				:this(x  ,x  ,y){}
		public Param(int x,int y,int z){
			_max = x;
			_now = y;
			_min = z;
		}
		
		/*参照*/
		public void Reference(ref Character c){
			rc = c;
		}
		
		/*表示関数*/
		public virtual void Show(string n,string a){
			System.Console.WriteLine("{0}"+a,n,_now,_max);
		}
		public virtual void Show(string n){
			Show(n,"{1}/{2}");
		}
		public virtual void Show(){
			Show("   :");
		}
	}
}	
