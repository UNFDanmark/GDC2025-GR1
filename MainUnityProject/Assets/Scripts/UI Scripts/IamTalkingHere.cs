using System;
using System.Collections;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IamTalkingHere : MonoBehaviour, IInteractable
{

    [SerializeField] string[] dialogue;
    [SerializeField] GameObject dialogUI;
    [SerializeField]GameObject btnUI, obj;
    [SerializeField]float delay, countdown;

    
    public bool talking, Bdialog1;
    TextMeshProUGUI dialogText;
    int currentDialog;
    public CanvasManager canvasManager;
    
    
    public void Interact(int input, GameObject Obj)
    {
        canvasManager.setDialogueState(true);
        canvasManager.startDialogue(dialogue);
        


        /*talking = true;
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
        */

    }

    void Update()
    {

        if (talking)
        {
            if (Bdialog1)
            {
                if (currentDialog == dialogue.Length)
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
                dialogText.SetText(dialogue[currentDialog]);
            }
        }
    }
    
    public void ShowUI(GameObject[] BtnUI, GameObject[] TxtUI)
    {
        
        if(!talking)
        {
            foreach (var btn in BtnUI)
            {
                btn.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            }
            foreach (var txt in TxtUI)
            {
                txt.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            }
        }
    }
}
