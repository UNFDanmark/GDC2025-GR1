using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CanvasManager : MonoBehaviour
{
    public GameObject interactUI, Btn1, Btn2;
    public GameObject textBox, textBoxEPG;
    public TextMeshProUGUI text1, text2, text3;
    public TextMeshProUGUI textElement, textElementEPG;
    public TextMeshProUGUI speakerElement;
    bool inDialogue, skipTextAnim, textshown;
    public float letterDelay;
    int pageNumber = 0;
    DialogueData[] currentDialogue;
    public GameObject interactor;
    public SoundManager soundManager;
    public EventManagerScript EventManager;
    public InventoryManager InventoryManager;


    UIDataManager uiDataManager;
    
    
    public void ToggleInteractUI(bool isActive)
    {
        if (inDialogue)
        {
            interactUI.SetActive(false);
        }
        else
        {
            interactUI.SetActive(isActive);
            Btn1.SetActive(isActive);
            if (InventoryManager.inventoryState.hasGun)
            {
                Btn2.SetActive(isActive);
            }
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
            text1.gameObject.SetActive(true);
            text2.gameObject.SetActive(true);
            text3.gameObject.SetActive(true);
        }
        else
        {
            text1.gameObject.SetActive(false);
            text2.gameObject.SetActive(false);
            text3.gameObject.SetActive(false);
        }
    }

    public void startDialogue(DialogueData[] dialogue, UIDataManager uiData)
    {
        uiDataManager = uiData;
        pageNumber = 0;
        currentDialogue = dialogue;
        displayPage();

        if (textBox.activeSelf)
        {
            text1.text = uiData.UIData[uiData.options].Text1;
            text2.text = uiData.UIData[uiData.options].Text2;
            text3.text = uiData.UIData[uiData.options].Text3;
        }
        
    }

    void displayPage()
    {
        
        
        
        speakerElement.text = currentDialogue[pageNumber].Speaker;
        
        StopAllCoroutines();
        
        if (textBox.activeSelf)
        {
            //textElement.text = currentDialogue[pageNumber].text;
            StartCoroutine(TextAnim(textElement));
        }
        else
        {
            //textElementEPG.text = currentDialogue[pageNumber].text;
            StartCoroutine(TextAnim(textElementEPG));
        }


    }

    void Update()
    {
        if (inDialogue)
        {
            if (pageNumber == 0)
            {
                if (textBoxEPG.activeSelf && Input.GetKeyDown(KeyCode.Mouse0))
                {
                    EventManager.PlayEvent(currentDialogue[pageNumber].PlayEvent); 
                    if (textshown)
                    {
                       
                        textshown = false;
                        pageNumber += 1;
                        displayPage();
                    }
                    else
                    {
                        skipTextAnim = true;
                        textshown = true;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    EventManager.PlayEvent(currentDialogue[pageNumber].PlayEvent); 
                    uiDataManager.options = 0;
                    pageNumber += 1;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    EventManager.PlayEvent(currentDialogue[pageNumber].PlayEvent); 
                    uiDataManager.options = 1;
                    pageNumber += 1;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    EventManager.PlayEvent(currentDialogue[pageNumber].PlayEvent); 
                    uiDataManager.options = 2;
                    pageNumber += 1;
                }
            }
            else if (Input.GetMouseButtonDown(0))
            {
                
                if (pageNumber < currentDialogue.Length)
                {
                    if (textshown)
                    {
                       
                        textshown = false;
                        EventManager.PlayEvent(currentDialogue[pageNumber].PlayEvent); 
                        pageNumber += 1;
                        displayPage();
                    }
                    else
                    {
                        skipTextAnim = true;
                        textshown = true;
                    }
                }
                else
                {
                    setDialogueState(false, false);
                }
            }
        }
    }

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
    
    
}
