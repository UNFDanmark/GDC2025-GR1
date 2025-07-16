using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlanScript : MonoBehaviour
{
    [SerializeField] float WFFDTime = 1;
    [SerializeField] CanvasManager CM;
    [SerializeField] GameObject Plan;

    void Awake()
    {
        StartCoroutine(WaitForFunnyDialog());
        CM.enabled = false;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, 0);
            StopAllCoroutines();
            Plan.SetActive(true);
            CM.enabled = true;
        }
    }

    IEnumerator WaitForFunnyDialog()
    {
        yield return new WaitForSeconds(WFFDTime);
        print("'funny message'");
        print("HA HA HA HA HA");
    }
}
