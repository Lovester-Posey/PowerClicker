using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TMP_Text wattsText;
    [SerializeField] private TMP_Text wattsPerSecondText;


    public void UpdateUI(int totalClicks, int wattsPerSecond)
    {
        if (totalClicks == 1)
        {
            wattsText.text = totalClicks.ToString() + " watt";   //update Power counter

        }
        else
        {
            wattsText.text = totalClicks.ToString() + " watts";
        }

        if (wattsPerSecond == 1)
        {
            wattsPerSecondText.text = wattsPerSecond.ToString() + " watt per second";   //update Power counter

        }
        else
        {
            wattsPerSecondText.text = wattsPerSecond.ToString() + " watts per seconds";
        }
    }


}
