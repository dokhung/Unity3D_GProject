using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetItemInfo : MonoBehaviour
{
   /*
    * 해야 하는것
    * 이넘이랑 제이슨이랑 연결을 해야한다.
    * ItemType이 SpeedUp이면 그것과 연결된 Type을 지정하여 사용한다.
    * 
    */
   public int type;
   public int count;
   public int index;
   private JsonStart JsonData;
   private AllEnum.ItemType ItemType;
   private ItemObjectInfo item;

   private void Start()
   {
      JsonData.LoadJson();
   }

   public void SetEnum()
   {
      switch (ItemType)
      {
         case AllEnum.ItemType.SpeedUp :
            item.Type = (int)AllEnum.ItemType.SpeedUp;
            Debug.Log(ItemType);
            break;
         case AllEnum.ItemType.JumpCountUp :
            item.Type = (int)AllEnum.ItemType.JumpCountUp;
            Debug.Log(ItemType);
            break;
         case AllEnum.ItemType.JumpPowerUp :
            item.Type = (int)AllEnum.ItemType.JumpPowerUp;
            Debug.Log(ItemType);
            break;
         case AllEnum.ItemType.LifeUp :
            item.Type = (int)AllEnum.ItemType.LifeUp;
            Debug.Log(ItemType);
            break;
         default:
            break;
      }
   }
}
