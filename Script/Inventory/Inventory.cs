using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

// Inventory 클래스
public class Inventory : Singleton<Inventory>
{
   public GameObject OverInventoryText;
   public GameObject NotItemText;
   public List<Slot> Slots = new List<Slot>();
   public AudioClip OverItem;
   private AudioSource OverItemSource;

   private void Start()
   {
      OverItemSource = gameObject.AddComponent<AudioSource>();
   }

   public void Registration(Item item)
   {
      int slotIndex = AddItemToSlot(item);

      // 아이템이 성공적으로 슬롯에 등록된 경우에만 아이템을 인벤토리에 추가
      if (slotIndex != -1)
      {
         SetInvenSlot(item, slotIndex, item.Count);
      }
   }

   private int AddItemToSlot(Item item)
   {
      // // 인벤토리에 이미 같은 아이템이 있는지 확인
      // for (int i = 0; i < Slots.Count; i++)
      // {
      //    if (Slots[i].item != null && Slots[i].item.name == item.name)
      //    {
      //       // 이미 존재하는 아이템이면 개수를 증가시킴
      //       Slots[i].item.Count += item.Count;
      //       return i; // 존재하는 슬롯의 인덱스 반환
      //    }
      // }

      // 존재하지 않는 경우, 빈 슬롯에 아이템을 등록하고 인덱스를 반환
      for (int i = 0; i < Slots.Count; i++)
      {
         if (Slots[i].IsEmpty())
         {
            
            Slots[i].SetItem(item, item.Count);
            return i; // 아이템이 등록된 슬롯의 인덱스 반환
         }
      }

      OverInventoryText.SetActive(true);
      Invoke("TimeWarrning", 2f);
      return -1; // 아이템이 등록되지 못한 경우 -1 반환
   }

   public void SetInvenSlot(Item item, int index, int count)
   {
      // 슬롯의 아이템을 인벤토리의 몇 번 칸에 저장할지를 결정하는 함수
      if (index >= 0 && index < Slots.Count)
      {
         Slots[index].SetItem(item, count);
      }
      else
      {
         Debug.LogError("잘못된 슬롯 인덱스: " + index);
      }
   }

   // 인벤토리가 꽉차서 더이상 들어가지 않는 다는 오류창.
   public void TimeWarrning()
   {
      OverItemSource.PlayOneShot(OverItem);
      OverInventoryText.SetActive(false);
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Alpha5))
      {
         UseItemInSlot(0);
      }
      if (Input.GetKeyDown(KeyCode.Alpha6))
      {
         UseItemInSlot(1);
      }
      if (Input.GetKeyDown(KeyCode.Alpha7))
      {
         UseItemInSlot(2);
      }
      if (Input.GetKeyDown(KeyCode.Alpha8))
      {
         UseItemInSlot(3);
      }
   }

   private void UseItemInSlot(int slotIndex)
   {
      if (slotIndex >= 0 && slotIndex < Slots.Count)
      {
         Slot targetSlot = Slots[slotIndex];
         //Debug.Log($"사용 슬롯 : "+targetSlot);

         // 해당 슬롯에 아이템이 존재하고, 아이템 사용 가능한 조건을 추가할 수 있습니다.
         if (!targetSlot.IsEmpty())
         {
            // Debug.Log("접근");
            Item itemToUse = targetSlot.item;
            //Debug.Log($"사용하는 아이템이름 : {itemToUse}");

            // 아이템 사용
            itemToUse.UseItem();

            // 아이템 사용 후 슬롯에서 제거
            targetSlot.ClearSlot();
         }
      }
      else
      {
         NotItemText.SetActive(true);
         Invoke("NotItemWarrningFalse",2f);
      }
   }

   public void NotItemWarrningFalse()
   {
      NotItemText.SetActive(false);
   }
}


