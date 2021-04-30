using System;
using System.Drawing;
using System.Windows.Forms;

class win1 : Form{
	
	//ピクチャ変数
	PictureBox[,] pictureBox = new PictureBox[5,6];
	//カーソル位置
	Point draggedPoint;

	
	//ドラッグ中かの判定
	bool dragged;
	int drop_x;
	int drop_y;
	int grid_x;
	int grid_y;
	
	//コンストラクタ
	public win1(int sizeX,int sizeY){
		
		
		//windowサイズ設定
		ClientSize = new Size(sizeX,sizeY);
		
		int cell_size = 100;	//セルサイズ
		
		for(int y=0;y<5;y++){
			for(int x=0;x<6;x++){
				int z = x+y*5;
				pictureBox[y,x] = new PictureBox()
		        {
					
					Left = 500-x*cell_size,
					Top = 800-y*cell_size,
					SizeMode = PictureBoxSizeMode.Zoom,
					Size = new Size(100,100),
		            Image = new Bitmap(@"C:\Users\尾上太一\Documents\C#\r_ball.png"),
					Text = z.ToString(),
		        };
				
				//ドロップの監視
				pictureBox[y,x].MouseUp +=
					new MouseEventHandler(Drop_MouseUp);
				pictureBox[y,x].MouseMove +=
					new MouseEventHandler(Drop_MouseMove);
				pictureBox[y,x].MouseDown +=
					new MouseEventHandler(Drop_MouseDown);
				this.Controls.Add(pictureBox[y,x]);					
			}	
		}

		//this.BackColor = SystemColors.Window;
		
		
		//window生成位置設定
		Location = new Point(50,50);		
	}
	
		
	//ペイント処理の上書き
	protected override void OnPaint(PaintEventArgs e){
		//メッセージ描画
		e.Graphics.DrawString(
			"パズドラ",						// msg
			new Font("ＭＳ 明朝",64),		// FONT
			new SolidBrush(Color.Black),	// COLOR
			100,150							// X,Y
		);
	}
	

	
	//マウスボタンが押されたとき
	void Drop_MouseDown(object sender,MouseEventArgs e){
		
		base.OnMouseDown(e);
		dragged = true;
		
		draggedPoint = this.PointToClient(Cursor.Position);	
		
		//掴んだ位置を保存
		grid_x = e.Location.X;
		grid_y =  e.Location.Y;
		
		//掴んだドロップ座標の取得
		drop_x = 5-(draggedPoint.X/100);
		drop_y = 4-(draggedPoint.Y/100-4);
	}
	
	//マウスドラッグ中
	void Drop_MouseMove(object sender,MouseEventArgs e){
		
    	base.OnMouseMove(e);
		
        if (dragged)
        {
			Point cursorPoint = this.PointToClient(Cursor.Position);
	
			pictureBox[drop_y,drop_x].Left = cursorPoint.X - grid_x;
            pictureBox[drop_y,drop_x].Top  = cursorPoint.Y - grid_y;
        }
	}
	
	//マウスボタンが離されたとき
	void Drop_MouseUp(object sender,MouseEventArgs e){
		
		base.OnMouseUp(e);
		
		dragged = false;
		draggedPoint = e.Location;
	}
	
	
	/* メイン */
	static void Main(){

		Application.EnableVisualStyles();
		Application.Run( new win1(600,1000) );
	}
	
}
