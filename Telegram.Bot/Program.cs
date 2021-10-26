using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using MyTelegram.Bot.Constans;
using MyTelegram.Bot.Handlers;

namespace MyTelegram.Bot
{
	class Program
	{
		static void Main(string[] args)
		{
			InitializingBot();
		}

		static void InitializingBot()
		{
			var botClient = new TelegramBotClient(GetToken(@"E:\С# файлы\OurRelationshipZandDBot\Telegram.Bot\Constans\token.txt"));

			var me = botClient.GetMeAsync().Result;
			Console.WriteLine(
				$"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
			);

			using var cts = new CancellationTokenSource();

			// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
			botClient.StartReceiving(
				new DefaultUpdateHandler(HandleUpdateAsync, HandleErrorAsync),
				cts.Token);

			Console.WriteLine($"Start listening for @{me.Username}");
			Console.ReadLine();

			// Send cancellation request to stop bot
			cts.Cancel();
		}

		public static string GetToken(string pathToTokentxt)
		{
			using var r = new StreamReader(pathToTokentxt);
			var token = r.ReadLine();
			return token;
		}

		static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
		{
			var ErrorMessage = exception switch
			{
				ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
				_ => exception.ToString()
			};

			Console.WriteLine(ErrorMessage);
			return Task.CompletedTask;
		}

		static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
		{
			if (update.Type != UpdateType.Message)
				return;
			if (update.Message.Type != MessageType.Text)
				return;

			var chatId = update.Message.Chat.Id;
			SendDataInConsole(botClient, update, chatId);

			if (Settings.AllowedUsersId.ContainsValue(chatId))
			{
				var textMessage = update.Message.Text;

				if (textMessage.StartsWith(Commands.Schedule))
					await CommandHandler.OnScheduleCommand(botClient, update.Message.Chat);
				else if (textMessage.StartsWith(Commands.DaysDating))
					await CommandHandler.OnDaysDatingCommand(botClient, update.Message.Chat);				
			}
			else
			{
				await botClient.SendTextMessageAsync(update.Message.Chat, "Unknown user. Access denied!");
			}
		}

		private static void SendDataInConsole(ITelegramBotClient botClient, Update update, long chatId)
		{
			Console.WriteLine();
			Console.WriteLine($"Received a '{update.Message.Text}' message in chat {chatId}.");
			Console.WriteLine($"BotId: {botClient.BotId}");
			Console.WriteLine($"Is bot: {update.Message.From.IsBot}, id: {update.Message.From.Id} Name: {update.Message.From.FirstName}");
		}
	}
}
