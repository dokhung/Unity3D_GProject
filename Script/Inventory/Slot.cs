using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    // 슬롯 한 칸의 대해서 아이템을 하나 넣음
    public Item item { get; private set; }

    public Image img;
    public Text countText;

    // 중복의 판단
    public bool IsEmpty()
    {
        return item == null;
    }

    public void SetItem(Item _item, int count)
    {
        this.item = _item;
        img.sprite = item.ItemImage;
        item.Count = count; // 아이템 개수를 설정
        countText.text = item.Count.ToString();
    }
    
    public void ClearSlot()
    {
        item = null;
        img.sprite = null;
        countText.text = string.Empty;
    }
}
