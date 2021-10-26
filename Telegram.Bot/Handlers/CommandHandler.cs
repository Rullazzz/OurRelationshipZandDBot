using MyTelegram.Bot.Constans;
using System;
using System.IO;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace MyTelegram.Bot.Handlers
{
	public class CommandHandler
	{
		private static readonly DateTime startDating = new DateTime(2020, 3, 9);

		public static async Task OnScheduleCommand(ITelegramBotClient botClient, ChatId chatId)
		{
			if (botClient is null)
			{
				throw new ArgumentNullException(nameof(botClient));
			}

			if (chatId is null)
			{
				throw new ArgumentNullException(nameof(chatId));
			}

			var path = Settings.AllowedUsersId["firstPartner"] == chatId ?
				@"E:\С# файлы\OurRelationshipZandDBot\Telegram.Bot\Constans\dashaSchedule.txt"
				: @"E:\С# файлы\OurRelationshipZandDBot\Telegram.Bot\Constans\zaharSchedule.txt";		

			using var r = new StreamReader(path);
			string schedule = r.ReadToEnd();

			await botClient.SendTextMessageAsync(chatId, schedule);
			await botClient.SendStickerAsync(chatId, "CAACAgIAAxkBAAEDKHNhd725RnrpL6ENhv0NF5fraQ9XugACBQEAAjDUnRHjuap2nB4GSyEE");
		}

		public static async Task OnDaysDatingCommand(ITelegramBotClient botClient, ChatId chatId)
		{
			if (botClient is null)
			{
				throw new ArgumentNullException(nameof(botClient));
			}

			if (chatId is null)
			{
				throw new ArgumentNullException(nameof(chatId));
			}

			var dating = DateTime.Now - startDating;
			string result = $"Мы встречаемся уже {dating.Days} дней!\n"
						  + $"или {Math.Round(dating.TotalHours)} часов!\n"
						  + $"Пусть другие завидуют😘😏";

			await botClient.SendTextMessageAsync(chatId, result);
			await botClient.SendStickerAsync(chatId, "CAACAgIAAxkBAAEDJ8hhd7wGuiZqMtGgZq6ahbeVHr77UAACjwAD9wLID_wtjEXQLXvPIQQ");
		}
	}
}
