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
