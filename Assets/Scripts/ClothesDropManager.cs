using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesDropManager : MonoBehaviour
{
    public Transform[] DropPoints;
    public GameObject ClothesPrefab;
    public int times;
    public float ClothesAmount;

    int currentDropPoint = 0;

    void Start(){
        times = 20;
        StartCoroutine(Sleep());
    }
    public void Spawn(){
        times += 20;
        StartCoroutine(Sleep());
    }

    IEnumerator Sleep(){
        for(int i = 0; i < times; i++){
            Instantiate(ClothesPrefab, DropPoints[currentDropPoint].position, Quaternion.identity);
            ClothesAmount += 1;
            if(currentDropPoint == DropPoints.Length - 1){
                currentDropPoint = 0;
            }else{
                currentDropPoint++;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
