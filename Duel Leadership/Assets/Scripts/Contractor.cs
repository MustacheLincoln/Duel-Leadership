using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contractor : MonoBehaviour
{
    private Employer _employer;

    private void Start()
    {
        _employer = GetComponent<Employer>();
        _employer.jobs = 4;
    }

    private void Update()
    {
        foreach (GameObject worker in _employer.workers)
        {
            break;
        }
    }
}
