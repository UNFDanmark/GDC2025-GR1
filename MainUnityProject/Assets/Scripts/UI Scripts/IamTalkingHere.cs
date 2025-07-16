using System;
using System.Collections;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IamTalkingHere : MonoBehaviour, IInteractable
{

    [SerializeField] ConversationData[] conversations;
    [SerializeField] ConversationData[] shotConversations;
    public CanvasManager canvasManager;
    
    
    public void Interact(GameObject interactor)
    {
        InventoryData inventoryState = interactor.transform.parent.GetComponent<InventoryManager>().inventoryState;
        
        for (int i = 0; i < conversations.Length; i += 1)
        {
            if (conversations[i].inventoryState.isequals(inventoryState))
            {
                canvasManager.setDialogueState(true, conversations[i].isTalkingToEarPieceGuy);
                canvasManager.startDialogue(conversations[i].dialogue);
                break;
            }
            
        }



        

    }

    public void ShootGun(GameObject interactor)
    {
        print("I am shot");
        conversations = shotConversations;
        



    }
    
    
}
