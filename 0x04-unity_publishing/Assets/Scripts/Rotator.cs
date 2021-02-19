using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    float x;

    void Update()
    {
        x += Time.deltaTime * 45;
        transform.rotation = Quaternion.Euler(0, x, 90);
    }
}
