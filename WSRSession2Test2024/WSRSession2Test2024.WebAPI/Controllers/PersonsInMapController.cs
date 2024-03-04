using Microsoft.AspNetCore.Mvc;
using WSRSession2Test2024.WebAPI.Models;

namespace WSRSession2Test2024.WebAPI.Controllers
{
	[Route("api/Get[controller]")]
	[ApiController]
	public class PersonsInMapController : ControllerBase
	{
		private readonly Random _rnd = new();

		[HttpGet(Name = "GetPersonsInMap")]
		public IEnumerable<PersonInMapData> Get()
		{
			var personsInMapList = new List<PersonInMapData>();

			for(int i = 0; i < 5; i++)
			{
				var numPersonType = _rnd.Next(0, 3);
				var numDirection = _rnd.Next(0, 2);

				personsInMapList.Add(new PersonInMapData()
				{
					PersonCode = _rnd.Next(1000, 10000),
					PersonType = Enum.GetValues<PersonType>()[numPersonType],
					LastSecurityPointNumber = _rnd.Next(0, 23).ToString(),
					LastSecurityPointDirection = numDirection % 2 == 0 ? "in" : "out",
					LastSecurityPointTime = DateTime.Now
				});
			}

			return personsInMapList;
		}
	}
}
