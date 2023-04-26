using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static int ClotesGathered;
    public Text ClotesGatheredText;
    public int Points;
    public int SpeedPrize;
    public PlayerMovement playerScript; 
    // Start is called before the first frame update
    void Start()
    {
        
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
    public void PickupSpeedUpgrade(){
        
        
    }   
}
