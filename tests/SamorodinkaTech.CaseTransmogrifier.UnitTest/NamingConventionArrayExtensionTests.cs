namespace SamorodinkaTech.CaseTransmogrifier.UnitTests;

[TestClass]
public class CaseStyleStringArrayExtensionTests
{
    [TestMethod]
    public void ApplyTitleCase()
    {
        var arr = new[] { "a", "N" };
        arr.ApplyTitleCase();
    }

    [TestMethod]
    public void ApplyLowerCaseTest()
    {
        var arr = new[] { "a", "N" };
        arr.ApplyLowerCase();
    }

    [TestMethod]
    public void ApplyCamelCaseTest()
    {
        var arr = new[] { "a", "N" };
        arr.ApplyCamelCase();
    }

    [TestMethod]
    public void JoinToFontCaseTest()
    {
        var arr = new[] { "a", "N" };
        arr.JoinToFontCase();
    }

    [TestMethod]
    public void JoinToSnakeTest()
    {
        var arr = new[] { "a", "N" };
        arr.JoinToSnake();
    }

    [TestMethod]
    public void JoinToKebabTest()
    {
        var arr = new[] { "a", "N" };
        arr.JoinToKebab();
    }
}
