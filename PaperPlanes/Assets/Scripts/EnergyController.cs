using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergyController : MonoBehaviour
{
    public float energy = 100;
    public Image energyBar;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (energy <= 0)
        {
            GameManager.instance.playerDead = true;
        }
        if (Input.touchCount > 0)
        {
            energy -= 0.7f;
        }
        energyBar.fillAmount = energy / 100;

    }
}
