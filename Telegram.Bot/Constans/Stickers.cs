using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTelegram.Bot.Constans
{
	public class Stickers
	{
		public static readonly Dictionary<string, string> LoveStickers = new Dictionary<string, string>()
		{
			{"cuteHedgehog", "CAACAgIAAxkBAAEDKONheAABNEpb2nIdmPmK2yAhpbEB_zwAAscPAALuzllJ77fOwaT5eg8hBA"},
			{"twoFoxes", "CAACAgIAAxkBAAEDJ8hhd7wGuiZqMtGgZq6ahbeVHr77UAACjwAD9wLID_wtjEXQLXvPIQQ"},
			{"cuteFrog", "CAACAgIAAxkBAAEDK5dhei82ZyANRB3ISoClErIEiB_GBwACBQEAAjDUnRHjuap2nB4GSyEE"},
			{"sleepingFrogs", "CAACAgIAAxkBAAEDK6JhejybnM96wFFxXmQurVyOKIuUhQAC-AADMNSdEVG5hwJIi4KpIQQ"},
			{"ricardoWithFlowers", "CAACAgIAAxkBAAEDLdthe7IaDSOgn5QJZfoz9MT5_UNwXgACKQ0AAtPoKErNOe8RHramAAEhBA"},
			{"pepe", "CAACAgIAAxkBAAEDLd1he7Je6nGWuH-4AbIzoOa7nY8qBAACCgEAAjDUnRFWVFdpxm65byEE"},
			{"twoFrogs", "CAACAgIAAxkBAAEDLeZhe7rPglvtUJnJFJ0f_GCMmoQGHAAC-wADMNSdEe7TrvuTt3RGIQQ"},
			{"coolDonut", "CAACAgIAAxkBAAEDL59hfQo5ujNhblUf0Ay5TJ1i7LwVAQACVgADrWW8FFNmUhveRyN7IQQ"},
			{"ladyNoriNight", "CAACAgIAAxkBAAEDL6lhfQrLCtMt9H2VqyDz54vMUJ5gaQAC4wcAAkb7rAT9ebMBZStPYSEE"},
			{"dinTheDinoLove", "CAACAgIAAxkBAAEDL7dhfQtoCLL84RqF_NUCP1j9vdsJZQACQwMAArVx2gZYvRa_g3e_xyEE"}, // #10
		};

		public static string[] AllStikers = new string[]
		{
			"CAACAgIAAxkBAAEDKONheAABNEpb2nIdmPmK2yAhpbEB_zwAAscPAALuzllJ77fOwaT5eg8hBA",
			"CAACAgIAAxkBAAEDJ8hhd7wGuiZqMtGgZq6ahbeVHr77UAACjwAD9wLID_wtjEXQLXvPIQQ",
			"CAACAgIAAxkBAAEDK5dhei82ZyANRB3ISoClErIEiB_GBwACBQEAAjDUnRHjuap2nB4GSyEE",
			"CAACAgIAAxkBAAEDK6JhejybnM96wFFxXmQurVyOKIuUhQAC-AADMNSdEVG5hwJIi4KpIQQ",
			"CAACAgIAAxkBAAEDLdthe7IaDSOgn5QJZfoz9MT5_UNwXgACKQ0AAtPoKErNOe8RHramAAEhBA",
			"CAACAgIAAxkBAAEDNUVhgU3_sePrmNNPSrn40hJIHrOL3wACgw8AAv1KAUoYYOfWWiTEFiEE",
			"CAACAgIAAxkBAAEDLd1he7Je6nGWuH-4AbIzoOa7nY8qBAACCgEAAjDUnRFWVFdpxm65byEE",
			"CAACAgIAAxkBAAEDLeZhe7rPglvtUJnJFJ0f_GCMmoQGHAAC-wADMNSdEe7TrvuTt3RGIQQ",
			"CAACAgIAAxkBAAEDL59hfQo5ujNhblUf0Ay5TJ1i7LwVAQACVgADrWW8FFNmUhveRyN7IQQ",
			"CAACAgIAAxkBAAEDNUlhgU4rPxaAJoirFk5fTSaiOBoS_wACCREAAnAbEUv0vXfymd3KHyEE",
			"CAACAgIAAxkBAAEDNTVhgU1XnVTjgQmjPd6FQGlVYTc-3QAC-gADMNSdEQaxr8KI9p3dIQQ",
			"CAACAgIAAxkBAAEDL6lhfQrLCtMt9H2VqyDz54vMUJ5gaQAC4wcAAkb7rAT9ebMBZStPYSEE",
			"CAACAgIAAxkBAAEDL7dhfQtoCLL84RqF_NUCP1j9vdsJZQACQwMAArVx2gZYvRa_g3e_xyEE",
			"CAACAgIAAxkBAAEDNTNhgU0iWTdlXmYYnxLJ2tFuZsiXqwADAQACMNSdEWUlGO5M1I_XIQQ",
			"CAACAgIAAxkBAAEDNTdhgU1-PUlGUg3QaJTRxXPvBbYNlQACyBAAAqndMEtaK4o7Fp7cISEE",
			"CAACAgIAAxkBAAEDNTlhgU2dV7ipQkVyqVQ5pyZHC6lmNAAC5wIAArVx2gZIrx2wn98X5iEE",
			"CAACAgIAAxkBAAEDNUFhgU3cb7cEJIGMLtL1-yTqX6A5qgAC1xEAA87wS6HzeyYsUDh6IQQ",
			"CAACAgIAAxkBAAEDNUthgU5BeJwO9c_Omb4lj_lrYXcNqQACXA4AAps8CEtfuUWfWeFB2iEE",
			"CAACAgIAAxkBAAEDNU1hgU5sGeerw9PJIvXBXhh4moHOAQACwg4AAmG58UtqAAFU0_WhKLohBA", // #17
		};

		public static string GetRandomSticker<TKey>(IDictionary<TKey, string> dict)
		{
			Random rand = new Random(DateTime.Now.Millisecond);
			List<string> values = Enumerable.ToList(dict.Values);
			int size = dict.Count;			
			return values[rand.Next(size)];			
		}

		public static string GetSticker(IEnumerable<string> stikers, int key)
		{
			List<string> values = Enumerable.ToList(stikers);
			return values[key];
		}
	}
}
