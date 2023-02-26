using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRoom : Room
{
    protected void Awake()
    {
        GenerateNextRooms(this);
    }
}
