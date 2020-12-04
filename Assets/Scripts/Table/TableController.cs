using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleARCore;

public class TableController : MonoBehaviour
{
    private DetectedPlane detectedPlane;
    public GameObject tablePrefab;

    public BallController ball;

    // Update is called once per frame
    void Update()
    {
        if (Session.Status != SessionStatus.Tracking)
        {
            return;
        }
        if (detectedPlane == null)
        {
            return;
        }

        while (detectedPlane.SubsumedBy != null)
        {
            detectedPlane = detectedPlane.SubsumedBy;
        }
    }

    void SpawnTable()
    {
        if (GameManager.instance.table != null)
        {
            return;
        }

        Vector3 pos = detectedPlane.CenterPose.position;

        GameManager.instance.table = Instantiate(tablePrefab, pos, Quaternion.Euler(0, -90, 0), transform);

        ball.SpawnBall(GameManager.instance.table.transform.Find("BallSpawnPoint").position);
    }

    public void SetPlane(DetectedPlane plane)
    {
        detectedPlane = plane;
        SpawnTable();
    }
}

