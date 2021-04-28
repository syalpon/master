namespace RPG
{
	class Status 
	{
		/*フィールド*/
		private string _name;
		private HP  _hp;
		private ATC _atc;
		private EXP _exp;
		private LV  _lv;
		
		/*プロパティ*/
		public string name
		{
			set{ _name = f(value);}
			get{ return _name;}
		}
		public virtual string f(string h)
		{
			return h;
		}

		public HP hp
		{
			set{ _hp = value;}
			get{ return _hp;}
		}
		public ATC atc
		{
			set{ _atc = value;}
			get{ return _atc;}
		}
		public EXP exp
		{
			set{ _exp = value;}
			get{ return _exp;}
		}
		public LV lv
		{
			set{ _lv = value;}
			get{ return _lv;}
		}
		
		
		/*コンストラクタ*/
		public Status():this("Unknown"){}
		public Status(string n){
			_name = n;
			_hp  = new HP(100,100,0);
			_atc = new ATC(999,10,0);
			_exp = new EXP(100,0,0);
			_lv  = new LV(99,1,0);
		}
		
		/*表示部*/
		public void Show(){
			System.Console.WriteLine("\n");
			System.Console.WriteLine("{0}のステータス表示",name);
			_hp.Show("HP :");
			_exp.Show("EXP:");
			_atc.Show("ATC:","{1}");
			_lv.Show("LV :","{1}");
		}
	}
}	
