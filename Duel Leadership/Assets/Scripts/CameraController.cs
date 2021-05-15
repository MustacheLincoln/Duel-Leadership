using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private readonly float _baseCameraSpeed = 10f;
    private readonly float _screenEdge = 1f;

    void Update()
    {
        //Speed Modifier
        var _cameraSpeed = _baseCameraSpeed * ((transform.position.y + 1) / 2);

        //WASD Scrolling
        if (Input.GetKey(KeyCode.W))
            transform.position += Vector3.forward * Time.deltaTime * _cameraSpeed;

        if (Input.GetKey(KeyCode.A))
            transform.position += Vector3.left * Time.deltaTime * _cameraSpeed;

        if (Input.GetKey(KeyCode.S))
            transform.position += Vector3.back * Time.deltaTime * _cameraSpeed;

        if (Input.GetKey(KeyCode.D))
            transform.position += Vector3.right * Time.deltaTime * _cameraSpeed;

        //Edge Scrolling
        if (Input.mousePosition.y >= Screen.height - _screenEdge)
            transform.position += Vector3.forward * Time.deltaTime * _cameraSpeed;

        if (Input.mousePosition.x <= 0 + _screenEdge)
            transform.position += Vector3.left * Time.deltaTime * _cameraSpeed;

        if (Input.mousePosition.y <= 0 + _screenEdge)
            transform.position += Vector3.back * Time.deltaTime * _cameraSpeed;

        if (Input.mousePosition.x >= Screen.width - _screenEdge)
            transform.position += Vector3.right * Time.deltaTime * _cameraSpeed;

        //Zoom
        transform.position -= new Vector3(0, Input.mouseScrollDelta.y, 0);
        transform.eulerAngles -= new Vector3(Input.mouseScrollDelta.y, 0, 0);
    }
}
