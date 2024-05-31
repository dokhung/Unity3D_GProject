using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTrap : MonoBehaviour
{
   private float speed = 100;
   private Quaternion originalRotation;
   private void OnCollisionEnter(Collision other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         Rigidbody PlayerRigid = other.rigidbody;
         Control.Instance.isMove = false;
         transform.Rotate(-90,0,0);
         PlayerRigid.AddForce(0,0,-20,ForceMode.Impulse);
         Invoke("STOP",1.5f);
         Invoke("Init",2f);
      }
   }

   public void STOP()
   {
      Control.Instance.isMove = true;
   }

   public void Init()
   {
      transform.rotation = originalRotation;;
   }
}
