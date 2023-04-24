using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MovingPlayer : MonoBehaviour
{
    public TextMeshProUGUI timer_display;
    public GameObject intrustion;
    // Update is called once per frame
    public float speed;
    private float timer = 180.0f;
    public void start()
    {
        timer_display.text = "03:00";
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            string minutes = Mathf.Floor(timer / 60).ToString("00");
            string seconds = Mathf.Floor(timer % 60).ToString("00");
            timer_display.text = minutes + ":" + seconds;
        }
        if (timer < 120)
        {
            intrustion.SetActive(false);
        }
        // myTime = myTime - 1;
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 47.9f)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > 30.7f)
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Kraken")
        {
            print("you lose");
            // Destroy(gameObject);
            SceneManager.LoadScene(3);
        }
    }
}
