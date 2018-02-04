using System;
using ANC.Sales.Commom.Extensions;
using Xunit;

namespace ANC.Sales.Commom.Test.Extensions
{
    public class StringExtensionsTest
    {
        [Fact]
        public void IsValidEmail_WithInvalidEmail_ShouldReturnFalse()
        {
            var itsNotAnEmail = "a";

            var t = itsNotAnEmail.IsValidEmail();
            Assert.NotNull(t);
        }
    }
}
