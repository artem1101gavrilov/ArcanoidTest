using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : Cube
{
    private float speed = 1;

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
        SetBorder();
    }

    public void SetBonus()
    {
        spriteRenderer.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1);
    }
}