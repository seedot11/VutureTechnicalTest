using NUnit.Framework;

namespace WebinarRegistration.Tests.Services
{
    [TestFixture]
    public class DataMaskTests
    {
        [Test]
        [TestCase("Adam", ExpectedResult = "A---")]
        [TestCase("Ben", ExpectedResult = "B--")]
        [TestCase("Frederick", ExpectedResult = "F--------")]
        public string ValidateAsciiNames(string input)
        {
            return WebinarRegistration.Services.Helpers.HtmlHelpers.MaskPersonalData(input);
        }

        [Test]
        [TestCase("Šliževičiūtė", ExpectedResult = "Š-----------")]
        [TestCase("履带式车辆", ExpectedResult = "履----")]
        public string ValidateUnicodeNames(string input)
        {
            return WebinarRegistration.Services.Helpers.HtmlHelpers.MaskPersonalData(input);
        }

        [Test]
        [TestCase("Jean Claude", ExpectedResult = "J--- C-----")]
        public string ValidateSplitNames(string input)
        {
            return WebinarRegistration.Services.Helpers.HtmlHelpers.MaskPersonalData(input);
        }
    }
}
