using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public struct SaveData
{
    public int totalClicks;
    public int pointsPerClick;
    public int pointsPerSecond;
    public int upgradeBTN1;
    public int upgradeBTN2;

}
public class GameManager : MonoBehaviour
{

    public int totalClicks;
    public int pointsPerClicks;
    public int wattsPerSecond;

    [SerializeField] private GameObject floatingTextPrefab;

    [SerializeField] private RectTransform boxTransform;

    [SerializeField] private UpgradeButton upgradeBTN1;
    [SerializeField] private UpgradeButton upgradeBTN2;

    [SerializeField] private float rewardTimer;
    [SerializeField] private float rewardTime;

    [SerializeField] private UIManager iManager;

    private UpgradeType upgrade;

    private float cooldown = 1;


    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if(cooldown <= 0)
        {
            PointsOverTime();
        }
    }

    private void PointsOverTime()
    {
        totalClicks += wattsPerSecond;
        iManager.UpdateUI(totalClicks, wattsPerSecond);
        cooldown = 1;
    }

    public void OnBatteryClicked()
    {
        totalClicks += pointsPerClicks;
        iManager.UpdateUI(totalClicks,wattsPerSecond);
        CreateFloatingText("+" + pointsPerClicks);
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



    private void SaveGame()
    {
        Debug.Log("Game Saved...");

        //create the save data object
        SaveData saveData = new SaveData();

        //Populate the save data with current data
        saveData.totalClicks = totalClicks;
        saveData.pointsPerClick = pointsPerClicks;
        saveData.pointsPerSecond = wattsPerSecond;
        saveData.upgradeBTN1 = upgradeBTN1.level;
        saveData.upgradeBTN2 = upgradeBTN2.level;

        //Convert the save data to JSON - Seriializing it
        string saveJSON = JsonUtility.ToJson(saveData);

        //Save the JSON to PlayerPrefs
        PlayerPrefs.SetString("savegame", saveJSON);
    }

    private void LoadGame()
    {
        Debug.Log("Game Loaded...");

        //Load the JSON from PlayerPrefs
        string saveJSON = PlayerPrefs.GetString("savegame", "{}");

        //Convert the JSON data to a data object - Deseriializing it
        SaveData saveData = JsonUtility.FromJson<SaveData>(saveJSON);

        //Populate current game state with saved data
        totalClicks = saveData.totalClicks;
        wattsPerSecond = saveData.pointsPerSecond;
        upgradeBTN1.level = saveData.upgradeBTN1;
        upgradeBTN2.level = saveData.upgradeBTN2;

        if (saveData.pointsPerClick == 0)
        {
            pointsPerClicks = 1;
        }
        else
        {
            pointsPerClicks = saveData.pointsPerClick;
        }
    }

    public bool TryToBuyUpgrade(int price, UpgradeType upgrade)
    {
        if(totalClicks < price)
        {
            return false;
            
        }


        switch (upgrade)
        {
            case UpgradeType.PowerPerClick:
                pointsPerClicks++;
                iManager.UpdateUI(totalClicks,wattsPerSecond);
                break;
            case UpgradeType.PowerPerSecond:
                wattsPerSecond++;
                iManager.UpdateUI(totalClicks, wattsPerSecond);
                break;

        }

        return true;
    }
}
