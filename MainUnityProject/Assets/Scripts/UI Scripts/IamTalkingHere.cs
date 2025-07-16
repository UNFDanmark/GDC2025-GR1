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

   

    public void Interact(GameObject interactor)
    {
        
        canvasManager.setDialogueState(true, false);
        canvasManager.CheckDialogues(conversations, uiDataManager);

    }
    
}
