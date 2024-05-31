using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    //기본적 정보 셋팅
    
    //이름
    public string Name;
    // 아이템 순서
    public int Index { get; set; } = 0;
    // 아이템 갯수
    public int Count { get; set; } = 0;
    // 이미지
    public Sprite ItemImage;
    
    // 이 아이템이 뭔지 알기위한 타입
    public int Type = 0;
    
    public Item(string name, int index, int count, int type)
    {
        this.Name = name;
        this.Index = index;
        this.Count = count;
        this.Type = type;
    }
    
    

    public virtual void UseItem()
    {
        
    }



}
