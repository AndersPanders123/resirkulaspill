using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesDropManager : MonoBehaviour
{
    public Transform[] DropPoints;
    public GameObject ClothesPrefab;
    public int times;

    int currentDropPoint = 0;

    void Start(){
        StartCoroutine(Sleep());
    }

    IEnumerator Sleep(){
        for(int i = 0; i < times; i++){
            Instantiate(ClothesPrefab, DropPoints[currentDropPoint].position, Quaternion.identity);
            if(currentDropPoint == DropPoints.Length - 1){
                currentDropPoint = 0;
            }else{
                currentDropPoint++;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
