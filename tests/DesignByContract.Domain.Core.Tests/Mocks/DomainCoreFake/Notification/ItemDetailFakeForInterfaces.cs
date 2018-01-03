﻿using DesignByContract.Domain.Core.Interfaces.Notifications;

namespace DesignByContract.Domain.Core.Tests.Mocks.DomainCoreFake.Notification
{
    public class ItemDetailFakeForInterfaces : IItemDetail
    {
        public string Message { get; }

        public ItemDetailFakeForInterfaces(string message, params string[] args)
        {
            Message = message;

            if (string.IsNullOrWhiteSpace(Message)) return;

            for (var i = 0; i < args.Length; i++)
            {
                Message = Message.Replace("{" + i + "}", args[i]);
            }
        }

        public override string ToString() => Message;
    }
}