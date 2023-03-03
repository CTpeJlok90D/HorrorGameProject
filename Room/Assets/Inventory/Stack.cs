using System;
using UnityEngine;

[Serializable]
public class Stack
{
    [SerializeField] private ItemData _itemData;
    [SerializeField] private int _count;

    public Stack(ItemData item, int count)
    {
        _itemData = item;
        Count = count;
    }

    public ItemData ItemData => _itemData;
    public bool IsEmpty => _count == 0;

    public int Count
    {
        get
        {
            return _count;
        }
        set
        {
            _count = Mathf.Clamp(value, 0, _itemData.MaxStackCount);
        }
    }

    public void AddStack(Stack stack)
    {
        int difference = Count + stack.Count;
        Count += stack.Count;
        stack.Count = difference - Count;
    }

    public static bool IdentityStack(Stack stack1, Stack stack2)
    {
        if (stack1._itemData != stack2.ItemData)
        {
            Debug.LogError(new Exception($"Invalid stack sum operation. Different stack item types -> {stack1.ItemData.name} and {stack2.ItemData.name}"));
            return false;
        }
        return true;
    }

    public static SumResult operator +(Stack stack1, Stack stack2)
    {
        if (IdentityStack(stack1, stack2) == false)
        {
            return new SumResult()
            {
                Result = stack1,
                Remains = stack2
            };
        }

        ItemData item = stack1.ItemData;

        return new SumResult()
        {
            Result = new Stack(item, stack1.Count + stack2.Count),
            Remains = new Stack(item, stack1.Count + stack2.Count - item.MaxStackCount)
        };
    }

    public static Stack operator +(Stack stack1, int value)
    {
        return new Stack(stack1.ItemData, stack1.Count + value);
    }

    public struct SumResult
    {
        public Stack Result;
        public Stack Remains;
    }
}
