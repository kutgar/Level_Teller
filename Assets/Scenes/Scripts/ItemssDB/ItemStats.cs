using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ItemStats 
{
    public string Name;
    public int Strength;
    public int Hp;
    public int Shield;

    public override string ToString()
    {
        return Name+"|" + Strength + "|" + Hp + "|" + Shield + "|";
    }
}
