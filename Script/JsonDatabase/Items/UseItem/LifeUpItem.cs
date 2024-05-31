using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUpItem : Item
{
    public override void UseItem()
    {
        Control.Instance.LifeUp();
    }
    public LifeUpItem(string name, int index, int count, int type) : base(name, index, count, type)
    {
    }
}
