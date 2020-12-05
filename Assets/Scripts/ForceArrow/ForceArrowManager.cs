using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceArrowManager : MonoBehaviour
{
    private GameObject arrowStem;
    public Material red;

    // Start is called before the first frame update
    void Start()
    {
        arrowStem = CreateLine();
    }

    private GameObject CreateLine()
    {
        GameObject line = new GameObject("Arrow");
        LineRenderer lr = line.AddComponent<LineRenderer>();
        lr.startWidth = 0.01f;
        lr.endWidth = 0.01f;
        lr.startColor = Color.red;
        lr.endColor = Color.red;

        lr.material = red;

        line.SetActive(false);

        return line;
    }

    public void Destroy()
    {
        arrowStem.SetActive(false);
    }

    public void Draw(Vector3 start, Vector3 end)
    {
        arrowStem.SetActive(true);

        LineRenderer lr = arrowStem.GetComponent<LineRenderer>();
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }
}
