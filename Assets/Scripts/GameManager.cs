using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Vector3 ballSpawnPoint;
    public int score = 0;

    private void Awake()
    {
        instance = this;
    }
}
