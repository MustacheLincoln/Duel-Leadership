using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    private float _speed = 5f;
    public float _energy = 100f;
    public Employer _employer;
    public Home _home;
    public Vector3 _destination;
    public GameObject _shanty;

    void Update()
    {
        StateMachine();
        Walk();
    }

    void StateMachine()
    {
        if (_energy >= 100)
        {
            if (_employer == null)
            {
                FindJob();
                return;
            }
            _destination = _employer.transform.position;
        }
               
        if (_energy <= 0)
        {
            if (_home == null)
            {
                FindHome();
                return;
            }
            _destination = _home.transform.position;
        }
    }

    void FindJob()
    {
        foreach (Employer employer in GameObject.FindObjectsOfType<Employer>())
        {
            if (employer._enabled == true)
            {
                if (employer._workers.Count < employer._jobs)
                {
                    employer._workers.Add(gameObject);
                    _employer = employer;
                }
            }
        }
    }

    void FindHome()
    {
        foreach (Home home in GameObject.FindObjectsOfType<Home>())
        {
            if (home._enabled == true)
            {
                if (home._residents.Count < home._rooms)
                {
                    home._residents.Add(gameObject);
                    _home = home;
                    return;
                }
            }
        }
        Instantiate(_shanty, new Vector3(_employer.transform.position.x + Random.Range(-5,5), _employer.transform.position.y - transform.lossyScale.y / 2, _employer.transform.position.z + Random.Range(-5, 5)), Quaternion.identity);
    }

    void Walk()
    {
        if (Vector3.Distance(transform.position, _destination) >= .1)
        {
            var direction = (transform.position - _destination).normalized;
            transform.position -= direction * Time.deltaTime * _speed;
        }
        else
        {
            if (_employer)
                if (_destination == _employer.transform.position)
                    AtWork();
            if (_home)
                if (_destination == _home.transform.position)
                    AtHome();
        }
    }

    void AtWork()
    {
        _energy -= 10 * Time.deltaTime;
    }

    void AtHome()
    {
        _energy += 10 * Time.deltaTime;
    }

    void Die()
    {
        _employer._workers.Remove(gameObject);
        Destroy(gameObject);
    }
}
