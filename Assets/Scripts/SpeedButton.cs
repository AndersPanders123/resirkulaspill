using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedButton : MonoBehaviour
{
    public GameManager GameManagerScript;
    public void SpeedButtonUpgrade(){
        GameManager GameManagerScript = FindObjectOfType<GameManager>();
        GameManagerScript.SpeedUpgrade();
        Debug.Log("Click");
    }
}
