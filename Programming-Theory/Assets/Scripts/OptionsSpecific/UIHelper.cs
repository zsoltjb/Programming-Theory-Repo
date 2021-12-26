using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.UI;

public class UIHelper : MonoBehaviour
{
    [Header("Available Planets")]
    [SerializeField] private List<GameObject> planetList;
  

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextBtn()
    {
        int current = FindActive();
        planetList[current].SetActive(false);
        planetList[current < planetList.Count-1 ? current + 1 : 0].SetActive(true);
        Debug.Log("Active planet's num" + current);
    }
    public void PreviousBtn()
    {
        int current = FindActive();
        planetList[current].SetActive(false);
        planetList[current > 0 ? current - 1 : planetList.Count-1].SetActive(true);
        Debug.Log("Active planet's num" + current);
    }

    int FindActive()
    {
        int activeObj = 0;
        for (int i = 0; i < planetList.Count; i++)
        {
            if (planetList[i].activeInHierarchy)
            {
                activeObj = i;
            }
        }
        
        return activeObj;
    }

    

}
