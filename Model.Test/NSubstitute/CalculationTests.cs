﻿using NSubstitute;
using NUnit.Framework;

namespace Model.Tests.NSubstitute
{
    [TestFixture]
    public class CalculationTests
    {
        [Test]
        public void GetName_ShouldGetValueFromBusinessContext()
        {
            var businessContext = Substitute.For<IBusinessContext>();
            var calculation = new Calculation(businessContext);
            string expectedName = "foo";
            businessContext.GetTransalation(calculation, nameof(Calculation.Name)).Returns(expectedName);

            var actualName = calculation.Name;

            businessContext.Received(1).GetTransalation(calculation, nameof(Calculation.Name));
            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void SetName_ShouldPassValueToBusinessContext()
        {
            var businessContext = Substitute.For<IBusinessContext>();
            var calculation = new Calculation(businessContext);

            var expectedName = "foo";
            calculation.Name = expectedName;

            businessContext.Received(1).SetTranslation(calculation, nameof(Calculation.Name), expectedName);
        }
    }
}