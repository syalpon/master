namespace RPG{
	class HP : IAction {
		IAction iaction = new Lv();

		/*コンストラクタ*/
		public HP(){}
		public HP(int x):base(x,x,0){}
		public HP(int x,int y):base(x,x,y){}
		public HP(int x,int y,int z):base(x,y,z){}
		
		/*現在値が下限値を下回る場合*/
		protected override int Below_now(int val){
			if( val <= min ){
				/*死亡処理*/
				rc.Die();
				return min;
			}else{
				return val;
			}
			
		}
		/*HPの表示を変えたい*/
		/*void override show()*/
	}
}	
