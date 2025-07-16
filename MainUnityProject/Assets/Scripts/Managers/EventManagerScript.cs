using UnityEngine;
using TMPro;

public class EventManagerScript : MonoBehaviour
{
    [SerializeField] EventData[] eventData;
    [SerializeField] SoundManager soundManager;
    [SerializeField] InventoryManager PlayerInv;
    [SerializeField] EarPieceGuy EPG;
    [SerializeField] TextMeshProUGUI objectiveText;
    

    public void PlayEvent(string Event)
    {
        for (int i = 0; i < eventData.Length; i += 1)
        {
            if (eventData[i].EventName == Event)
            {
                
                if (eventData[i].PlaySound)
                {
                    soundManager.playSound(eventData[i].Sound);
                }

                if (eventData[i].ChangeInventory)
                {
                    PlayerInv.inventoryState = eventData[i].Inventory;
                }

                if (eventData[i].ChangeObjective)
                {
                    objectiveText.text = eventData[i].NewObjective;
                }

                if (eventData[i].EPGTalks)
                {
                    EPG.EPGDialogProgression++;
                    EPG.HeTalks();
                }

                if (eventData[i].ToggleObjectVisibility)
                {
                    eventData[i].Object.SetActive(!eventData[i].Object.activeSelf);
                }
                break;
            }
        }
    }
}
