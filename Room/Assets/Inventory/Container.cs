using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    [SerializeField] private List<Stack> _stacks = new();
    [SerializeField] private int _maxStackCount = 10;

    public bool IsFull => _maxStackCount == _stacks.Count;

    public bool ContainsItem(ItemData item)
    {
        foreach (Stack stack in _stacks)
        {
            if (stack.ItemData == item)
            {
                return true;
            }
        }
        return false;
    }

    public bool RemoveItem(ItemData item)
    {
        foreach (Stack stack in _stacks)
        {
            if (stack.ItemData == item)
            {
                _stacks.Remove(stack);
                return true;
            }
        }
        return false;
    }

    public Stack AddStack(Stack stack)
    {
        foreach (Stack iteratorStack in _stacks.ToArray())
        {
            if (iteratorStack.ItemData == stack.ItemData)
            {
                iteratorStack.AddStack(stack);
            }
        }

        if (IsFull && stack.Count > 0)
        {
            return stack;
        }

        if (stack.Count > 0)
        {
            _stacks.Add(stack);
        }
        return null;
    }

    public static Container operator +(Container container, Stack stack)
    {
        container.AddStack(stack);
        return container;
    }
}