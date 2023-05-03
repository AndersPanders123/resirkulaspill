using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPerRecButton : MonoBehaviour
{
    public GameManager GameScript;
   public void ButtonPressed()
    {
        GameManager GameScript = FindObjectOfType<GameManager>();
        GameScript.CoinPerRecUpgrade();
    }
}
