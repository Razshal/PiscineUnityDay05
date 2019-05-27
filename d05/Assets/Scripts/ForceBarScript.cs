using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceBarScript : MonoBehaviour {
    public Slider slider;
    private GameObject ball;
    private bool up = true;
    public float forceMultiplier = 10;

	// Use this for initialization
	void Start ()
    {
        ball = GameObject.Find("Ball");
	}

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ball.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * slider.value * forceMultiplier);
            ball.GetComponent<BallScript>().replaceCam = false;
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        slider.value = up ? slider.value + 1 : slider.value - 1;

        if (up && slider.value >= slider.maxValue)
            up = false;
        else if (!up && slider.value <= slider.minValue)
            up = true;
    }
}
