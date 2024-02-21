namespace MirrorWaiter.Domain.Exceptions
{
    public class RequiredInfoException: Exception
    {
        public RequiredInfoException(string message) : base(message) { }
    }
}
