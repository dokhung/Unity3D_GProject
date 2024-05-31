using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class JsonStart : MonoBehaviour
{
    private string filePath = "";

    public Dictionary<AllEnum.ItemType, ItemObjectInfo>
        AllBaseInfo = new Dictionary<AllEnum.ItemType, ItemObjectInfo>();

    private void Start()
    {
        
        
        //Json 원본 만들때 메소드
        //NewJsonSave();
        
        
        //Json 원본 만들 후 사용 
        LoadJson();
    }
    // Json 원본만들기
    public void NewJsonSave()
    {
        ItemObjectInfoList ItemList = new ItemObjectInfoList();
        ItemList.ItemList.Add(new ItemObjectInfo(1,1,"SpeedUpItem"));
        ItemList.ItemList.Add(new ItemObjectInfo(2,2,"JumpPowerUpItem"));
        ItemList.ItemList.Add(new ItemObjectInfo(3,3,"JumpCountUpItem"));
        ItemList.ItemList.Add(new ItemObjectInfo(4,4,"LifeUpItem"));

        string JsonData = JsonConvert.SerializeObject(ItemList, Formatting.Indented);
        filePath = Path.Combine(Application.dataPath, "ItemJsonData.json");
        File.WriteAllText(filePath,JsonData);
        Debug.Log("Make Json OK");
    }

    public void LoadJson()
    {
        filePath = Path.Combine(Application.dataPath, "ItemJsonData.json");
        string JsonData = File.ReadAllText(filePath);
        ItemObjectInfoList itemList = JsonConvert.DeserializeObject<ItemObjectInfoList>(JsonData);
        for (int i = 0; i < itemList.ItemList.Count; i++)
        {
            AllBaseInfo.Add((AllEnum.ItemType)itemList.ItemList[i].Type,itemList.ItemList[i]);
            
            
            // //아이템 번호
            // Debug.Log(itemList.ItemList[i].Type);
            // //아이템 이름
            // Debug.Log((AllEnum.ItemType)itemList.ItemList[i].Type);
        }
        //Debug.Log("Load Json OK");
    }
}
