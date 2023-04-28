using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPackButton : MonoBehaviour
{
    public GameManager GameScript;
    public void BackPackUpgradeButton(){
        GameManager GameScript = FindObjectOfType<GameManager>();
        GameScript.BackPackSizeUpgrade();
    }
}
