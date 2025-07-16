using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CanvasManager : MonoBehaviour
{
    public GameObject interactUI;
    public GameObject textBox, textBoxEPG;
    public TextMeshProUGUI textElement;
    public TextMeshProUGUI speakerElement;
    bool inDialogue, skipTextAnim;
    public float letterDelay;
    int pageNumber = 0;
    DialogueData[] currentDialogue;
    public GameObject interactor;
    public GameObject shootButton;

    public void ToggleShootButton(bool isActive)
    {
        if (isActive)
        {
            shootButton.SetActive(true);
        }
        else
        {
            shootButton.SetActive(false);
        }
    }
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

    public void setDialogueState(bool newState, bool EPGisTalking)
    {
        print(newState);
        print(EPGisTalking);
        
        inDialogue = newState;
        ToggleInteractUI(false);

        textBox.SetActive(inDialogue);
        textBoxEPG.SetActive(inDialogue);
        
        interactor.transform.parent.GetComponent<movementscript>().enabled = !inDialogue;
        interactor.transform.parent.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        interactor.transform.parent.GetComponent<CameraMovementScript>().enabled = !inDialogue;
        interactor.GetComponent<IInteractor>().enabled = !inDialogue;

        if (newState && EPGisTalking)
        {
            textBoxEPG.SetActive(true);
            textBox.SetActive(false);
        }
        else if (newState)
        {
            textBoxEPG.SetActive(false);
            textBox.SetActive(true);
        }
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
                    setDialogueState(false, false);
                }
            }
        }
    }
/*
    IEnumerator TextAnim()
    {
        yield return new WaitForSeconds()
    }
    */
}
