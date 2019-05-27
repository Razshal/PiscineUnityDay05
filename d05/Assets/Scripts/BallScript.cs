using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
    public GameObject objectiveHole;
    new private Rigidbody rigidbody;
    public GameObject forceBar;
    new private GameObject camera;


    void Start () {
        gameObject.transform.LookAt(objectiveHole.transform.position);
        rigidbody = gameObject.GetComponent<Rigidbody>();
        camera = Camera.main.gameObject;
	}

    private void FixedUpdate()
    {
        if (rigidbody.velocity.Equals(Vector3.zero))
        {
            if (Input.GetKeyDown(KeyCode.Space) && !forceBar.activeSelf)
            {
                forceBar.SetActive(true);
            }
            if (forceBar.activeSelf)
                transform.rotation = camera.transform.rotation;
        }
    }
}
