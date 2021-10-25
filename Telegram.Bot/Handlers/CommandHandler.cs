using MyTelegram.Bot.Constans;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MyTelegram.Bot.Handlers
{
	public class CommandHandler
	{
		public static void OnScheduleCommand(ITelegramBotClient botClient, ChatId chatId)
		{
			var path = Settings.AllowedUsersId["firstPartner"] == chatId ?
				@"E:\С# файлы\OurRelationshipZandDBot\Telegram.Bot\Constans\dashaSchedule.txt"
				: @"E:\С# файлы\OurRelationshipZandDBot\Telegram.Bot\Constans\zaharSchedule.txt";		

			using var r = new StreamReader(path);
			string schedule = r.ReadToEnd();
			botClient.SendTextMessageAsync(chatId, schedule);
		}
	}
}
