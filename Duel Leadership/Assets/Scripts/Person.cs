using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    private float _personSpeed = 5f;

    void Update()
    {
        Walk();
    }

    void Walk()
    {
        transform.position += Vector3.right * Time.deltaTime * _personSpeed;
    }
}
