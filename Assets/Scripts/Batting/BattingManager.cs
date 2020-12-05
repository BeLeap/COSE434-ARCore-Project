using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class BattingManager : MonoBehaviour
{
    public TMP_Text textMesh;
    void Update()
    {
        textMesh.text = "Batting: " + GameManager.instance.batting.ToString();
    }
}
