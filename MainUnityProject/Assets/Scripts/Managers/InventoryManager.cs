using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventoryData inventoryState;

    public void ChangeGunData(bool ShouldHaveGun)
    {
        inventoryState.hasGun = ShouldHaveGun;
    }
}
