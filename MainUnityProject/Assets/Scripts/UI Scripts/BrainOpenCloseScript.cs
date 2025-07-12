using System;
using UnityEngine;

public class BrainOpenCloseScript : MonoBehaviour
{
   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Tab))
      {
         GetComponent<Animator>().SetBool("New Bool", !GetComponent<Animator>().GetBool("New Bool"));
      }
   }
}
