using UnityEngine;


interface IInteractable
{
    public void Interact()
    {
        
    }

    public void ShowUI()
    {
        
    }
}

public class IInteractor : MonoBehaviour
{
    [SerializeField] float interactRange = 5;
    [SerializeField] GameObject ButtonUI;
    
    
    void Update()
    {
        ButtonUI.SetActive(false);
        
        if (Physics.Raycast(transform.position, transform.forward * interactRange, out var hit))
        {
            if (hit.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                ButtonUI.SetActive(true);
                
                interactObj.ShowUI();
                if (Input.GetKeyDown(KeyCode.E))
                {
                
                }
                else if (Input.GetKeyDown(KeyCode.F))
                {
                
                }
            }
        }
    }
}
