using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatheringClothes : MonoBehaviour
{
    public float PickupLength;
    public GameObject EtoPickUp;
    public Camera camera;
    public GameObject Shop;
    bool IsTabbed;
    bool  AllowPickup;
    // Start is called before the first frame update
    void Start()
    {
        Shop.SetActive(false);   
        AllowPickup = true;
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Tab)){
            
            IsTabbed = !IsTabbed;
            if(IsTabbed){
                Shop.SetActive(true);
            }else{
                Shop.SetActive(false);
            }
        }
        if(AllowPickup == true && Physics.Raycast(camera.transform.position, camera.transform.forward, out RaycastHit Hit, PickupLength)){
            if(Hit.transform.tag == "Clothes"){
                EtoPickUp.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E)){
                Destroy(Hit.transform.gameObject);
                GameManager.ClotesGathered += 1;
                StartCoroutine(PickupDelay());
                }
            }else {
                EtoPickUp.SetActive(false);
            }
        }
    }
    IEnumerator PickupDelay(){
        AllowPickup = false;
        yield return new WaitForSeconds(GameManager.PickupSpeed);
        AllowPickup = true;
    }
}
