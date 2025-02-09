﻿using System.Collections;
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

        TrackableHit hit;
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinBounds;

        if (Frame.Raycast(Screen.width / 2, Screen.height / 2, raycastFilter, out hit))
        {
            Vector3 pos = hit.Pose.position - new Vector3(0.25f, 0, 0);

            GameManager.instance.table = Instantiate(tablePrefab, pos, Quaternion.Euler(0, -90, 0), transform);

            ball.SpawnBall(GameManager.instance.table.transform.Find("BallSpawnPoint").position);
        }
    }

    public void SetPlane(DetectedPlane plane)
    {
        detectedPlane = plane;
        SpawnTable();
    }
}

