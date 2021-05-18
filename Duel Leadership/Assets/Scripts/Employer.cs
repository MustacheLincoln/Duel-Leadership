using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employer : MonoBehaviour
{
    public List<GameObject> workers;
    public int jobs;
    public Building _building;

    private void Awake()
    {
        _building = GetComponent<Building>();
    }
}
