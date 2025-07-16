using System;
using System.Collections;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IamTalkingHere : MonoBehaviour, IInteractable
{

    [SerializeField] ConversationData[] conversations;
    public CanvasManager canvasManager;
    public UIData[] UIdata { get; set; }
    public UIData[] UI_Data;

    void Start()
    {
        UIdata = UI_Data;
    }

    public void Interact(GameObject interactor, int interactoption)
    {
        UIdata = UI_Data;
        
        InventoryData inventoryState = interactor.transform.parent.GetComponent<InventoryManager>().inventoryState;
        
        for (int i = 0; i < conversations.Length; i += 1)
        {
            if (conversations[i].inventoryState.isequals(inventoryState) && interactoption == conversations[i].interactoption)
            {
                canvasManager.setDialogueState(true, false);
                canvasManager.startDialogue(conversations[i].dialogue);
                break;
            }
            
        }

    }
    
}
