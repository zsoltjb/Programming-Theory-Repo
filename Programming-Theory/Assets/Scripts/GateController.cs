using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateController : MonoBehaviour
{
    public bool turnTheWheel = false;
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

    private void OnTriggerEnter(Collider other)
    {
        turnTheWheel = true;
        StartCoroutine(WaitForIt());
    }

    private void OnTriggerExit(Collider other)
    {
        turnTheWheel = false;
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(3);
        if (turnTheWheel)
        {
            SceneManager.LoadScene(1);
        }
        
    }
}
