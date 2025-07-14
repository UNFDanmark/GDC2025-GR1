using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

interface IInteractable
{
    public void Interact(int input, GameObject obj)
    {
        
    }

    public void ShowUI(GameObject[] BtnUI, GameObject[] TextUI)
    {
        
    }

    
    
}

public class IInteractor : MonoBehaviour
{
    public float interactRange;
    [SerializeField]GameObject[] ButtonUI, TextUI;
    
    
    void Update()
    {
        
        
        if (Physics.Raycast(transform.position, transform.forward, out var hit, interactRange))
        {
            if (hit.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                
                interactObj.ShowUI(ButtonUI, TextUI);
                
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactObj.Interact(0, gameObject);
                }
                else if (Input.GetKeyDown(KeyCode.F))
                {
                    interactObj.Interact(1, gameObject);
                }
            }
        }
        else
        {
            foreach (var btn in ButtonUI)
            {
                btn.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            }
            foreach (var txt in TextUI)
            {
                txt.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            }
        }
    }
}
