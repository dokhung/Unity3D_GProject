using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap4 : MonoBehaviour
{
   public GameObject punchPrefab;
   public List<GameObject> punchObjectPool;
   private GameObject obj;
   public Transform Target;

   private void Start()
   {
      StartCoroutine(PunchObject());
   }

   private IEnumerator PunchObject()
   {
      while (true)
      {
         if (obj == null)
         {
            obj = Instantiate(punchPrefab, transform.position, transform.rotation);
            obj.SetActive(false);
         }
         else
         {
            obj.SetActive(false);
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
         }

         yield return new WaitForSeconds(2f);

         obj.SetActive(true);

         // Set the initial position and rotation
         Vector3 initialPosition = obj.transform.position;
         Quaternion initialRotation = obj.transform.rotation;

         float elapsedTime = 0f;
         float duration = 2f;

         while (elapsedTime < duration)
         {
            obj.transform.position = Vector3.MoveTowards(initialPosition, Target.transform.position, (elapsedTime / duration) * Vector3.Distance(initialPosition, Target.transform.position));
            obj.transform.rotation = Quaternion.Slerp(initialRotation, Target.transform.rotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;

            yield return null;
         }

         obj.SetActive(false);

         yield return new WaitForSeconds(2f);
      }
   }
}
