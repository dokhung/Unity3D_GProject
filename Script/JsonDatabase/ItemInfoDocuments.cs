using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfoDocuments : MonoBehaviour
{
    // 타입의 대한 분류
    public int type;
    public int count;
    public int index;

    public void SetInfo(ItemObjectInfo info)
    {
        type = info.Type;
        
        
    }
}
