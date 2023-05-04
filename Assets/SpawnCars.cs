using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    public GameObject BusPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Sleep());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Sleep(){
        yield return new WaitForSeconds(4);
        Instantiate(BusPrefab, transform.position, transform.rotation);
        StartCoroutine(Sleep());
    }
}
