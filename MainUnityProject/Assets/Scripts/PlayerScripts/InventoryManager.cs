using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public CanvasManager canvasManager;
    public InventoryData inventoryState;

    public void ChangeGunData(bool ShouldHaveGun)
    {
        inventoryState.hasGun = ShouldHaveGun;
        canvasManager.ToggleShootButton(ShouldHaveGun);
    }
}
