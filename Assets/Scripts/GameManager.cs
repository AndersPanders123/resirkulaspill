using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static float ClothesGathered;
    public Text ClotesGatheredText;
    public static float Points;
    public float SpeedPrize;
    public PlayerMovement playerScript; 
    public static float PickupSpeed;
    public float PickupSpeedPrize;
    public Text PointText;
    public TextMeshProUGUI PickupSpeedPrizeText;
    public TextMeshProUGUI SpeedPrizeText;
    public static float BackPackSize;
    public float BackPackPrize;
    public TextMeshProUGUI BackPackText;
    public TextMeshProUGUI TimerText;
    public ClothesDropManager clothesScript;
    public TextMeshProUGUI ClothesToGatherText;
    public TextMeshProUGUI WavesText;
    public float Waves;
    public float CoinPerRecUpgradePrize;
    public TextMeshProUGUI CoinPerRecText;
    public static float CoinPerRec;
    public float timeplus;
    public TextMeshProUGUI levelspeed;
    public TextMeshProUGUI levelrecycle;
    public TextMeshProUGUI levelpickup;
    public TextMeshProUGUI levelbackpack;
    public float speedlevel;
    public float recyclelevel;
    public float pickuplevel;
    public float backpacklevel;
    // Start is called before the first frame update
    void Start()
    {
        speedlevel = 1;
        recyclelevel = 1;
        pickuplevel = 1;
        backpacklevel = 1;
        timeplus = 50;
        Waves = 1;
        PickupSpeed = 1;
        PickupSpeedPrize = 2;
        BackPackSize = 5;
        ClothesGathered = 0;
        CoinPerRec = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        levelbackpack.text = "Level: " + backpacklevel.ToString();
        levelpickup.text = "Level: " + pickuplevel.ToString();
        levelrecycle.text = "Level: " + recyclelevel.ToString();
        levelspeed.text = "Level: " + speedlevel.ToString();
        CoinPerRecText.text = "Coins Per Recycle P:" + CoinPerRecUpgradePrize.ToString();
        ClothesDropManager clothesScript = FindObjectOfType<ClothesDropManager>();
         ClothesToGatherText.text = "Clothes Left: " + clothesScript.ClothesAmount.ToString();
        if(clothesScript.ClothesAmount <= 0){
            clothesScript.Spawn();
            Timer.Timers += timeplus;
            Waves += 1;
            timeplus -= 1;
        }
        WavesText.text = "Wave: " + Waves.ToString();

        TimerPart();
        TimerText.text = "Time Left: " + Timer.Timers.ToString();
        ClotesGatheredText.text = ClothesGathered.ToString() + "/" + BackPackSize.ToString();
        PointText.text = ": " + Points.ToString();
        SpeedPrizeText.text = "Speed P:" + SpeedPrize.ToString();
        PickupSpeedPrizeText.text = "Pickup Speed P:" + PickupSpeedPrize.ToString();
        BackPackText.text = "BackPack Size P:" + BackPackPrize.ToString();

    }
    public void SpeedUpgrade(){
        Debug.Log("GameManagerUpgrade");
        if(Points >= SpeedPrize){
            Points -= SpeedPrize;
            PlayerMovement playerScript = FindObjectOfType<PlayerMovement>();
            playerScript.speed += 1;
            SpeedPrize *= 2;
        }
    }
    public void PickupUpgrade(){
        if(Points >= PickupSpeedPrize){
            Points -= PickupSpeedPrize;
            PickupSpeed -= 0.1f;
            PickupSpeedPrize *= 2;
        }
    }
    public void BackPackSizeUpgrade(){
        if(Points >= BackPackPrize){
            Points -= BackPackPrize;
            BackPackPrize *= 2;
            BackPackSize += 1;
        }
    } 
    public void TimerPart(){
        if(Timer.Timers <= 0){
            PlayerMovement.Looks = false;
            Timer.stopTimer = true;
            PlayerMovement.deads = true;
        }
    }
    public void CoinPerRecUpgrade()
    {
        if(Points >= CoinPerRecUpgradePrize)
        {
            CoinPerRec += 1;
            Points -= CoinPerRecUpgradePrize;
            CoinPerRecUpgradePrize *= 2;
        }
    }
}
