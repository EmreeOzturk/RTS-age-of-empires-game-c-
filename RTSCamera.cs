using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSCamera : MonoBehaviour
{

    float speed = 10.0f; // navigation speed when using WASD keys
    float zoomSpeed = 200.0f; // zoom speed when scrolling mouse wheel
    float rotationSpeed = 0.1f; // rotation speed on middle mouse button
    float minZoom = 3.0f; // minimum zoom distance
    float maxZoom = 30.0f; // maximum zoom distance

    Vector2 p1;
    Vector2 p2;
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20.0f;
            zoomSpeed = 400.0f;
        }
        else
        {
            speed = 10.0f;
            zoomSpeed = 200.0f;
        }

        float horizontalSpeed = speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        float verticalSpeed = speed * Input.GetAxis("Vertical") * Time.deltaTime;
        float scrollSpeed = (float)(Math.Log(transform.position.y) * -zoomSpeed * Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime);


        if ((transform.position.y <= minZoom && (scrollSpeed < 0)) || (transform.position.y >= maxZoom && (scrollSpeed > 0)))
        {
            scrollSpeed = 0;
        }
        if ((transform.position.y + scrollSpeed) < minZoom)
        {
            scrollSpeed = minZoom - transform.position.y;
        }
        if ((transform.position.y + scrollSpeed) > maxZoom)
        {
            scrollSpeed = maxZoom - transform.position.y;
        }


        Vector3 verticalMovement = new(0, scrollSpeed, 0);
        Vector3 horizontalMovement = horizontalSpeed * transform.right;
        Vector3 forwardMovement = transform.forward;

        forwardMovement.y = 0;
        forwardMovement.Normalize();
        forwardMovement *= verticalSpeed;

        Vector3 movement = verticalMovement + horizontalMovement + forwardMovement;
        transform.position += movement;


        getCameraMovement();
    }

    void getCameraMovement()
    {
        if (Input.GetMouseButtonDown(2)) // check middle mouse button pressed
        {
            p1 = Input.mousePosition;
        }
        if (Input.GetMouseButton(2))   // check middle mouse button held
        {
            p2 = Input.mousePosition;
            float dx = (p2 - p1).x * rotationSpeed;
            float dy = (p2 - p1).y * rotationSpeed;

            transform.Rotate(new Vector3(0, dx, 0), Space.World);
            transform.Rotate(new Vector3(-dy, 0, 0), Space.Self);

            p1 = p2;
        }

    }
}
