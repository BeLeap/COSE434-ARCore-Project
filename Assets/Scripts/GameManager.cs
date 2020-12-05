using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int batting = 0;

    public GameObject table;
    public GameObject ball;

    public Vector2 dragDistance;

    private void Awake()
    {
        instance = this;
    }
}
