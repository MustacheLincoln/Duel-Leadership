using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shanty : Home
{
    void Start()
    {
        _rooms = 1;
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, LayerMask.GetMask("Buildings"));
        if (hitColliders.Length > 1)
            Destroy(gameObject);
    }
}
