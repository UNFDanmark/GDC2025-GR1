using UnityEngine;

public class Pistol : MonoBehaviour, IInteractable
{
    
    public void Interact(int input, GameObject interactor)
    {
        interactor.transform.parent.GetComponent<InventoryManager>().ChangeGunData(true);
        Destroy(gameObject);
    }
}
