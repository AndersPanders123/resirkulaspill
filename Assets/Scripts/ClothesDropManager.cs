using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesDropManager : MonoBehaviour
{
    public Transform[] DropPoints;
    public GameObject ClothesPrefab;
    public int times;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ClothesPrefab, DropPoints[3].transform.position, Quaternion.identity);
        StartCoroutine(Sleep());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //For loop for og spawne klær på positions
    IEnumerator Sleep(){
        for (int i = 0; i < times; i++)
         {
            int index = i;
            i = index;
            if (index >= DropPoints.Length)
            {
             index = 0; 
            }
            Instantiate(ClothesPrefab, DropPoints[index].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
         }
    }
}
