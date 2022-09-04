
using Algorithms;

public static class Program
{
    public static void Main()
    {
        var virtualMemory = new VirtualMemory();

        var head = CreateNewLinkedList(virtualMemory, 100);

        AddNewNodeInTail(virtualMemory, head, 200);
        virtualMemory.Alloc(1);
        virtualMemory.Alloc(3);
        AddNewNodeInTail(virtualMemory, head, 400);
        virtualMemory.Alloc(2);
        AddNewNodeInTail(virtualMemory, head, 300);
        virtualMemory.Alloc(4);
        AddNewNodeInTail(virtualMemory, head, 500);
        virtualMemory.Alloc(7);

        head = DeleteNodeByIndex(virtualMemory, head, 0);
        head = DeleteNodeByIndex(virtualMemory, head, 3);
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


    public static int DeleteNodeByIndex(VirtualMemory virtualMemory, int headNodePoint, int index)
    {
        if (index == 0)
        {
            int newHeadPoint = virtualMemory.GetData(headNodePoint, 1);
            virtualMemory.Free(headNodePoint);
            return newHeadPoint;
        }
        else
        {
            var tempNodePoint = headNodePoint;
            int nextNodePoint;
            int previousNodePoint = 0;
            int deletedNodeNext = 0;
            for (int i = 0; i < index + 1; i++)
            {
                nextNodePoint = virtualMemory.GetData(tempNodePoint, 1);
                if (i + 1 == index)
                {
                    previousNodePoint = tempNodePoint;
                }

                tempNodePoint = nextNodePoint;

                if (i == index)
                {
                    if (nextNodePoint == -3)
                    {
                        virtualMemory.SetData(previousNodePoint, 1, -3);
                        return headNodePoint;
                    }
                    deletedNodeNext = nextNodePoint;
                }
            }
            virtualMemory.SetData(previousNodePoint, 1, deletedNodeNext);
            return headNodePoint;
        }
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