using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float Timers;
    public static bool stopTimer;
    // Start is called before the first frame update
    void Start()
    {
        Timers = 150;
    }

    // Update is called once per frame
    void Update()
    {
        if(stopTimer == false){
        Timers -= Time.deltaTime;
        }
    }
}
