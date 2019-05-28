using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    public float movementSpeed = 1;
    public float rotateSpeed = 2.0f;
    private Vector3 direction;
    public bool isLocked = false;
    private GameObject ball;
    public GameObject forceBar;

    public void ReplaceToball()
    {
        ball.transform.rotation = Quaternion.identity;
        transform.position = ball.transform.position - (ball.transform.right * 20) + ball.transform.up * 5;
        transform.LookAt(ball.GetComponent<BallScript>().objectiveHole.transform);
    }

    private void Start()
    {
        ball = GameObject.Find("Ball");
        ReplaceToball();
    }

    private void FixedUpdate()
    {
        if (!isLocked)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isLocked = true;
                ReplaceToball();
            }
            Vector3 Direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetAxis("Vertical"));
            transform.Translate(Direction * movementSpeed);
            if (Input.GetMouseButton(1) || Input.GetKey(KeyCode.LeftAlt))
            {
                direction = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f) * rotateSpeed;
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + direction);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && !forceBar.activeSelf)
            {
                forceBar.SetActive(true);
                ReplaceToball();
            }
            if (Input.GetKeyDown(KeyCode.E))
                isLocked = false;
            transform.Translate(Input.GetAxis("Horizontal"), 0, 0);
            transform.LookAt(ball.transform);
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
