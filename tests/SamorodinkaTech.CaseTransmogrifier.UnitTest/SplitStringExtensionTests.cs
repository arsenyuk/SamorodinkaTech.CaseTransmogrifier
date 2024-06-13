namespace SamorodinkaTech.CaseTransmogrifier.UnitTests;

[TestClass]
public class SplitStringExtensionTests
{

    [DataTestMethod]
    //[DataRow("1_aA", "1aa")]
    [DataRow("POSVersion", "posVersion")]
    public void ParseCase_DataTest(string source, string expected)
    {
        var actual = source.ParseCase().ApplyCamelCase().JoinToFontCase();

        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow("1 aA", "1_aA")]
    [DataRow("Empl ID", "Empl_ID")]
    public void SplitBySpace_DataTest(string source, string expected)
    {
        var actual = source.SplitBySpace().JoinToSnake();

        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow("\r", 1)]
    [DataRow("\n", 1)]
    [DataRow("\n\r", 2)]
    [DataRow("\r\n\n", 2)]
    [DataRow("\r\n\r\n", 2)]
    [DataRow("\r\n\r\n\r", 3)]
    [DataRow("\r\n\r\n\n", 3)]
    public void SplitByNewline_DataTest(string source, int expectedCount)
    {
        var actualCount = source.SplitByNewline().Length;

        Assert.AreEqual(expectedCount + 1, actualCount);
    }

    [DataTestMethod]
    [DataRow("1_aA", "1_aA")]
    [DataRow("1 aA", "1_aA")]
    public void SplitByStandartSymbolSets_DataTest(string source, string expected)
    {
        var actual = source.SplitByStandartSymbolSets().JoinToSnake();

        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow("aA", "AA")]
    [DataRow("POSVersion", "PosVersion")]
    [DataRow("EmplID", "EmplId")]
    public void SplitByCase_DataTest(string source, string expected)
    {
        var actual = source.SplitByCase().ApplyTitleCase().JoinToFontCase();

        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow("1a", false)]
    [DataRow("11", false)]
    [DataRow("aa", true)]
    public void ComposedOfOnlyLetters_DataTest(string source, bool expected)
    {
        var actual = source.ConsistsOfLetters();

        Assert.AreEqual(expected, actual);
    }
}
