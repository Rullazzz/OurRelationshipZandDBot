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
		private static int currentIndexMotivation = 0;
		private static int currentIndexSticker = 0;		
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

			await botClient.SendTextMessageAsync(chatId, motivations[GetNextIndex(ref currentIndexMotivation, motivations.Length)]);
			await botClient.SendStickerAsync(chatId, Stickers.GetSticker(Stickers.LoveStickers, GetNextIndex(ref currentIndexSticker, motivations.Length)));
		}

		private static int GetNextIndex(ref int value, int count)
		{
			if ((value + 1) < count)
				return ++value;
			else
				return value = 0;
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
