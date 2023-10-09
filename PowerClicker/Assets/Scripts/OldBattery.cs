using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OldBattery : MonoBehaviour
{

    public int totalClicks;
    public int pointsPerClicks;
    public float[] spinSpeed;
    public TMP_Text wattsText;
    public RectTransform[] spinLight;
    public int minSpeed;
    public int maxSpeed;
    public GameObject floatingTextPrefab;
    public RectTransform boxTransform;
    // Start is called before the first frame update
    void Start()
    {
        int speed = Random.Range(minSpeed, maxSpeed);

        //match spin speed to number of spin lights
        spinSpeed = new float[spinLight.Length];

        //Generates random speed for lights
        for (int i = 0; i < spinSpeed.Length; i++)
        {
            spinSpeed[i] = Random.Range(-45f, 45f);
        }

        wattsText.text = 0 + " Watts";
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < spinLight.Length; i++)
        {
            spinLight[i].Rotate(0, 0, spinSpeed[i] * Time.deltaTime);
        }
        
    }

    public void OnBatteryClicked()
    {
        totalClicks+=pointsPerClicks;
        UpdateUI();
        CreateFloatingText("+" + pointsPerClicks);
    }

    private void UpdateUI()
    {
        if(totalClicks == 1)
        {
            wattsText.text = totalClicks.ToString() + " Watt";
        }
        else
        {
            wattsText.text = totalClicks.ToString() + " Watts";
        }
    }

    private void CreateFloatingText(string messeage)
    {
        //Spawn a new floating text
        GameObject newFloatingText = Instantiate(floatingTextPrefab, boxTransform);

        //Generate a random position around the muffin
        Vector3 randomPosition = GetRandomPosAroundMuffin();

        //Position the new floating text at that random position
        newFloatingText.transform.localPosition = randomPosition;

        //Set the floating text's actual text
        newFloatingText.GetComponent<TMP_Text>().text = messeage;

    }

    private Vector3 GetRandomPosAroundMuffin()
    {
        return new Vector3(Random.Range(-200, 200), Random.Range(30, 150));
    }
}
