namespace WinFormsTest2024
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			dataGridView1 = new DataGridView();
			pictureBox1 = new PictureBox();
			button1 = new Button();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// dataGridView1
			// 
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(12, 12);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.Size = new Size(407, 506);
			dataGridView1.TabIndex = 0;
			// 
			// pictureBox1
			// 
			pictureBox1.BorderStyle = BorderStyle.FixedSingle;
			pictureBox1.Location = new Point(504, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(188, 184);
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 1;
			pictureBox1.TabStop = false;
			// 
			// button1
			// 
			button1.Location = new Point(504, 213);
			button1.Name = "button1";
			button1.Size = new Size(188, 29);
			button1.TabIndex = 2;
			button1.Text = "Create";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(955, 530);
			Controls.Add(button1);
			Controls.Add(pictureBox1);
			Controls.Add(dataGridView1);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private DataGridView dataGridView1;
		private PictureBox pictureBox1;
		private Button button1;
	}
}
