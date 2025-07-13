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
        obj.GetComponent<movementscript>().enabled = false;
        obj.transform.GetChild(0).GetComponent<CameraMovementScript>().enabled = false;
        obj.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        
        if (input == 1)
        {
            print("guard speak type shi");
            Dialog();
        }
        else if (iamGuard && input == 2)
        {
            print("water thingy");
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
