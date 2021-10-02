using PaymentContext.Common.Commands;

namespace PaymentContext.Common.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
         ICommandResult Handle(T command);
    }
}