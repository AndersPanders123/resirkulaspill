using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class framelimit : MonoBehaviour
{
    public int FrameRateCap;
    public bool ForwardTime;
    public int forwardTimeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = FrameRateCap;
        if (ForwardTime)
        {
            Time.timeScale = forwardTimeSpeed;
        }
    }
}
