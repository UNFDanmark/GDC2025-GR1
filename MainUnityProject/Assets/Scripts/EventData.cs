using UnityEngine;
[System.Serializable]
public class EventData
{
    //EventName
    public string EventName;
    [Space(20)]
    
    //sound
    public bool PlaySound;
    public string Sound;
    [Space(20)]
    
    //Inventory
    public bool ChangeInventory;
    public InventoryData Inventory;
    [Space(20)]
    
    //Objective
    public bool ChangeObjective;
    public string NewObjective;
    [Space(20)]

    //EPG Talks
    public bool EPGTalks;
    [Space(20)]

    //Toggles Object Visibility
    public bool ToggleObjectVisibility;
    public GameObject Object;

}
