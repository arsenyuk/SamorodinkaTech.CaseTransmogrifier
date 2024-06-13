namespace SamorodinkaTech.CaseTransmogrifier.UnitTests;

[TestClass]
public class CaseStyleStringExtensionTests
{
    [TestMethod]
    public void ToTitleCase_CallTest()
    {
        var arr = new[] { "a", "N" };
        arr.ApplyTitleCase();
    }

    [TestMethod]
    public void ToLowerCase_CallTest()
    {
        var arr = new[] { "a", "N" };
        arr.ApplyLowerCase();
    }

    [DataTestMethod]
    [DataRow("", "")]
    [DataRow("Public", "public")]
    [DataRow("localArr", "localArr")]
    [DataRow("GM_PARAMETER", "gmParameter")]
    [DataRow("EmplID", "emplId")]
    [DataRow("GmNsiReferenceRecordDataAreaIdReference", "gmNsiReferenceRecordDataAreaIdReference")]
    public void CamelCase_DataTest(string source, string actual)
    {
        Assert.AreEqual(actual, source.CamelCase());
    }

    [DataTestMethod]
    [DataRow("", "")]
    [DataRow("EmplID", "EmplId")]
    public void PascalCase_DataTest(string source, string actual)
    {
        Assert.AreEqual(actual, source.PascalCase());
    }

    [DataTestMethod]
    [DataRow("", "")]
    [DataRow("bankCurrencyPair", "BankCurrencyPair")]
    public void ArrayToPascalCase_DataTest(string source, string actual)
    {
        var arr = source.ParseCase();
        Assert.AreEqual(actual, arr.PascalCase());
    }

    [DataTestMethod]
    [DataRow("", "")]
    [DataRow("EmplID", "empl_id")]
    public void SnakeCase_DataTest(string source, string actual)
    {
        Assert.AreEqual(actual, source.SnakeCase());
    }

    [DataTestMethod]
    [DataRow("", "")]
    [DataRow("EmplID", "empl-id")]
    public void KebabCase_DataTest(string source, string actual)
    {
        Assert.AreEqual(actual, source.KebabCase());
    }
}
