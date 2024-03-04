namespace WSRSession2Test2024
{
	public class RoomPersonsData
	{
		private int _personCode;
		private PersonType _personType;
		private int _posX;
		private int _posY;

		public RoomPersonsData() { }

		public RoomPersonsData(int personCode, PersonType personType, int posX, int posY) 
		{
			_personCode = personCode;
			_personType = personType;
			_posX = posX;
			_posY = posY;
		}

		public int PersonCode 
		{
			get => _personCode;
			set { _personCode = value; }
		}

		public PersonType PersonType
		{
			get => _personType;
			set { _personType = value; }
		}

		public int PosX
		{
			get => _posX;
			set { _posX = value; }
		}

		public int PosY
		{
			get => _posY;
			set { _posY = value; }
		}
	}
}
