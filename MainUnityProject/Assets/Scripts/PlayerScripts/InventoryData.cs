using UnityEngine;
[System.Serializable]
public class InventoryData
{
    public bool hasGun;
    public bool isequals(InventoryData other)
    {
        if (hasGun == other.hasGun)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}