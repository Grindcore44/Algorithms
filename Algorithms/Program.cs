
using Algorithms;

public static class Program
{
    public static void Main()
    {
        var virtualMemory = new VirtualMemory();

        var head = CreateNewLinkedList(virtualMemory, 100);

        AddNewNodeInTail(virtualMemory, head, 200);
        AddNewNodeInTail(virtualMemory, head, 300);
        AddNewNodeInTail(virtualMemory, head, 400);
        virtualMemory.Alloc(1);
        virtualMemory.Alloc(2);
        virtualMemory.Alloc(3);
        virtualMemory.Alloc(4);
        virtualMemory.Alloc(7);
        virtualMemory.WriteLineDataConsole();
    }
    // -3 == null

    public static int CreateNewLinkedList(VirtualMemory virtualMemory, int value)
    {
        var nodePoint = virtualMemory.Alloc(2);
        virtualMemory.SetData(nodePoint, 0, value);
        virtualMemory.SetData(nodePoint, 1, -3);

        return nodePoint;
    }

    public static void AddNewNodeInTail(VirtualMemory virtualMemory, int headNodePoint, int value)
    {
        var nextNodePoint = headNodePoint;
        
        while (true)
        {
            var tempNodePoint = virtualMemory.GetData(nextNodePoint, 1);

            if (tempNodePoint == -3)
            {
                break;
            }
            nextNodePoint = tempNodePoint;
        }
        var newNode = virtualMemory.Alloc(2);
        virtualMemory.SetData(newNode, 0, value);
        virtualMemory.SetData(newNode, 1, -3);
        virtualMemory.SetData(nextNodePoint, 1, newNode);
    }
}

public class LinkedListElement
{
    public int Value { get; set; }
    public LinkedListElement? Next { get; set; }
}

public class LinkedList
{
    public LinkedListElement Head { get; set; }

    public int GetValueByIndex(int index)
    {
        var currentElement = GetLinkedListElementByIndex(index);
        return currentElement.Value;
    }

    public void Insert(int value, int index)
    {

        var element = GetLinkedListElementByIndex(index - 1);
        var element2 = element.Next;
        var newElement = new LinkedListElement
        {
            Value = value,
            Next = element2
        };
        element.Next = newElement;
    }

    public void InsertAfter(int value, LinkedListElement element)
    {
        var element2 = element.Next;
        var newElement = new LinkedListElement
        {
            Value = value,
            Next = element2
        };
        element.Next = newElement;
    }

    private LinkedListElement GetLinkedListElementByIndex(int index)
    {
        var currentElement = Head;
        for (int i = 0; i < index; i++)
        {
            if (currentElement.Next != null)
            {
                currentElement = currentElement.Next;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        return currentElement;
    }

    private void DeleteByIndex(int index)
    {
        LinkedListElement elementBeforeBeingDeleted = GetLinkedListElementByIndex(index - 1);
        LinkedListElement elementToBeDeleted = GetLinkedListElementByIndex(index);
        elementBeforeBeingDeleted.Next = elementToBeDeleted.Next;
    }

    public void AddFirstElement(LinkedListElement element)
    {
        Head.Value = element.Value;
    }

    public void AddLast(LinkedListElement element)
    {
        LinkedListElement currentElement = Head;
        while (true)
        {
            if (currentElement.Next != null)
            {
                currentElement = currentElement.Next;
            }
            else
            {
                currentElement.Next = element;
                break;
            }
        }
    }

}