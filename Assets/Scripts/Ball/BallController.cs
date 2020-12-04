using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleARCore;

public class BallController : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject table;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnBall(Vector3 pos) 
    {
        Instantiate(ballPrefab, pos, Quaternion.identity);
    }
}
