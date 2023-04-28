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
    public Animator PlayerAnim;
    public GameObject EToRecycle;
    public GameObject ShirtHand;
    // Start is called before the first frame update
    void Start()
    {
        Shop.SetActive(false);   
        AllowPickup = true;
        EToRecycle.SetActive(false);
        ShirtHand.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        if(GameManager.ClothesGathered > 0){
            ShirtHand.SetActive(true);
        }else{
            ShirtHand.SetActive(false);
        }

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
                GameManager.ClothesGathered += 1;
                PlayerAnim.SetTrigger("Grab");
                StartCoroutine(PickupDelay());
                }
            }else {
                EtoPickUp.SetActive(false);
            }
        }
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out RaycastHit Hits, PickupLength)){
            if(Hits.transform.tag == "Container"){
                EToRecycle.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E)){
                    GameManager.Points += GameManager.ClothesGathered;
                    GameManager.ClothesGathered = 0;
                }
            }else{
                    EToRecycle.SetActive(false);
                }
        }
    }
    IEnumerator PickupDelay(){
        AllowPickup = false;
        yield return new WaitForSeconds(GameManager.PickupSpeed);
        AllowPickup = true;
    }
}
