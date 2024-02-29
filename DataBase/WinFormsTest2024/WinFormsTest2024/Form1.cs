using System.Net.Http.Json;
using System.Net.Http;
using System;
using QRCoder;
using Xceed.Words.NET;
using Xceed.Document.NET;

namespace WinFormsTest2024
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			using var appContext = new ApplicationContext();
			var users = appContext.User.ToList();

			dataGridView1.DataSource = users;

			var doc = DocX.Create(@"D:\repos\WinFormsTest2024\WinFormsTest2024\test.docx");
			doc.InsertParagraph("Test");
			doc.InsertParagraph("Test2");
			doc.Save();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string qrText = "123321456654";
			using var qrGenerator = new QRCodeGenerator();
			using var qrData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
			using var qrCode = new QRCode(qrData);

			pictureBox1.Image = qrCode.GetGraphic(10);
		}
	}
}
