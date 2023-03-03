using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    [SerializeField] private int _maxStackCount;

    public int MaxStackCount => _maxStackCount;
}
