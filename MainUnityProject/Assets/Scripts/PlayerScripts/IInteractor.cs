using UnityEngine;


interface IInteractable
{
    public void Interact(int input, GameObject obj)
    {
        
    }

    public void ShowUI()
    {
        
    }
}

public class IInteractor : MonoBehaviour
{
    [SerializeField]public float interactRange;
    [SerializeField] GameObject ButtonUI;
    
    
    void Update()
    {
        ButtonUI.SetActive(false);
        
        if (Physics.Raycast(transform.position, transform.forward, out var hit, interactRange))
        {
            if (hit.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                ButtonUI.SetActive(true); 
                print("AAAAAAAAAAAAAAA2");
                
                interactObj.ShowUI();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactObj.Interact(1, transform.parent.gameObject);
                }
                else if (Input.GetKeyDown(KeyCode.F))
                {
                    interactObj.Interact(2, transform.parent.gameObject);
                }
            }
        }
    }
}
