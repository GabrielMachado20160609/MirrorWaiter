﻿namespace MirrorWaiter.Domain.Exceptions
{
    public class AlreadyExistsException: Exception
    {
        public AlreadyExistsException(string message) : base(message) { }
    }
}
