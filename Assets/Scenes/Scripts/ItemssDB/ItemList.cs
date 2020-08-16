
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemStats;
using System;

[Serializable]
public class ItemList
{

    [SerializeField]
    public List<ItemStats> Items;

    public ItemList()
    {
        Items = new List<ItemStats>();
    }
    public override string ToString()
    {
        string theCollaction = "";
        foreach (var item in Items)
        {
            theCollaction += item.ToString();
        }
        return theCollaction;
    }
}