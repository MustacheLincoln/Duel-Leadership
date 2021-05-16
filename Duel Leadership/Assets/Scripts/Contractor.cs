using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contractor : MonoBehaviour
{
    private Employer _HR;

    private void Start()
    {
        _HR = GetComponent<Employer>();
        _HR.jobs = 4;
    }

    private void Update()
    {
        foreach (GameObject worker in _HR.workers)
        {
            break;
        }
    }
}
