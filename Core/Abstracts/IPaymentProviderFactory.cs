namespace Core.Abstracts
{
    public interface IPaymentProviderFactory
    {
        IPaymentProvider GetProvider(string providerName);
    }
}
