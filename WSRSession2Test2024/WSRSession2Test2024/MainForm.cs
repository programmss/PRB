using Newtonsoft.Json;
using WSRSession2Test2024.WebAPI.Models;

namespace WSRSession2Test2024
{
	public partial class MainForm : Form
	{
		private const int CIRCLE_WIDTH = 25;
		private const int CIRCLE_HEIGHT = 25;
		private const int DISTANCE_BETWEEN_CIRCLES = 5;
		private const int CIRCLES_OFFSET = 10;

		private readonly Dictionary<string, List<RoomPersonsData>> _hospitalMap = [];
		private readonly Random _rnd = new();
		private readonly List<PictureBox> _pbSKUDList = [];

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainFormLoad(object sender, EventArgs e)
		{
			pbMap.Controls.Add(tlpMap);

			DoubleBuffered = true;
			SetStyle(
			ControlStyles.AllPaintingInWmPaint |
			ControlStyles.UserPaint |
			ControlStyles.DoubleBuffer,
			true);

			CreateRoomsImage();

			GenerateMap(tlpTopLevel);
			GenerateMap(tlpBottomLevel);
			GenerateMap(tlpTopLevelSKUD0);
		}

		/// <summary>
		/// Генерируем/инициализируем сетку ячеек возможного местонахождения людей в каждой комнате
		/// </summary>
		/// <param name="tlpLevel"></param>
		private void GenerateMap(TableLayoutPanel tlpLevel)
		{
			foreach(var control in tlpLevel.Controls)
			{
				var pbSKUD = control as PictureBox;

				if(pbSKUD is not null)
				{
					_pbSKUDList.Add(pbSKUD);

					var roomPersonsDataList = new List<RoomPersonsData>();

					for(int x = CIRCLES_OFFSET; x <= pbSKUD.Width - (CIRCLE_WIDTH + DISTANCE_BETWEEN_CIRCLES); x += (CIRCLE_WIDTH + DISTANCE_BETWEEN_CIRCLES))
					{
						for(int y = CIRCLES_OFFSET; y <= pbSKUD.Height - (CIRCLE_HEIGHT + DISTANCE_BETWEEN_CIRCLES); y += (CIRCLE_HEIGHT + DISTANCE_BETWEEN_CIRCLES))
						{
							var roomPersonsData = new RoomPersonsData(0, PersonType.None, x, y);

							roomPersonsDataList.Add(roomPersonsData);
						}
					}

					_hospitalMap.Add(pbSKUD.Tag.ToString(), roomPersonsDataList);
				}
			}
		}

		// Получаем и обновляем данные о передвижении людей по комнатам больницы 
		private async void TimerGetPersonsDataTick(object sender, EventArgs e)
		{
			using var client = new HttpClient();
			var response = await client.GetAsync("https://localhost:7228/api/GetPersonsInMap");

			if(response is not null)
			{
				var jsonString = await response.Content.ReadAsStringAsync();
				var personsInMapData = JsonConvert.DeserializeObject<List<PersonInMapData>>(jsonString);

				foreach(var person in personsInMapData)
				{
					var room = (from m in _hospitalMap
								where m.Key == person.LastSecurityPointNumber
								select m.Value).First();

					if(person.LastSecurityPointDirection == "in")
					{
						var emptyPlacesInRoom = (from r in room
												 where r.PersonType == PersonType.None
												 select r).ToList();

						if(emptyPlacesInRoom.Count > 0)
						{
							var randomEmptyPlaceInRoomIndex = _rnd.Next(0, emptyPlacesInRoom.Count);

							room[randomEmptyPlaceInRoomIndex].PersonType = person.PersonType;
							room[randomEmptyPlaceInRoomIndex].PersonCode = person.PersonCode;

							DrawPersonsInRoom(person.LastSecurityPointNumber);
						}
					}
					else
					{
						var personPlaceInRoom = (from r in room
												 where r.PersonCode == person.PersonCode
												 select r).FirstOrDefault();

						if(personPlaceInRoom is not null)
						{
							personPlaceInRoom.PersonCode = 0;
							personPlaceInRoom.PersonType = PersonType.None;

							DrawPersonsInRoom(person.LastSecurityPointNumber);
						}
					}
				}
			}
		}

		/// <summary>
		/// Отрисовка заполненности комнаты
		/// </summary>
		/// <param name="roomNumber">Номер комнаты</param>
		private void DrawPersonsInRoom(string roomNumber)
		{
			var pbSKUD = (from pbList in _pbSKUDList
						 where pbList.Tag.ToString() == roomNumber
						 select pbList).FirstOrDefault();
			pbSKUD.Image = new Bitmap(pbSKUD.Width, pbSKUD.Height);

			var personsInRoom = (from m in _hospitalMap
								 from rpd in m.Value
								 where m.Key == roomNumber
								    && rpd.PersonType != PersonType.None
								 select rpd).ToList();

			foreach(var person in personsInRoom)
			{
				var personColor = person.PersonType == PersonType.Pacient ? Brushes.Green : Brushes.Blue;

				var g = Graphics.FromImage(pbSKUD.Image);
				g.FillEllipse(personColor, person.PosX, person.PosY, CIRCLE_WIDTH, CIRCLE_HEIGHT);
				g.DrawString(person.PersonCode.ToString(), new Font(Font.FontFamily, 8), Brushes.White, new Point(person.PosX - 1, person.PosY + 5));
			}

			pbSKUD.Refresh();
		}

		/// <summary>
		/// Создание области рисования в комнатах больницы
		/// </summary>
		private void CreateRoomsImage()
		{
			foreach(var control in tlpTopLevel.Controls)
			{
				var pbSKUD = control as PictureBox;

				if(pbSKUD is not null)
				{
					pbSKUD.Image = new Bitmap(pbSKUD.Width, pbSKUD.Height);
				}
			}

			foreach(var control in tlpBottomLevel.Controls)
			{
				var pbSKUD = control as PictureBox;

				if(pbSKUD is not null)
				{
					pbSKUD.Image = new Bitmap(pbSKUD.Width, pbSKUD.Height);
				}
			}
		}
	}
}
