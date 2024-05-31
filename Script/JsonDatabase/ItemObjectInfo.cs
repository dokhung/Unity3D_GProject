using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjectInfoList
{
    public List<ItemObjectInfo> ItemList = new List<ItemObjectInfo>();
}
public class ItemObjectInfo
{
    public int Index;
    public int Type;
    public string Name;

    public ItemObjectInfo(int index, int type, string name)
    {
        Index = index;
        Type = type;
        Name = name;
    }
}
