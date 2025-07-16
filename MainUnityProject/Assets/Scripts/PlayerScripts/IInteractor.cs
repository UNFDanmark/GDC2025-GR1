using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public interface IInteractable
{
    public UIData[] UIdata { get; set; }
    public void Interact(GameObject interactor, int interactoption);

}

public class IInteractor : MonoBehaviour
{
    public float interactRange;
    [SerializeField]GameObject[] ButtonUI, TextUI;
    public CanvasManager canvasManager;
    
    void Update()
    {
        
        
        if (Physics.Raycast(transform.position, transform.forward, out var hit, interactRange))
        {
            if (hit.collider.TryGetComponent(out IInteractable interactObj))
            {
                canvasManager.ToggleInteractUI(true, interactObj.UIdata);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactObj.Interact(gameObject, 0);
                }
                else if (Input.GetKeyDown(KeyCode.F))
                {
                    interactObj.Interact(gameObject, 1);
                }
            }
            else
            {
                canvasManager.ToggleInteractUI(false, new UIData[1]);
            }
        }
        else
        {
            canvasManager.ToggleInteractUI(false, new UIData[1]);

           
        }
    }
}
