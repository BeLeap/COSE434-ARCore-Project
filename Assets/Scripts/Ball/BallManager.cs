using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class BallManager : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.ball = this.gameObject;
    }
    public void Hit(Vector3 force)
    {
        this.GetComponent<Rigidbody>().AddForce(force);
    }
}
