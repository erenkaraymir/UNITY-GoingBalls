using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObstacle : MonoBehaviour
{
    public float time;
    public GameObject ball;
    public float ballSpeed;
    public bool right, left;
    GameObject ballClone;
    void Update()
    {
        time += Time.deltaTime;
        if(time > 2)
        {
            time = 0;
            ballClone = Instantiate(ball, transform.position, Quaternion.identity);
        }
        if (right && ballClone!=null)
        {
           // transform.position += new Vector3(ballSpeed * Time.deltaTime * -1, 0f, 0f);
            ballClone.GetComponent<Rigidbody>().AddForce(Vector3.left * ballSpeed, ForceMode.Acceleration);
            Destroy(ballClone, 2.5f);
        }
        else if (left && ballClone != null)
        {
            ballClone.GetComponent<Rigidbody>().AddForce(Vector3.right * ballSpeed, ForceMode.Acceleration);
            Destroy(ballClone, 2f);
        }
    }
}
