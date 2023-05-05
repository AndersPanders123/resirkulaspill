using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatheringClothes : MonoBehaviour
{
    public float PickupLength;
    public GameObject EtoPickUp;
    public Camera camera;
    
    bool IsTabbed;
    bool  AllowPickup;
    public Animator PlayerAnim;
    public GameObject EToRecycle;
    public GameObject ShirtHand;
    bool BackPackFull;
   
    public Vector3 firstPosition;
    public Vector3 secondPosition;
    public float moveSpeed = 5f;
    public AudioSource CoinChing;

    private bool isAtFirstPosition = true;
    public GameObject cubeObject;

    public ClothesDropManager clothesScript;
    public Animator UIAnim;
    public Animator ClothesAnim;
    public bool closed;

    public AudioSource ClothesGrabeffect;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.CoinPerRec = 0;
        AllowPickup = true;
        EToRecycle.SetActive(false);
        ShirtHand.SetActive(false);
        BackPackFull = false;
    }

    // Update is called once per frame
    void Update(){
         // Check if Tab key is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Toggle isAtFirstPosition
            isAtFirstPosition = !isAtFirstPosition;
            PlayerMovement.Looks = !PlayerMovement.Looks;

        if(isAtFirstPosition == true)
        {
           if(PlayerMovement.deads == false){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
           }
            
        }
        if(isAtFirstPosition == false){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        }
        
        

        // Move towards firstPosition or secondPosition based on isAtFirstPosition
        // Move towards firstPosition or secondPosition based on isAtFirstPosition
        Vector3 targetPosition = isAtFirstPosition ? firstPosition : secondPosition;
        cubeObject.transform.position = Vector3.MoveTowards(cubeObject.transform.position, targetPosition, moveSpeed * Time.deltaTime);


        if(GameManager.ClothesGathered > 0){
            ShirtHand.SetActive(true);
        }else{
            ShirtHand.SetActive(false);
        }
        if(GameManager.ClothesGathered < GameManager.BackPackSize){
            BackPackFull = false;
        }else{
            BackPackFull = true;
        }

        
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out RaycastHit Hit, PickupLength)){
            if(Hit.transform.tag == "Clothes"){
                if(BackPackFull == true && Input.GetKeyDown(KeyCode.E)){
                    PlayerAnim.SetTrigger("FullPack");
                }
                EtoPickUp.SetActive(true);
                if(BackPackFull == false && AllowPickup == true && Input.GetKeyDown(KeyCode.E)){
                StartCoroutine(PickupDelay());
                AllowPickup = false;
                Destroy(Hit.transform.gameObject);
                ClothesDropManager clothesScript = FindObjectOfType<ClothesDropManager>();
                clothesScript.ClothesAmount -= 1;
                ClothesAnim.SetTrigger("PlusClothes");
                GameManager.ClothesGathered += 1;
                PlayerAnim.SetTrigger("Grab");
                ClothesGrabeffect.Play();
                }
            }else {
                EtoPickUp.SetActive(false);
            }
        }
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out RaycastHit Hits, PickupLength)){
            if(Hits.transform.tag == "Container"){
                EToRecycle.SetActive(true);
                if(GameManager.ClothesGathered > 0 && Input.GetKeyDown(KeyCode.E)){
                    GameManager.Points += GameManager.ClothesGathered + GameManager.CoinPerRec;
                    GameManager.ClothesGathered = 0;
                    UIAnim.SetTrigger("PlusCoin");
                    StartCoroutine(CoinChingWait());
                }
            }
        }else {
                    EToRecycle.SetActive(false);
            }
    }
    IEnumerator PickupDelay(){
        AllowPickup = false;
        float wait = GameManager.PickupSpeed;
        yield return new WaitForSeconds(wait);
        AllowPickup = true;
    }
    IEnumerator CoinChingWait()
    {
        yield return new WaitForSeconds(0.2f);
        CoinChing.Play();
    }
     
}
