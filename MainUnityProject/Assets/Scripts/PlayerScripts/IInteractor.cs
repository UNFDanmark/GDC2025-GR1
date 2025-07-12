using UnityEngine;


interface IInteractable
{
    public bool isNPC;
    public void Interact(int input, GameObject obj)
    {
        
    }

    public void ShowUI()
    {
        
    }

    public GameObject gimmeyoGameObj()
    {
        return GameObject()
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
                
                if (interactObj.isNPC)
                {
                    if(!interactObj.)
                    ButtonUI.SetActive(true);
                }
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
