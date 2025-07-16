using System;
using UnityEngine;
using TMPro;
[System.Serializable]
public class UIData
{
    //btn 1
    public bool button1Enabled;
    public string button1Text;
    public InventoryData InventoryCondition_btn1;
    [Space(20)]
    
    //btn 2
    public bool button2Enabled;
    public string button2Text;
    public InventoryData InventoryCondition_btn2;
    [Space(20)]
    
    //btn 3
    public bool button3Enabled;
    public string button3Text;
    public InventoryData InventoryCondition_btn3;
    [Space(20)]
    
    public FontStyles font;
}
