using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    [SerializeField] private float ballSpeed;
    private bool isTouch = false;
    Rigidbody rb;
    private float horizontal, vertical;
    private float jumpValue = 0f;
    public float rotateSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Rotate(new Vector3(transform.forward.z,0f,0f));
        rb.AddForce(new Vector3(0f, jumpValue, vertical * ballSpeed * Time.deltaTime), ForceMode.Acceleration);
        //rb.velocity += new Vector3(horizontal * ballSpeed * Time.deltaTime / 2f, jumpValue, vertical * ballSpeed * Time.deltaTime); 
    }
}
