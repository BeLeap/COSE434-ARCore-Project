using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoleManager : MonoBehaviour
{
    public ParticleSystem fireWork;
    private bool isPlaying = false;

    private Text label;

    private void Start()
    {
        label = GameObject.Find("Text").GetComponent<Text>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
            fireWork.gameObject.transform.position = this.transform.position;
            if (!isPlaying)
            {
                isPlaying = true;
                ParticleSystem fireWorkParticle = Instantiate(fireWork, this.transform);
                fireWorkParticle.Play();
                isPlaying = false;
            }
            label.text = "Game End!!";
            Invoke("Quit", 5);
        }
    }

    private void Quit()
    {
        Application.Quit();
    }
}
