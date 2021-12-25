using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateController : MonoBehaviour
{
    public bool gateActive = false;
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        gateActive = true;
       
        StartCoroutine(WaitForIt());
    }

    private void OnTriggerExit(Collider other)
    {
        gateActive = false;
       
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(1);
        if (gateActive)
        {
            SceneManager.LoadScene(1);
        }
        
    }
}
