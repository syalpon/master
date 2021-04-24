namespace RPG{
	class EXP : Param {
		/*コンストラクタ*/
		public EXP(){}
		public EXP(int x):base(x,x,0){}
		public EXP(int x,int y):base(x,x,y){}
		public EXP(int x,int y,int z):base(x,y,z){}
		
		protected override int Exceed_now(int val){
			int old;
			if(	max < val ){
				while( max <= val ){
					old = val;
					val -= max;
					now = val;
					/*レベルアップ処理*/
					rc.lv.LevelUp(old);
					
				}
				return val;
			}else{
				return val;
			}
		}
	}
}	
