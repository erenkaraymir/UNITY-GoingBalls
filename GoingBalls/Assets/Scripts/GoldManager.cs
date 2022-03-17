using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    private float gold;

    private void Update()
    {
        transform.Rotate(Vector3.left * 100 * Time.deltaTime, Space.Self);
    }
}
