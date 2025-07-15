using UnityEngine;

public class Pistol : MonoBehaviour, IInteractable
{
    
    public void Interact( GameObject interactor)
    {
        interactor.transform.parent.GetComponent<InventoryManager>().ChangeGunData(true);
        Destroy(gameObject);
    }

    public void ShootGun(GameObject interactor)
    {
        throw new System.NotImplementedException();
    }
}
