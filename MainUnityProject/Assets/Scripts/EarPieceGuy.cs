using System;
using UnityEngine;

public class EarPieceGuy : MonoBehaviour
{
    [SerializeField] ConversationData[] conversations;
    public CanvasManager canvasManager;
    public int EPGDialogProgression;

    void Start()
    {
        HeTalks();
    }
    
    public void HeTalks()
    {
        canvasManager.setDialogueState(true, true);
        canvasManager.startDialogue(conversations[EPGDialogProgression].dialogue, new UIDataManager());
    }
}
