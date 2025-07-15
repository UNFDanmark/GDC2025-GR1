using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public interface IInteractable
{
    public void Interact(int input, GameObject obj);

    public void ShowUI(GameObject[] BtnUI, GameObject[] TextUI)
    {
        
    }

    
    
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
                canvasManager.ToggleInteractUI(true);
                //interactObj.ShowUI(ButtonUI, TextUI);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactObj.Interact(0, gameObject);
                }
                else if (Input.GetKeyDown(KeyCode.F))
                {
                    interactObj.Interact(1, gameObject);
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

            // foreach (var btn in ButtonUI)
            // {
            //     btn.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            // }
            // foreach (var txt in TextUI)
            // {
            //     txt.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            // }
        }
    }
}
