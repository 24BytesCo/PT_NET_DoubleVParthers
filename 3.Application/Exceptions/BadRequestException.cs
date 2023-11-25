namespace _3.Application.Exceptions;
public class BadRequestException : ApplicationException
{

    public BadRequestException(string message): base(message)
    {
    }

}