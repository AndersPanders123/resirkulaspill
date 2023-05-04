using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Camera Movement")]
    public float Sensitivity;
    float camX;
    [Header("Rigidbody Movement")]
    public Rigidbody rb;
    public float speed;
    public static bool Looks;
    [Header("Jumping")]
    public GameObject JumpObject;
    public float jumprad;
    public LayerMask GroundMask;
    public float JumpPower;
    bool IsGrounded;
    bool canJump = true;
    public Animator DeadAnim;
    public static bool deads;

    
    // Start is called before the first frame update
    void Start()
    {
        deads = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Looks = true;
    }

    // Update is called once per frame
    void Update()
    {
       Application.targetFrameRate = 60;
      Look();
      Jumping();
      if(deads){
        DeadAnim.SetBool("Dead", true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
      }
    }
    void FixedUpdate(){
        if(IsGrounded && Looks){
      Movement();
      }
    }
    void Movement(){
      float moveX = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
      float moveZ = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
      Vector3 move = transform.forward * moveZ + transform.right * moveX;
      rb.AddForce(move, ForceMode.VelocityChange);

      
    }
    void Look(){
        if (Looks)
        {
            // GetComponentsInChildren<Camera>();
            float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;
            transform.Rotate(transform.up * mouseX);

            camX -= mouseY;
            camX = Mathf.Clamp(camX, -70, 70);
            GetComponentsInChildren<Camera>()[0].transform.localRotation = Quaternion.Euler(camX, 0, 0);
        }
    }
    void Jumping(){
        IsGrounded = false;
        foreach(Collider i in Physics.OverlapSphere(JumpObject.transform.position, jumprad)){
            if(i.transform.tag != "Player"){
                IsGrounded = true;
                break;
            }
        }
        if(IsGrounded && canJump){
            if(Input.GetKeyDown(KeyCode.Space)){
                rb.AddForce(transform.up * JumpPower, ForceMode.VelocityChange);
                canJump = false;
            }
        }
        rb.drag = IsGrounded ? 10 : 0;
        if(!IsGrounded){
            canJump = true;
        }
    }
    void OnCollisionStay(Collision Man){
        if(Man.transform.tag == "Car"){
            Looks = false;
            deads = true;
        }
    }
}
