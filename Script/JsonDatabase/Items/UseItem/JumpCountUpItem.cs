using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCountUpItem : Item
{
    

    public override void UseItem()
    {
        Control.Instance.Player_JumpCountUp_UseItem();
    }

    public JumpCountUpItem(string name, int index, int count, int type) : base(name, index, count, type)
    {
    }
}
