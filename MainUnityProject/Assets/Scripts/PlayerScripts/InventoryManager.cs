using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public CanvasManager canvasManager;
    public InventoryData inventoryState;
    
    void Update()
    {
        if (inventoryState.hasGun)
        {
            canvasManager.ToggleShootButton(true);
        }
        else
        {
            canvasManager.ToggleShootButton(false);
        }
    }
}
