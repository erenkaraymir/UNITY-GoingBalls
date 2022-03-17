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
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rb.AddForce(new Vector3(horizontal * ballSpeed * Time.deltaTime / 2f, jumpValue, vertical * ballSpeed * Time.deltaTime), ForceMode.Acceleration);
        //rb.velocity += new Vector3(horizontal * ballSpeed * Time.deltaTime / 2f, jumpValue, vertical * ballSpeed * Time.deltaTime);
    }
}
