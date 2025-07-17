using UnityEngine;

public class Pistol : MonoBehaviour, IInteractable
{
    [SerializeField] EventManagerScript eventManager;
    public void Interact( GameObject interactor)
    {
        interactor.transform.parent.GetComponent<InventoryManager>().ChangeGunData(true);
        eventManager.PlayEvent("GunAcquired");
        Destroy(gameObject);
    }
}
