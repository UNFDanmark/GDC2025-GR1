using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CanvasManager : MonoBehaviour
{
    public GameObject interactUI;
    public GameObject textBox, textBoxEPG;
    public TextMeshProUGUI textElement, textElementEPG;
    public TextMeshProUGUI speakerElement;
    bool inDialogue, skipTextAnim, textshown;
    public float letterDelay;
    int pageNumber = 0;
    DialogueData[] currentDialogue;
    public GameObject interactor;
    public GameObject shootButton;
    public SoundManager soundManager;
    public EventManagerScript EventManager;
   

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
        inDialogue = newState;
        ToggleInteractUI(false);

        textBox.SetActive(inDialogue);
        textBoxEPG.SetActive(inDialogue);
        
        interactor.transform.parent.GetComponent<movementscript>().enabled = !inDialogue;
        interactor.transform.parent.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        interactor.transform.parent.GetComponent<CameraMovementScript>().enabled = !inDialogue;
        interactor.GetComponent<IInteractor>().enabled = !inDialogue;

        if (newState)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
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
        
        
        
        speakerElement.text = currentDialogue[pageNumber].Speaker;
        
        if (textBox.activeSelf)
        {
            textElement.text = currentDialogue[pageNumber].text;
            //StartCoroutine(TextAnim(textElement));
        }
        else
        {
            textElementEPG.text = currentDialogue[pageNumber].text;
            //StartCoroutine(TextAnim(textElementEPG));
        }

        textshown = true;

    }

    void Update()
    {
        if (inDialogue)
        {
            if (Input.GetMouseButtonDown(0))
            {
                EventManager.PlayEvent(currentDialogue[pageNumber].PlayEvent); 
                pageNumber += 1;
                if (pageNumber < currentDialogue.Length)
                {
                    if (textshown)
                    {
                        textshown = false;
                        displayPage();
                    }
                    else
                    {
                        skipTextAnim = true;
                    }
                }
                else
                {
                    setDialogueState(false, false);
                }
            }
        }
    }
/*
    public IEnumerator TextAnim(TextMeshProUGUI TextElement)
    {
        TextElement.text = "";
        for (int i = 0; i < currentDialogue[pageNumber].text.Length; i += 1)
        {
            if (skipTextAnim)
            {
                skipTextAnim = false;
                TextElement.text = currentDialogue[pageNumber].text;
                StopAllCoroutines();
            }
            TextElement.text += currentDialogue[pageNumber].text[i];
            
            yield return new WaitForSeconds(letterDelay);
        }

        textshown = true;
    }
    */
    
}
