using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void Plays()
    {
        SceneManager.LoadScene("Game");
        Timer.Timers = 150;
        Timer.Timers = 150;
    }
}
