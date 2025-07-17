using UnityEngine;
using TMPro;
[System.Serializable]
public class ConversationData
{

    
    public DialogueData[] dialogue;

    public InventoryData inventoryState;
    
    public int interactoption;
    
    public TMP_FontAsset fallbackfont;
    public GameObject fallbackdialogBox;
    
}
