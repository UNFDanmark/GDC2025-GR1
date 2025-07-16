using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public interface IInteractable
{
    public void Interact(GameObject interactor);

}

public class IInteractor : MonoBehaviour
{
    public float interactRange;
    public CanvasManager canvasManager;
    
    void Update()
    {
        
        
        if (Physics.Raycast(transform.position, transform.forward, out var hit, interactRange))
        {
            if (hit.collider.TryGetComponent(out IInteractable interactObj))
            {
                canvasManager.ToggleInteractUI(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactObj.Interact(gameObject);
                }
            }
            else
            {
                canvasManager.ToggleInteractUI(false);
            }
        }
        else
        {
            canvasManager.ToggleInteractUI(false);

           
        }
    }
}
