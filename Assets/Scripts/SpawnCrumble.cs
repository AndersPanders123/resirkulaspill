using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCrumble : MonoBehaviour
{
    public GameObject CrumblePrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Sleep());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Sleep()
    {
        yield return new WaitForSeconds(0.2f);
        Instantiate(CrumblePrefab, transform.position, Quaternion.identity);
        StartCoroutine(Sleep());
    }
}
