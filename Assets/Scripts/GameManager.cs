using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Vector3 ballSpawnPoint;

    private void Awake()
    {
        instance = this;
    }
}
