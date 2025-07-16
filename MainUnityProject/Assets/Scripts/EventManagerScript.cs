using UnityEngine;

public class EventManagerScript : MonoBehaviour
{
    public EventData[] eventData;
    [SerializeField] SoundManager soundManager;
    [SerializeField] InventoryManager PlayerInv;

    void PlayEvent(string Event)
    {
        for (int i = 0; i < eventData.Length; i += 1)
        {
            if (eventData[i].Event == Event)
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
            
                }
                break;
            }
        }
    }
}
