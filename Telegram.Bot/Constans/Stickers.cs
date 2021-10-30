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
			{"dinTheDinoLove", "CAACAgIAAxkBAAEDL7dhfQtoCLL84RqF_NUCP1j9vdsJZQACQwMAArVx2gZYvRa_g3e_xyEE"},
		};

		public static string GetRandomSticker<TKey>(IDictionary<TKey, string> dict)
		{
			Random rand = new Random(DateTime.Now.Millisecond);
			List<string> values = Enumerable.ToList(dict.Values);
			int size = dict.Count;			
			return values[rand.Next(size)];			
		}

		public static string GetSticker<TKey>(IDictionary<TKey, string> dict, int key)
		{
			List<string> values = Enumerable.ToList(dict.Values);
			return values[key]; 
		}
	}
}
