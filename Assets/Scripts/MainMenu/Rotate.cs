using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    void Update()
    {
        transform.Rotate(new Vector3(0f, rotationSpeed, 0f));
    }
}
