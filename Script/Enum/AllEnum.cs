using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnum : MonoBehaviour
{
    public enum ItemType
    {
        //종류
        SpeedUp = 1,
        JumpCountUp,
        JumpPowerUp,
        LifeUp,
        
        // 끝
        // 사용 이유 : Random.Range(1,(int)AllEnum.ItemType.End);
        End,
    }
}
