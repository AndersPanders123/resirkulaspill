using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpeedUpgrade : MonoBehaviour
{   
    public GameManager gameScript;

   public void PickupButton(){
    GameManager gameScript = FindObjectOfType<GameManager>();
    gameScript.PickupUpgrade();
   }
}