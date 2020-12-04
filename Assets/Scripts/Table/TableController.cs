using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleARCore;

public class TableController : MonoBehaviour
{
    private DetectedPlane detectedPlane;
    public GameObject tablePrefab;
    private GameObject tableInstance;

    // Start is called before the first frame update
    void Start()
    {

    }

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
        if (tableInstance != null)
        {
            return;
        }

        Vector3 pos = detectedPlane.CenterPose.position;

        tableInstance = Instantiate(tablePrefab, pos, Quaternion.Euler(0, -90, 0), transform);
        tableInstance.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    public void SetPlane(DetectedPlane plane)
    {
        detectedPlane = plane;
        SpawnTable();
    }
}

