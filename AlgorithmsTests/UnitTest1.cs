using Xunit;

namespace AlgorithmsTests;

public class UnitTest1
{
    [Fact]
    public void AddFirstElementTests()
    {
        //arrange 
        var expectedCurrent = 1488;
        LinkedList linkedList = new LinkedList();
        LinkedListElement linkedListElement = new LinkedListElement();
        linkedListElement.Value = expectedCurrent;
        //act
        linkedList.AddFirstElement(linkedListElement);
        var actualCurrent = linkedList.Head.Value;
        //assert
        Assert.Equal(expectedCurrent, actualCurrent);
    }
}
