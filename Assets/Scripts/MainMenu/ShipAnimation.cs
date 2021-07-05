using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAnimation : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] float z;

    void Update()
    {

        transform.rotation.SetFromToRotation(new Vector3(0,0,0), new Vector3(0,0,100));

    }
}
