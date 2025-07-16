using System;
using UnityEngine;
using TMPro;
[System.Serializable]
public class UIData
{
    //btn 1
    public bool button1Enabled;
    public InventoryData InventoryCondition_btn1;
    [Space(20)]
    
    //btn 2
    public bool button2Enabled;
    public InventoryData InventoryCondition_btn2;
    [Space(20)]
    
    //texts
    public string Text1;
    public string Text2;
    public string Text3;
    public FontStyles font;
    
    
    
}
