using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : Item
{
   // 사용의미 한가지로는 먹으면 사라지게 한다. 
   // 아이템을 먹으면 인벤토리에 보내는 것과 
   // 인벤토리에 있는 이 스크립트의 아이템을 사용하기 위한 스크립트를 분리하라
   

   


   public override void UseItem()
   {
      Control.Instance.Player_SpeedUp_UseItem();
   }


   public SpeedUpItem(string name, int index, int count, int type) : base(name, index, count, type)
   {
      
   }
}
