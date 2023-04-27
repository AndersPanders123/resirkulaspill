using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static float ClotesGathered;
    public Text ClotesGatheredText;
    public float Points;
    public float SpeedPrize;
    public PlayerMovement playerScript; 
    public static float PickupSpeed;
    public float PickupSpeedPrize;
    // Start is called before the first frame update
    void Start()
    {
        PickupSpeed = 1;
        PickupSpeedPrize = 2;
    }

    // Update is called once per frame
    void Update()
    {
        ClotesGatheredText.text = "Clothes Gathered: " + ClotesGathered.ToString();
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
}
