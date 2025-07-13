using System;
using System.Collections;
using System.IO;
using UnityEngine;
using TMPro;

public class IamTalkingHere : MonoBehaviour, IInteractable
{

    [SerializeField] string[] dialog1;
    [SerializeField] bool iamGuard;
    [SerializeField] GameObject dialogUI;
    [SerializeField]GameObject btnUI, obj;
    public bool talking;
    [SerializeField]float delay, countdown;
    
    public void Interact(int input, GameObject Obj)
    {

        obj = Obj;
        obj.transform.parent.GetComponent<movementscript>().enabled = false;
        obj.transform.parent.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        obj.transform.parent.GetComponent<CameraMovementScript>().enabled = false;


        if (input == 0)
        {
            StartCoroutine(Dialog());
        }
        else if (input == 1)
        {
            
        }
        
        

    }

    IEnumerator Dialog()
    {
        talking = true;
        btnUI.SetActive(false);
        dialogUI.SetActive(true);
        int currentDialog = 0;
        TextMeshProUGUI dialogText = dialogUI.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();        
        
        while (talking)
        {
            if (currentDialog == dialog1.Length)
            {
                talking = !talking;
                dialogUI.SetActive(false);
            }
            else if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                currentDialog++;
            }
            dialogText.SetText(dialog1[currentDialog]);
        }

        yield return new WaitForEndOfFrame();
    }
    
    public void ShowUI(GameObject BtnUI)
    {
        btnUI = BtnUI;
        if(!talking) btnUI.SetActive(true);
    }
}
