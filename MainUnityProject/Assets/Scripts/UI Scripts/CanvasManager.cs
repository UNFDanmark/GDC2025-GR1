using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CanvasManager : MonoBehaviour
{
    public GameObject interactUI;
    public GameObject textBox;
    public TextMeshProUGUI textElement;
    public TextMeshProUGUI speakerElement;
    bool inDialogue;
    int pageNumber = 0;
    DialogueData[] currentDialogue;
    public GameObject interactor;
    public void ToggleInteractUI(bool isActive)
    {
        if (inDialogue)
        {
            interactUI.SetActive(false);
        }
        else
        {
            interactUI.SetActive(isActive);
        }
    }

    public void setDialogueState(bool newState)
    {
        inDialogue = newState;
        ToggleInteractUI(false);

        textBox.SetActive(inDialogue);
        
        interactor.transform.parent.GetComponent<movementscript>().enabled = !inDialogue;
        interactor.transform.parent.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        interactor.transform.parent.GetComponent<CameraMovementScript>().enabled = !inDialogue;
        interactor.GetComponent<IInteractor>().enabled = !inDialogue;
    }

    public void startDialogue(DialogueData[] dialogue)
    {
        pageNumber = 0;
        currentDialogue = dialogue;
        displayPage();
    }

    void displayPage()
    {
        textElement.text = currentDialogue[pageNumber].text;
        speakerElement.text = currentDialogue[pageNumber].Speaker;
    }

    void Update()
    {
        if (inDialogue)
        {
            if (Input.GetMouseButtonDown(0))
            {
                pageNumber += 1;
                if (pageNumber < currentDialogue.Length)
                {
                    displayPage();
                }
                else
                {
                    setDialogueState(false);
                }
            }
        }
    }
}
