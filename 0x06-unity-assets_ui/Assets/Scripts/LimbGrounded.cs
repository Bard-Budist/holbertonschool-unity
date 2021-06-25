using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbGrounded : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        PlayerController py = other.gameObject.GetComponent<PlayerController>();
        py.isGround = true;
        Debug.Log("Buenas");
    }
}
