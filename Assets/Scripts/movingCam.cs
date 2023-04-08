using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingCam : MonoBehaviour
{
    // // Start is called before the first frame update
    // void Start()
    // {

    // }
    public float speed = 5f;
    // Update is called once per frame
    void Update()
    {
        // var speed = 5f;
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 96.26)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow)&& transform.position.x > 33.26)
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }

    }
}
