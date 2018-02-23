namespace ANC.Sales.Web.Mvc.Configuration.Contracts
{
    /// <summary>
    /// This interface provides all external routes and implements ICommomConfiguration
    /// to ensure value setup at instanciation 
    /// </summary>
    public interface IExternalRouteConfiguration : ICommomConfiguration
    {
        string AFirstAPI { get; set; }
        string ASecondAPI { get; set; }
        string AnotherAPI { get; set; }
    }   
}