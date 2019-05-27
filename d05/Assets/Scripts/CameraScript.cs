using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public float movementSpeed = 1;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    public float speedY = 2.0f;
    public float speedX = 2.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 Direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetAxis("Vertical"));
        transform.Translate(Direction * movementSpeed);

        if (Input.GetMouseButton(1) || Input.GetKey(KeyCode.LeftAlt))
        {
            yaw += speedY * Input.GetAxis("Mouse X");
            pitch -= speedX * Input.GetAxis("Mouse Y");
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles 
                                                  + new Vector3(speedY * -Input.GetAxis("Mouse Y"), 
                                                                speedX * Input.GetAxis("Mouse X"), 
                                                                0f));
        }
    }
}
