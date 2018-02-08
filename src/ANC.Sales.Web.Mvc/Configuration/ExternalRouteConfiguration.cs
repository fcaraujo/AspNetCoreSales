using System;
using ANC.Sales.Web.Mvc.Configuration.Contracts;
using Microsoft.Extensions.Configuration;

namespace ANC.Sales.Web.Mvc.Configuration
{
    public class ExternalRouteConfiguration : IExternalRouteConfiguration
    {
        #region Private fields

        private IConfigurationSection _configurationSection;

        #endregion Private fields


        #region Ctor
        
        public ExternalRouteConfiguration()
        { }

        public ExternalRouteConfiguration(IConfigurationSection configurationSection)
        {
            _configurationSection = configurationSection 
                                  ?? throw new ArgumentNullException(nameof(configurationSection));

            Validate();
        }

        #endregion Ctor


        #region Configuration Properties

        public string AFirstAPI { get; set; }
        public string ASecondAPI { get; set; }
        public string AnotherAPI { get; set; }

        #endregion Configuration Properties


        #region Public Methods
        
        /// <summary>
        /// When this configuration instance is created, must check if the Configuration Section has the values and bind to properties below
        /// </summary>
        public void Validate()
        {
            // Bind configuration
            _configurationSection.Bind(this);

            // Message when a required property must be provided
            var exceptionMessage = $"Configuration key/value cannot be null. Check appsettings.json configuration section ({_configurationSection.Path}) for parameter below.";
            
            // Validate all properties
            if (string.IsNullOrWhiteSpace(this.AFirstAPI))
            {
                throw new ArgumentNullException(nameof(this.AFirstAPI));
            }
        }

        #endregion Public Methods
    }    
}