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
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Looks = true;
    }

    // Update is called once per frame
    void Update()
    {
       Application.targetFrameRate = 60;
      Look();
      Movement();
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
            GetComponentsInChildren<Camera>();
            float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;
            transform.Rotate(transform.up * mouseX);

            camX -= mouseY;
            camX = Mathf.Clamp(camX, -70, 70);
            GetComponentsInChildren<Camera>()[0].transform.localRotation = Quaternion.Euler(camX, 0, 0);
        }
    }
}
