using System;
using System.Drawing;
using System.Windows.Forms;

class win1 : Form{
	
	//�s�N�`���ϐ�
	PictureBox[,] pictureBox = new PictureBox[5,6];
	//�J�[�\���ʒu
	Point draggedPoint;

	
	//�h���b�O�����̔���
	bool dragged;
	int drop_x;
	int drop_y;
	int grid_x;
	int grid_y;
	
	//�R���X�g���N�^
	public win1(int sizeX,int sizeY){
		
		
		//window�T�C�Y�ݒ�
		ClientSize = new Size(sizeX,sizeY);
		
		int cell_size = 100;	//�Z���T�C�Y
		
		for(int y=0;y<5;y++){
			for(int x=0;x<6;x++){
				int z = x+y*5;
				pictureBox[y,x] = new PictureBox()
		        {
					
					Left = 500-x*cell_size,
					Top = 800-y*cell_size,
					SizeMode = PictureBoxSizeMode.Zoom,
					Size = new Size(100,100),
		            Image = new Bitmap(@"C:\Users\���㑾��\Documents\C#\r_ball.png"),
					Text = z.ToString(),
		        };
				
				//�h���b�v�̊Ď�
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
		
		
		//window�����ʒu�ݒ�
		Location = new Point(50,50);		
	}
	
		
	//�y�C���g�����̏㏑��
	protected override void OnPaint(PaintEventArgs e){
		//���b�Z�[�W�`��
		e.Graphics.DrawString(
			"�p�Y�h��",						// msg
			new Font("�l�r ����",64),		// FONT
			new SolidBrush(Color.Black),	// COLOR
			100,150							// X,Y
		);
	}
	

	
	//�}�E�X�{�^���������ꂽ�Ƃ�
	void Drop_MouseDown(object sender,MouseEventArgs e){
		
		base.OnMouseDown(e);
		dragged = true;
		
		draggedPoint = this.PointToClient(Cursor.Position);	
		
		//�͂񂾈ʒu��ۑ�
		grid_x = e.Location.X;
		grid_y =  e.Location.Y;
		
		//�͂񂾃h���b�v���W�̎擾
		drop_x = 5-(draggedPoint.X/100);
		drop_y = 4-(draggedPoint.Y/100-4);
	}
	
	//�}�E�X�h���b�O��
	void Drop_MouseMove(object sender,MouseEventArgs e){
		
    	base.OnMouseMove(e);
		
        if (dragged)
        {
			Point cursorPoint = this.PointToClient(Cursor.Position);
	
			pictureBox[drop_y,drop_x].Left = cursorPoint.X - grid_x;
            pictureBox[drop_y,drop_x].Top  = cursorPoint.Y - grid_y;
        }
	}
	
	//�}�E�X�{�^���������ꂽ�Ƃ�
	void Drop_MouseUp(object sender,MouseEventArgs e){
		
		base.OnMouseUp(e);
		
		dragged = false;
		draggedPoint = e.Location;
	}
	
	
	/* ���C�� */
	static void Main(){

		Application.EnableVisualStyles();
		Application.Run( new win1(600,1000) );
	}
	
}
