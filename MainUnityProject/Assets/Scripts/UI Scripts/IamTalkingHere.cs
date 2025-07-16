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
    [SerializeField] UIDataManager uiDataManager;

   

    public void Interact(GameObject interactor, int interactoption)
    {
        
        InventoryData inventoryState = interactor.transform.parent.GetComponent<InventoryManager>().inventoryState;
        
        for (int i = 0; i < conversations.Length; i += 1)
        {
            if (conversations[i].inventoryState.isequals(inventoryState))
            {
                canvasManager.setDialogueState(true, false);
                canvasManager.startDialogue(conversations[i].dialogue, uiDataManager);
                break;
            }
            
        }

    }
    
}
