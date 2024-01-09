using System;

namespace MarsRoverApp.Exceptions;
public class RoverLandingException : Exception
{
    public RoverLandingException(string message) : base(message)
    {
    }
}