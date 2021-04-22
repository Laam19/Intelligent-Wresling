using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotatioSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horaizantalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horaizantalInput * Time.deltaTime * rotatioSpeed);
    }
}
