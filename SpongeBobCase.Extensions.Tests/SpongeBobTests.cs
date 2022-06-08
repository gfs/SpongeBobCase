namespace SpongeBobCase.Extensions.Tests;

[TestClass]
public class SpongeBobTests
{
    [DataRow("lower case string","LoWeR cAsE sTrInG")]
    [DataRow("UPPER CASE STRING","UpPeR cAsE sTrInG")]
    [DataRow("Does this look right to you?","DoEs ThIs LoOk RiGhT tO yOu?")]
    [DataTestMethod]
    public void CurrentCultureTests(string input, string expected)
    {
        Assert.AreEqual(expected, input.ToSpongeBobCase());
    }
}