using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] private GameObject balloonPrefab;
    [SerializeField] private GameObject balloonConnectorPrefab;

    [SerializeField] private Transform balloonHolder;

    public float spawnRate = 1f;
    public float fillTime = 1f;

    public int maxBalloonNumbers;
    private int spawnedBalloonNumbers = 0;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnBalloon), spawnRate, spawnRate);
    }

    public void SpawnBalloon()
    {
        Rigidbody rb = balloonConnectorPrefab.GetComponent<Rigidbody>();

        GameObject balloon = Instantiate(balloonPrefab, transform.position, Quaternion.identity);
        var joint = balloon.GetComponent<ConfigurableJoint>();

        spawnedBalloonNumbers++;

        FillBalloon(balloon, joint, rb);

        if (spawnedBalloonNumbers >= maxBalloonNumbers)
        {
            CancelInvoke(nameof(SpawnBalloon));
        }
    }
    public void FillBalloon(GameObject balloon, ConfigurableJoint joint, Rigidbody rb)
    {
        balloon.transform.DOScale(Vector3.one, fillTime).OnComplete(() => 
        { 
            joint.connectedBody = rb;
        });
    }
}
