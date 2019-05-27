using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceBarScript : MonoBehaviour {
    public Slider slider;
    private GameObject ball;
    private bool up = true;

	// Use this for initialization
	void Start () {
        ball = GameObject.Find("Ball");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && !slider.enabled)
        {
            slider.enabled = true;
        }
        if (slider.enabled)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ball.GetComponent<Rigidbody>().AddForce(Vector3.forward * slider.value * 100);
                slider.enabled = false;
            }

            slider.value = up ? slider.value + 1 : slider.value - 1;

            if (up && slider.value >= slider.maxValue)
                up = false;
            else if (!up && slider.value <= slider.minValue)
                up = true;
        }
	}
}
