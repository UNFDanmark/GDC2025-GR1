using UnityEngine;

public class Pistol : MonoBehaviour, IInteractable
{
    public void Interact( GameObject interactor, int interactoption)
    {
        interactor.transform.parent.GetComponent<InventoryManager>().ChangeGunData(true);
        Destroy(gameObject);
    }
}
