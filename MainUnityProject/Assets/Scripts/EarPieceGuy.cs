using System;
using UnityEngine;

public class EarPieceGuy : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] ConversationData[] conversations;
    public CanvasManager canvasManager;


    void Start()
    {
        HeTalks();
    }
    
    void HeTalks()
    {
        InventoryData inventoryState = player.GetComponent<InventoryManager>().inventoryState;
        
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
}
