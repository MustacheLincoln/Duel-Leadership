using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    //Temp
    public GameObject _building;

    public void OnBuildButtonPress()
    {
        var building = Instantiate(_building, new Vector3(1000, 1000, 1000) , Quaternion.identity);
        building.GetComponent<Building>()._built = false;
    }
}