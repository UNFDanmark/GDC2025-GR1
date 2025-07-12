using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class IamTalkingHere : MonoBehaviour, IInteractable
{

    [SerializeField] string[] dialog;
    [SerializeField] bool iamGuard;
    [SerializeField] GameObject UI;
    public bool showingui, talking;
    float delay, countdown;
    
    public bool isNPC;
    public void Interact(int input, GameObject obj)
    {

   
        GetComponent<movementscript>().enabled = false;
        
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

    public void ShowUI()
    {
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
        while (talking)
        {
            
        }
    }
}
