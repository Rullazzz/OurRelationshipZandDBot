using MyTelegram.Bot.Constans;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MyTelegram.Bot.Handlers
{
	public class CommandHandler
	{
		private static readonly DateTime startDating = new DateTime(2020, 3, 9);

		public static async Task OnScheduleCommand(ITelegramBotClient botClient, ChatId chatId)
		{
			if (botClient is null)
				throw new ArgumentNullException(nameof(botClient));

			if (chatId is null)
				throw new ArgumentNullException(nameof(chatId));			

			var path = Settings.AllowedUsersId["firstPartner"] == chatId ?
				Path.GetFullPath(Directory.GetCurrentDirectory() + @"\..\..\..\Constans\dashaSchedule.txt"):
				Path.GetFullPath(Directory.GetCurrentDirectory() + @"\..\..\..\Constans\zaharSchedule.txt");		

			using var r = new StreamReader(path);
			string schedule = r.ReadToEnd();

			await botClient.SendTextMessageAsync(chatId, schedule);
			await botClient.SendStickerAsync(chatId, Stickers.LoveStickers["cuteFrog"]);
		}

		public static async Task OnDaysDatingCommand(ITelegramBotClient botClient, ChatId chatId)
		{
			if (botClient is null)
				throw new ArgumentNullException(nameof(botClient));			

			if (chatId is null)
				throw new ArgumentNullException(nameof(chatId));			

			var dating = DateTime.Now - startDating;
			string result = $"Мы встречаемся уже {dating.Days} дней!\n"
						  + $"или {Math.Round(dating.TotalHours)} часов!\n"
						  + $"Пусть другие завидуют😘😏";

			await botClient.SendTextMessageAsync(chatId, result);
			await botClient.SendStickerAsync(chatId, Stickers.LoveStickers["twoFoxes"]);
		}

		public static async Task OnMotivationCommand(ITelegramBotClient botClient, ChatId chatId)
		{
			if (botClient is null)
				throw new ArgumentNullException(nameof(botClient));			

			if (chatId is null)
				throw new ArgumentNullException(nameof(chatId));			

			var path = Settings.AllowedUsersId["firstPartner"] == chatId ?
				  Path.GetFullPath(Directory.GetCurrentDirectory() + @"\..\..\..\Constans\motivationForDasha.txt"): 
				  @"E:\С# файлы\OurRelationshipZandDBot\Telegram.Bot\Constans\motivationForDasha.txt";
			//TODO: Добавить мотивацию для себя.

			var motivationLines = new List<string>();
			string line;
			using (var r = new StreamReader(path))
			{
				while ((line = r.ReadLine()) != null)
					motivationLines.Add(line);
			}

			var rnd = new Random(DateTime.Now.Millisecond);

			await botClient.SendTextMessageAsync(chatId, motivationLines[rnd.Next(motivationLines.Count)]);
			await botClient.SendStickerAsync(chatId, Stickers.LoveStickers["cuteHedgehog"]);
		}
	}
}
