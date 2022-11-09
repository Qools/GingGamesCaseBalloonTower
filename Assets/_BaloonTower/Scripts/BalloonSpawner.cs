using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] private GameObject balloonPrefab;
    [SerializeField] private GameObject balloonConnectorPrefab;

    [SerializeField] private Transform balloonHolder;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject connector = Instantiate(balloonConnectorPrefab, transform.position, Quaternion.identity, balloonHolder);
            Rigidbody rb = connector.GetComponent<Rigidbody>();

            GameObject balloon = Instantiate(balloonPrefab, transform.position, Quaternion.identity);
            ConfigurableJoint joint = balloon.GetComponent<ConfigurableJoint>();

            joint.connectedBody = rb;

        }
    }
}
