namespace Pepsi.Tests;

public class UnitTest1
{
    [Fact]
    public void AdditionTest()
    {
        var result = 2 + 3;
        Assert.Equal(5, result);
    }

    [Fact]
    public void IsTrueTest()
    {
        var condition = 1 + 1 == 2;
        Assert.True(condition);
    }

    [Fact]
    public void NotNullTest()
    {
        var obj = new object();
        Assert.NotNull(obj);
    }


    [Fact]
    public void StringEqualityTest()
    {
        var expected = "hello";
        var actual = "hello";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CollectionContainsTest()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };
        Assert.Contains(3, list);
    }

    [Fact]
    public void MultipleConditionsTest()
    {
        var x = 5;
        var y = 10;
        Assert.True(x < y);
        Assert.True(y % 2 == 0);
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(2, 2, 4)]
    [InlineData(3, 3, 6)]
    public void AdditionTheoryTest(int a, int b, int expected)
    {
        var result = a + b;
        Assert.Equal(expected, result);
    }
}
