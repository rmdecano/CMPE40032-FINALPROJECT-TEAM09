using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{
    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    public GameObject MinDisplay;
    public GameObject SecDisplay;
    public GameObject MiliDisplay;

    public GameObject LapTimeBox;

    void OnTriggerEnter()
    {
        if(LapTimeManager.SecCount <= 9)
        {
            SecDisplay.GetComponent<Text>().text = "0" + LapTimeManager.SecCount + ".";
        }
        else
        {
            SecDisplay.GetComponent<Text>().text = "" + LapTimeManager.SecCount + ".";
        }

        if(LapTimeManager.MinCount <= 9)
        {
            SecDisplay.GetComponent<Text>().text = "0" + LapTimeManager.MinCount + ":";
        }
        else
        {
            SecDisplay.GetComponent<Text>().text = "" + LapTimeManager.MinCount + ":";
        }

        MiliDisplay.GetComponent<Text>().text = "" + LapTimeManager.MiliCount;

        LapTimeManager.MinCount = 0;
        LapTimeManager.SecCount = 0;
        LapTimeManager.MiliCount = 0;

        HalfLapTrig.SetActive(true);
        LapCompleteTrig.SetActive(false); 
    }


}
