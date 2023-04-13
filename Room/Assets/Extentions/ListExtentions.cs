using System.Collections.Generic;
using UnityEngine;

public static class ListExtentions
{
    public static T RandomElemet<T>(this List<T> @this)
    {
        return @this[Random.Range(0, @this.Count)];
    }
}
