using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    private float _personSpeed = 5f;
    public bool _employed = false;
    public GameObject _employer;

    void Update()
    {
        Walk();

        if (_employed == false)
        {
            foreach (GameObject employer in GameObject.FindGameObjectsWithTag("Employer"))
            {
                if (employer.GetComponent<Employer>().workers.Count < employer.GetComponent<Employer>().jobs)
                {
                    employer.GetComponent<Employer>().workers.Add(this.gameObject);
                    _employer = employer;
                    _employed = true;
                }
            }
        }
    }

    void Walk()
    {
        transform.position += Vector3.right * Time.deltaTime * _personSpeed;
    }
}
