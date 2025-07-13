using System;
using System.Collections;
using System.IO;
using UnityEngine;
using TMPro;

public class IamTalkingHere : MonoBehaviour, IInteractable
{

    [SerializeField] string[] dialog;
    [SerializeField] bool iamGuard;
    [SerializeField] GameObject UI, dialogUI;
    [SerializeField]GameObject btnUI, obj;
    public bool showingui, talking;
    [SerializeField]float delay, countdown;
    
    public void Interact(int input, GameObject Obj)
    {

        obj = Obj;
        obj.transform.parent.GetComponent<movementscript>().enabled = false;
        obj.transform.parent.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        obj.transform.parent.GetComponent<CameraMovementScript>().enabled = false;
        
        
        if (input == 1)
        {
            Dialog();
        }
        else if (input == 2)
        {
            if (iamGuard)
            {
                print("water thingy");
            }
        }

    }

    public void ShowUI(GameObject BtnUI)
    {
        btnUI = BtnUI;
        if(!talking) btnUI.SetActive(true);
        showingui = true;
        showingUI();
    }

    void showingUI()
    {
        
        UI.SetActive(true);
        countdown = delay;
        while(showingui)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                showingui = false;
            }
        }
        UI.SetActive(false);
    }

    void Dialog()
    {
        talking = true;
        btnUI.SetActive(false);
        dialogUI.SetActive(true);
        int currentDialog = 0;
        
        TextMeshProUGUI dialogText = dialogUI.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();        
        
        while (talking)
        {
            if (currentDialog == dialog.Length)
            {
                talking = !talking;
                dialogUI.SetActive(false);
            }
            else if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                currentDialog++;
            }
            dialogText.SetText(dialog[currentDialog]);
        }
    }
}
