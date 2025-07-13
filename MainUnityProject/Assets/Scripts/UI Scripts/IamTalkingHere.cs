using System;
using System.Collections;
using System.IO;
using UnityEngine;
using TMPro;

public class IamTalkingHere : MonoBehaviour, IInteractable
{

    [SerializeField] string[] dialog1;
    [SerializeField] GameObject dialogUI;
    [SerializeField]GameObject btnUI, obj;
    [SerializeField]float delay, countdown;

    
    public bool talking, Bdialog1;
    TextMeshProUGUI dialogText;
    int currentDialog;
    
    
    public void Interact(int input, GameObject Obj)
    {

        obj = Obj;
        obj.transform.parent.GetComponent<movementscript>().enabled = false;
        obj.transform.parent.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        obj.transform.parent.GetComponent<CameraMovementScript>().enabled = false;
        obj.GetComponent<IInteractor>().enabled = false;


        talking = true;
        btnUI.SetActive(false);
        dialogUI.SetActive(true);
        dialogText = dialogUI.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();

        currentDialog = 0;
        
        if (input == 0)
        {
            Bdialog1 = true;
        }
        else if (input == 1)
        {
            
        }
        

    }

    void Update()
    {

        if (talking)
        {
            if (Bdialog1)
            {
                if (currentDialog == dialog1.Length)
                {
                    Bdialog1 = false;
                    talking = false;
                    dialogUI.SetActive(false);
                    obj.transform.parent.GetComponent<movementscript>().enabled = true;
                    obj.transform.parent.GetComponent<CameraMovementScript>().enabled = true;
                    obj.GetComponent<IInteractor>().enabled = true;
                }
                else if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    print("test");
                    currentDialog++;
                }
                dialogText.SetText(dialog1[currentDialog]);
            }
        }
    }
    
    public void ShowUI(GameObject BtnUI)
    {
        btnUI = BtnUI;
        if(!talking) btnUI.SetActive(true);
    }
}
