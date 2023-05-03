using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesDropManager : MonoBehaviour
{
    public Transform[] DropPoints;
    public GameObject TShirtPrefab;
    public GameObject PantsPrefab;
    public int times;
    public float ClothesAmount;
    public GameObject SpawnPrefab;
    public float Number;

    int currentDropPoint = 0;

    void Start(){
        Number = 1;
        times = 20;
        StartCoroutine(Sleep());
        StartCoroutine(ChangePrefab());
        SpawnPrefab = PantsPrefab;
    }
    public void Spawn(){
        times += 20;
        StartCoroutine(Sleep());
    }
        void Update()
    {
        if(Number == 3)
        {
            Number = 1;
        }
        if (Number == 2)
        {
            SpawnPrefab = TShirtPrefab;
            
        }
        if (Number == 1)
        {
            SpawnPrefab = PantsPrefab;
        }
    }

    IEnumerator Sleep(){
        for(int i = 0; i < times; i++){
            Instantiate(SpawnPrefab, DropPoints[currentDropPoint].position, Quaternion.identity);
            ClothesAmount += 1;
            if(currentDropPoint == DropPoints.Length - 1){
                currentDropPoint = 0;
            }else{
                currentDropPoint++;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator ChangePrefab()
    {
        
        yield return new WaitForSeconds(0.1f);
        Number += 1;
        StartCoroutine(ChangePrefab());


    }
}
