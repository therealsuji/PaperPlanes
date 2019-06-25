using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class scoreController : MonoBehaviour
{
    int score = 0;
    EnergyController energyController;
    AudioSource audioSoucre;
    public AudioClip pointClip;
    new Rigidbody rigidbody;
    void Start()
    {
        GameManager.instance.score.text = "0";
        GameManager.instance.finalScore.text = "0";
        energyController = GetComponent<EnergyController>();
        audioSoucre = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();

    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "scoreCollider")
        {
            audioSoucre.clip = pointClip;
            audioSoucre.Play();
            rigidbody.AddRelativeForce(Vector3.forward * 0.5f, ForceMode.Impulse);
            energyController.energy = 100f;
            score += 5;
            GameManager.instance.score.text = score.ToString();

        }
        else if (other.transform.tag == "deathCollider")
        {
            GameManager.instance.playerDead = true;
            GameManager.instance.finalScore.text = score.ToString();
        }

    }
}
