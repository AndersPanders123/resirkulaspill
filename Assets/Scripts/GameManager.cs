using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static int ClotesGathered;
    public Text ClotesGatheredText;

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

    }
    public void PickupSpeedUpgrade(){
        
    }
}
