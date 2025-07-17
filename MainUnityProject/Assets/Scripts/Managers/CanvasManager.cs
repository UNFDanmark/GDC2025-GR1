using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;
using Image = UnityEngine.UI.Image;

public class CanvasManager : MonoBehaviour
{
    public GameObject interactUI, Btn1, Btn2;
    public GameObject textBox, textBoxEPG;
    public TextMeshProUGUI text1, text2, text3;
    public TextMeshProUGUI textElement, textElementEPG;
    public TextMeshProUGUI speakerElement;
    bool inDialogue, textshown;
    public float letterDelay;
    int pageNumber = 0;
    DialogueData[] currentDialogue;
    public GameObject interactor;
    public SoundManager soundManager;
    public EventManagerScript EventManager;
    public InventoryManager InventoryManager;

    ConversationData[] conversation;
    [SerializeField]UIDataManager uiDataManager;
    
    [SerializeField]Image SpeakerImage;

    ConversationData currentConversation;
    
    
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
            text1.gameObject.SetActive(!EPGisTalking);
            text2.gameObject.SetActive(!EPGisTalking);
            text3.gameObject.SetActive(!EPGisTalking);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            text1.gameObject.SetActive(false);
            text2.gameObject.SetActive(false);
            text3.gameObject.SetActive(false);
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

    public void CheckDialogues(ConversationData[] conversations, UIDataManager UIDataManager)
    {
        conversation = conversations;
        
        for (int i = 0; i < conversations.Length; i += 1)
        {
            if (conversations[i].inventoryState.isequals(InventoryManager.inventoryState) && UIDataManager.options == conversations[i].interactoption)
            {
                currentDialogue = conversations[i].dialogue;
                currentConversation = conversations[i];
                startDialogue(currentDialogue, UIDataManager);
                break;
            }
            
        }
    }
    
    
    public void startDialogue(DialogueData[] dialogue, UIDataManager UiDataManager)
    {
        
        
        if(UiDataManager)
            uiDataManager = UiDataManager;
        else if (!uiDataManager)
            uiDataManager = new UIDataManager();
        pageNumber = 0;
        currentDialogue = dialogue;
        displayPage();

        if (textBox.activeSelf)
        {
            text1.text = UiDataManager.UIData[UiDataManager.options].Text1;
            text2.text = UiDataManager.UIData[UiDataManager.options].Text2;
            text3.text = UiDataManager.UIData[UiDataManager.options].Text3;
        }
        
    }

    void displayPage()
    {
        StopAllCoroutines();
        if (currentDialogue.Length > pageNumber)
        {
            EventManager.PlayEvent(currentDialogue[pageNumber].PlayEvent); 

            if (currentDialogue[pageNumber].SpeakerImage != null)
            {
                SpeakerImage.sprite = currentDialogue[pageNumber].SpeakerImage;
                SpeakerImage.gameObject.SetActive(true);
            }
            else 
                SpeakerImage.gameObject.SetActive(false);
            speakerElement.text = currentDialogue[pageNumber].Speaker;
            
            if (textBox.activeSelf)
            {
                StartCoroutine(TextAnim(textElement));
            }
            else
            {
                StartCoroutine(TextAnim(textElementEPG));
            }
        }
    }

    void Update()
    {
        if (inDialogue)
        {
            if (pageNumber == 0 && uiDataManager.options == 0 && !textBoxEPG.activeSelf)
            {
                
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    OptionsClick(1);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    OptionsClick(2);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    OptionsClick(3);
                }
                
            }
            else if (Input.GetMouseButtonDown(0))
            {
                
                if (pageNumber < currentDialogue.Length)
                {
                    if (textshown)
                    {
                       
                        textshown = false;
                        pageNumber += 1;
                        displayPage();
                    }
                    else
                    {
                        StopAllCoroutines();
                        textElement.text = currentDialogue[pageNumber].text;
                        textElementEPG.text = currentDialogue[pageNumber].text;
                        textshown = true;
                    }
                }
                else
                {
                    setDialogueState(false, false);
                    if(uiDataManager != null)
                        uiDataManager.options = 0;
                }
            }
        }
    }

    public IEnumerator TextAnim(TextMeshProUGUI TextElement)
    {
        print(currentConversation.fallbackfont);
        if (currentDialogue[pageNumber].font == null)
            textElement.font = currentConversation.fallbackfont;
        else
            textElement.font = currentDialogue[pageNumber].font;
        TextElement.text = "";
        for (int i = 0; i < currentDialogue[pageNumber].text.Length; i += 1)
        {
            if(i%4 == 0)
                soundManager.playSound("Subtitles");
            TextElement.text += currentDialogue[pageNumber].text[i];
            
            yield return new WaitForSeconds(letterDelay);
        }

        textshown = true;
    }

    public void OptionsState(bool state)
    {
        print(state);
        text1.gameObject.SetActive(state);
        text2.gameObject.SetActive(state);
        text3.gameObject.SetActive(state);
    }
    public void OptionsClick(int ChosenOption)
    {
        if(currentDialogue.Length > pageNumber)
            EventManager.PlayEvent(currentDialogue[pageNumber].PlayEvent); 
        uiDataManager.options = ChosenOption;
        pageNumber = 1;
        CheckDialogues(conversation, uiDataManager);
        soundManager.playSound("DialogSound");
        OptionsState(false);
    }
    
}
