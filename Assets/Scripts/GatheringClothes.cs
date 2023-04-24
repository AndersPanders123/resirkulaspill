using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatheringClothes : MonoBehaviour
{
    public float PickupLength;
    public GameObject EtoPickUp;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out RaycastHit Hit, PickupLength)){
            if(Hit.transform.tag == "Clothes"){
                EtoPickUp.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E)){
                Destroy(Hit.transform.gameObject);
                GameManager.ClotesGathered += 1;
                }
            }else {
                EtoPickUp.SetActive(false);
            }
        }
    }
}
