using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreboardManager : MonoBehaviour
{
    private TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = transform.Find("Score").GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + GameManager.instance.score;
    }
}
