﻿using System.Threading.Tasks;
using NetTelegram.Bot.Framework;
using NetTelegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;

namespace NetTelegram.Bot.Sample.Bots.GreeterBot
{
    public class PhotoForwarder : UpdateHandlerBase
    {
        public override bool CanHandleUpdate(IBot bot, Update update)
        {
            return update.Message.Photo != null;
        }

        public override async Task<UpdateHandlingResult> HandleUpdateAsync(IBot bot, Update update)
        {
            await bot.Client.ForwardMessageAsync(update.Message.Chat.Id,
                update.Message.Chat.Id,
                update.Message.MessageId);

            return UpdateHandlingResult.Handled;
        }
    }
}
