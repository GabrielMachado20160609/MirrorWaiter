﻿namespace MirrorWaiter.Domain.Exceptions
{
    public class ItemNotFoundException: Exception
    {
        public ItemNotFoundException(string message) : base(message) { }
    }
}