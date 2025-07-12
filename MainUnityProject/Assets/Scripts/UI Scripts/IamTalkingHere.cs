using System;
using UnityEngine;

public class IamTalkingHere : MonoBehaviour, IInteractable
{

    [SerializeField] string[] dialoge;
    [SerializeField] bool iamGuard;
    [SerializeField] GameObject UI;
    bool showingui;
    float delay, countdown;
    
    
    public void Interact(int input)
    {
        if (input == 1)
        {
            print("guard speak type shi");
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
}
