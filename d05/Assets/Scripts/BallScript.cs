using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
    public GameObject objectiveHole;
    new private Rigidbody rigidbody;
    public GameObject forceBar;
    new private GameObject camera;
    public bool replaceCam = false;


    void Start () {
        gameObject.transform.LookAt(objectiveHole.transform.position);
        rigidbody = gameObject.GetComponent<Rigidbody>();
        camera = Camera.main.gameObject;
	}

    private void FixedUpdate()
    {
        if (rigidbody.velocity.Equals(Vector3.zero))
        {
            if (!replaceCam)
            {
                camera.GetComponent<CameraScript>().ReplaceToball();
                replaceCam = true;
            }

            if (forceBar.activeSelf)
                transform.rotation = camera.transform.rotation;
        }
    }
}
