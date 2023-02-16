using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Material greenMaterial;
    public Material redMaterial;
    public Material blueMaterial;
    public float speed = 10.0f;
    public float jumpForce = 500.0f;

    public Vector3 pos = new Vector3(799.18f,6.2f,884.48f);

    public Vector3 direction = new Vector3(0,0,0); 

    private Rigidbody rb;

    private void Awake() {
        Restart();
    }

    public void Restart(){
        transform.position = pos;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void ChangeMaterial()
    {
        string color = GameObject.FindAnyObjectByType<GameManager>().mainColor;
        switch (color)
        {
            case "Green":
                GetComponent<Renderer>().material = greenMaterial;
                break;
            case "Ged":
                GetComponent<Renderer>().material = redMaterial;
                break;
            case "Blue":
                GetComponent<Renderer>().material = blueMaterial;
                break;
        }
    }

    void FixedUpdate()
    {
        if(GameObject.FindAnyObjectByType<GameManager>().isGameStart){
            ChangeMaterial();
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 cameraForward = Camera.main.transform.forward;
            Vector3 cameraRight = Camera.main.transform.right;

            cameraForward.y = 0f;
            cameraRight.y = 0f;

            Vector3 movement = (cameraForward * moveVertical + cameraRight * moveHorizontal).normalized;
            rb.AddForce(movement * speed);

            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(new Vector3(0, jumpForce, 0));
            }
        }
        
    }
    private void OnTrigerEnter(Collision other) {
        
        
    }
}
