using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayer : MonoBehaviour
{

    // Update is called once per frame
    public float speed;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 47.9f)

        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            print(transform.position.x);
        }
        if (Input.GetKey(KeyCode.LeftArrow)&& transform.position.x > 33.7f)
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            print(transform.position.x);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Kraken")
        {
            print("you lose");
            // Destroy(gameObject);
        }
    }
}
