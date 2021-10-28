using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTelegram.Bot.Constans
{
	public class Stickers
	{
		public static readonly Dictionary<string, string> LoveStickers = new Dictionary<string, string>()
		{
			{"cuteHedgehog",  "CAACAgIAAxkBAAEDKONheAABNEpb2nIdmPmK2yAhpbEB_zwAAscPAALuzllJ77fOwaT5eg8hBA"},
			{"twoFoxes", "CAACAgIAAxkBAAEDJ8hhd7wGuiZqMtGgZq6ahbeVHr77UAACjwAD9wLID_wtjEXQLXvPIQQ"},
			{"cuteFrog", "CAACAgIAAxkBAAEDK5dhei82ZyANRB3ISoClErIEiB_GBwACBQEAAjDUnRHjuap2nB4GSyEE"}
		};

		public static string GetRandomSticker<TKey>(IDictionary<TKey, string> dict)
		{
			Random rand = new Random();
			List<string> values = Enumerable.ToList(dict.Values);
			int size = dict.Count;			
			return values[rand.Next(size)];			
		}
	}
}
