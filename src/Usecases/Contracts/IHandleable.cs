namespace Usecases.Contracts
{
    public interface IHandleable<in TIn, out TOut>
    {
        TOut Handle(TIn input);
    }
}
