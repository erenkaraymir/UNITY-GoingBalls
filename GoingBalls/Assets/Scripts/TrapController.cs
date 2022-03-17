using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public float power;
    [SerializeField] GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var dir = gameObject.transform.position - other.gameObject.transform.position;
            other.GetComponent<Rigidbody>().AddForce(new Vector3(-dir.x,0f,0f) * power, ForceMode.Impulse);
        }
    }
}
