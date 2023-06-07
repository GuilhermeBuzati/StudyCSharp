[Serializable]
public class HandlerException : Exception
{
	public HandlerException() { }
	public HandlerException(string message) : base("Throwing Exception --> " + message) { }
	public HandlerException(string message, Exception inner) : base(message, inner) { }
	protected HandlerException(
	  System.Runtime.Serialization.SerializationInfo info,
	  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}