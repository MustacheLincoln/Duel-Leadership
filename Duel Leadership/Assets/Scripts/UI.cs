using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    //Temp
    public GameObject _toBuild;
    private GameObject _building;

    private void Update()
    {
        if (_building)
            if (_building.GetComponent<Building>()._built == false)
                _building.GetComponent<Building>().Build();
    }

    public void OnBuildButtonPress()
    {
        _building = Instantiate(_toBuild, new Vector3(1000, 1000, 1000) , Quaternion.identity);
        _building.GetComponent<Building>().Build();
    }
}