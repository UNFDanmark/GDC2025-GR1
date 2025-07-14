using UnityEngine;


interface IInteractable
{
    public void Interact(int input, GameObject obj)
    {
        
    }

    public void ShowUI(GameObject BtnUI)
    {
        
    }

    
    
}

public class IInteractor : MonoBehaviour
{
    [SerializeField]public float interactRange;
    [SerializeField] GameObject ButtonUI;
    
    
    void Update()
    {
        
        
        if (Physics.Raycast(transform.position, transform.forward, out var hit, interactRange))
        {
            if (hit.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                
                interactObj.ShowUI(ButtonUI);
                
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactObj.Interact(0, gameObject);
                }
                else if (Input.GetKeyDown(KeyCode.F))
                {
                    interactObj.Interact(1, transform.parent.gameObject);
                }
            }
        }
        else
        {
            ButtonUI.SetActive(false);
        }
    }
}
