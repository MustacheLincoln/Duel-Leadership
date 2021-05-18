using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    private float _speed = 5f;
    public bool _employed = false;
    public Employer _employer;
    public Vector3 _destination;

    void Update()
    {
        Walk();

        if (_employed == false)
        {
            foreach (Employer employer in GameObject.FindObjectsOfType<Employer>())
            {
                if (employer._building._enabled == true)
                {
                    if (employer.workers.Count < employer.jobs)
                    {
                        employer.workers.Add(gameObject);
                        _employer = employer;
                        _employed = true;
                    }
                }
            }
        }
    }

    void Walk()
    {
        if (_employed == true)
        {
            _destination = _employer.transform.position;
            var direction = (transform.position - _destination).normalized;
            transform.position -= direction * Time.deltaTime * _speed;
        }
    }

    void Die()
    {
        _employer.workers.Remove(gameObject);
        Destroy(gameObject);
    }
}
