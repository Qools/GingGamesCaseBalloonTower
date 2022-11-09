using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] private Rigidbody balloonRb;

    public float upForce;

    // Start is called before the first frame update
    void FixedUpdate()
    {
        balloonRb.AddForce(-Physics.gravity * upForce, ForceMode.Force);
    }
}
