using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
    private GameObject mainCamera;

	void Start () {
        mainCamera = Camera.main.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = mainCamera.transform.rotation;
	}
}
