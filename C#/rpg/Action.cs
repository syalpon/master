namespace RPG{
	class Action {
		/*イベントフィールド*/
		Character c;
		public event Events events;
		
		/*コンストラクタ*/
		public Action(Character c){
			this.c = c;
		}
		
		/*実行時の関数*/
		public void OnEvents(){
			if( events != null ){
				events(c);
			}
		}
	}
}	
