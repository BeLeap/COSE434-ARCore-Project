using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class BallManager : MonoBehaviour
{
    public float multiplier = 100;
    private void Start()
    {
        GameManager.instance.ball = this.gameObject;
    }

    public void Hit(Vector2 force)
    {
        if (Vector2.SqrMagnitude(force) < 0.001f) return;
        Vector2 multipliedForce = force * multiplier;
        this.GetComponent<Rigidbody>().AddForce(new Vector3(multipliedForce.x, 0, multipliedForce.y));
        GameManager.instance.batting++;
    }
}
