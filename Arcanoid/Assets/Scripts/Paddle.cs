using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : Cube
{
    private float speed = 2;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (!Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}