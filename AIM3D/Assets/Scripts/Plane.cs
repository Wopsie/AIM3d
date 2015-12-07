﻿using UnityEngine;
using System.Collections;

public class Plane : MonoBehaviour {

    private float speed = 90f;

    void FixedUpdate()
    {
        transform.position += transform.forward * Time.deltaTime * speed;

        speed -= transform.forward.y * Time.deltaTime * 50f;

        //minimum & maximum speed
        if (speed < 45f)
        {
            speed = 45f;
        }
        else if (speed > 160f)
        {
            speed = 160f;
        }

        transform.Rotate(Input.GetAxis("Vertical") * 1.5f, 0.0f, -Input.GetAxis("Horizontal") * 1.8f);

        Debug.Log(transform.rotation);
    }
}