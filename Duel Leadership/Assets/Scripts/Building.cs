using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    Ray _ray;
    RaycastHit _hit;
    public bool _built = true;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        if (_built == false)
        {
            //Make transparent here

            //Mouse Position in World
            _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit, Mathf.Infinity, ~3))
            {
                transform.position = new Vector3(_hit.point.x, _hit.point.y + transform.lossyScale.y / 2, _hit.point.z);
                Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, 3);
                if (hitColliders.Length <= 1)
                {
                    //Make normal color here
                    if (Input.GetMouseButtonDown(0))
                    {
                        _built = true;
                        //Make Untransparent here
                    }
                }
                else
                    Destroy(gameObject); //Replace with turn Red
            }
            else
                Destroy(gameObject); //Replace with 0 Alpha
        }
    }
}
