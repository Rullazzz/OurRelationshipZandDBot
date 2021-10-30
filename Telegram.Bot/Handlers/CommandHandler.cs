using MyTelegram.Bot.Constans;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace MyTelegram.Bot.Handlers
{
	public class CommandHandler
	{
		private static Random rnd = new Random();
		private static int lastRandomIndex = 0;

		private static readonly DateTime startDating = new DateTime(2020, 3, 9);

		public static async Task OnScheduleCommand(ITelegramBotClient botClient, ChatId chatId)
		{
			if (botClient is null)
				throw new ArgumentNullException(nameof(botClient));

			if (chatId is null)
				throw new ArgumentNullException(nameof(chatId));

			//TODO: Потом переделать для себя!
			var schedule = Settings.AllowedUsersId["firstPartner"] == chatId.Identifier ? Answers.GetDashaSchedule() : Answers.GetDashaSchedule();

			await botClient.SendTextMessageAsync(chatId, schedule, ParseMode.Markdown);
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
			await botClient.SendStickerAsync(chatId, Stickers.LoveStickers["twoFrogs"]);
		}

		public static async Task OnMotivationCommand(ITelegramBotClient botClient, ChatId chatId)
		{
			if (botClient is null)
				throw new ArgumentNullException(nameof(botClient));			

			if (chatId is null)
				throw new ArgumentNullException(nameof(chatId));

			var motivations = Settings.AllowedUsersId["firstPartner"] == chatId ? Answers.GetMotivationForDasha() : Answers.GetMotivationForDasha();
			//TODO: Добавить мотивацию для себя.

			var randomIndex = GetRandomNumber(motivations.Length);

			await botClient.SendTextMessageAsync(chatId, motivations[randomIndex]);
			await botClient.SendStickerAsync(chatId, Stickers.GetRandomSticker(Stickers.LoveStickers));
		}

		private static int GetRandomNumber(int count)
		{
			var randomIndex = rnd.Next(count);
			if (randomIndex == lastRandomIndex && count >= 2)
			{
				while (randomIndex == lastRandomIndex)
					randomIndex = rnd.Next(count);
			}
			lastRandomIndex = randomIndex;
			return randomIndex;
		}

		public static async Task OnInfoCommand(ITelegramBotClient botClient, ChatId chatId)
		{
			if (botClient is null)
				throw new ArgumentNullException(nameof(botClient));

			if (chatId is null)
				throw new ArgumentNullException(nameof(chatId));

			var info = Answers.GetInfo();
			await botClient.SendTextMessageAsync(chatId, info);
		}
	}
}
