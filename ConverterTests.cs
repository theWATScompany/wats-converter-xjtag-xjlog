using Virinco.WATS.Interface;
using Xunit;
using Xunit.Abstractions;
using WATS.Testing;
using Virinco.WATS.Converter.JTAG;

namespace Virinco.WATS.Converter.JTAG.Tests
{
    // XJLogConverter submits internally (returns null from ImportReport) — use TextConverterTestBase.
    public class ConverterTests : TextConverterTestBase
    {
        public ConverterTests(ITestOutputHelper output) : base(output) { }
        protected override IReportConverter_v2 CreateConverter() => new XJLogConverter();
        // Restrict to .xjlog files only; the Data folder also contains a .xml file that is not a zip archive.
        protected override string FilePattern => "*.xjlog";

        [Fact, Trait("TestMode", "ConvertOnly")]
        public void ConvertOnly_AllFiles() => RunAllFiles();

        [Fact, Trait("TestMode", "ConvertAndValidate")]
        public void ConvertAndValidate_AllFiles() => RunAllFiles(TestMode.ConvertAndValidate);
    }
}
