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
    // Start is called before the first frame update
    void Start()
    {
        PickupSpeed = 1;
        PickupSpeedPrize = 2;
        BackPackSize = 5;
        ClothesGathered = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
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
        }
    }
    public void PickupUpgrade(){
        if(Points >= PickupSpeedPrize){
            PickupSpeed -= 0.1f;
            Points -= PickupSpeedPrize;
        }
    }
    public void BackPackSizeUpgrade(){
        if(Points >= BackPackPrize){
            Points -= BackPackPrize;
            BackPackSize += 1;
        }
    } 
}
