using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleARCore;

public class BallController : MonoBehaviour
{
    private DetectedPlane detectedPlane;
    public GameObject ballPrefab;
    public GameObject table;
    private GameObject ballInstance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (detectedPlane == null)
        {
            return;
        }

        if (detectedPlane.TrackingState != TrackingState.Tracking)
        {
            return;
        }

        if (ballInstance == null && GameManager.instance.ballSpawnPoint != null)
        {
            Debug.Log("Spawn Location " + GameManager.instance.ballSpawnPoint);
            ballInstance = Instantiate(ballPrefab, GameManager.instance.ballSpawnPoint, Quaternion.identity);
        }
    }

    private void SetSelectedPlane(DetectedPlane selectedPlane)
    {
        detectedPlane = selectedPlane;
    }
}
