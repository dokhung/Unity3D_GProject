using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUpItem : Item
{
    public override void UseItem()
    {
        Control.Instance.Player_JumpPowerUp_UseItem();
    }
    
    public JumpPowerUpItem(string name, int index, int count, int type) : base(name, index, count, type)
    {
    }
}
