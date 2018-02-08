namespace ANC.Sales.Web.Mvc.Configuration.Contracts
{
    /// <summary>
    /// This interface provides a safe way to inject a configuration
    /// At invocation time the implementation constructor must call Validate()
    /// to force default values be declared at ConfigurationSection
    /// </summary>
    public interface ICommomConfiguration
    {
        void Validate();
    }
}