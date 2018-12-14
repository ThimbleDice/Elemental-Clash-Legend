using System;

public class MultiplayerException : Exception{

    public MultiplayerException()
    {
    }

    public MultiplayerException(string message)
        : base(message)
    {
    }

    public MultiplayerException(string message, Exception inner)
        : base(message, inner)
    {
    }

}