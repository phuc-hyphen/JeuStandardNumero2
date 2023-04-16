using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movingCam : MonoBehaviour
{
    public Transform target;
    private Vector3 _origine;
    private Vector3 _difference;
    private Camera _camera;

    private bool _isDragging;

    public float speed = 5f;
    public float limit_right = 200f;
    public float limit_left = -200f;
    public float limit_up = 200f;
    public float limit_down = -200f;
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            GameObject[] currentplanets = GameObject.FindGameObjectsWithTag("currentPlanet");
            if (currentplanets.Length == 1)
            {
                target = currentplanets[0].transform;
            }
        }
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        // var speed = 5f;
        // if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < limit_right)
        // {
        //     transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        // }
        // if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > limit_left)
        // {
        //     transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        // }
        // if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < limit_up)
        // {
        //     transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        // }
        // if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > limit_down)
        // {
        //     transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        // }

    }

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void OnDrag(InputAction.CallbackContext context)
    {
        if (context.started) _origine = getMousePosition;
        _isDragging = context.performed || context.started;
    }

    public void LateUpdate()
    {
        if (!_isDragging)
            return;

        _difference = getMousePosition - transform.position;
        transform.position = _origine - _difference;
    }
    private Vector3 getMousePosition => _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
}
