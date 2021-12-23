using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public bool turnTheWheel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    transform.Rotate(Vector3.right);
    //    Debug.Log("shud rotate");
    //}

    private void OnTriggerStay(Collider other)
    {
        transform.Rotate(Vector3.back);
    }
}
