using System.Collections.Generic;

namespace MyTelegram.Bot.Constans
{
	public static class Settings
	{
		private const string token = "2092804178:AAGMsJQPnu9mabwhEqb1oV5CIWZdCfJUEcU";

		public static readonly Dictionary<string, long> AllowedUsersId = new Dictionary<string, long>()
		{
			{"firstPartner",  846062920},
			{"secondPartner", 1215993728}
		};

		public static string GetToken()
		{
			return token;
		}
	}
}
