using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour {
    public float movementSpeed = 1;
    public float rotateSpeed = 2.0f;
    private Vector3 direction;
    public bool isLocked = false;
    private GameObject ball;

    private void Start()
    {
        ball = GameObject.Find("Ball");
        transform.position = ball.transform.position;
        transform.LookAt(ball.GetComponent<BallScript>().objectiveHole.transform);
    }

    private void FixedUpdate()
    {
        if (!isLocked)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isLocked = true;
                transform.position = ball.transform.position;
            }
            Vector3 Direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetAxis("Vertical"));
            transform.Translate(Direction * movementSpeed);
        }

        if (isLocked && Input.GetKeyDown(KeyCode.E))
            isLocked = false;

        if (Input.GetMouseButton(1) || Input.GetKey(KeyCode.LeftAlt))
        {
            direction = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f) * rotateSpeed;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + direction);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
