using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Planet1 : MonoBehaviour
{
    public static Planet PlanetData { get; set; }
    private TextMeshProUGUI planetTitle;
    private TextMeshProUGUI planetFeatures;
    public Planet1()
    {
        PlanetData = new Planet();     
    }

    private void Awake()
    {

        planetTitle = GameObject.Find("PlanetNameTitle").GetComponent<TextMeshProUGUI>();
        planetFeatures = GameObject.Find("Features").GetComponent<TextMeshProUGUI>();
        PlanetData.Init("First Planet");
       


    }

    void Update()
    {
        if (gameObject.activeSelf)
        {
            PrintDetails();
        }
    }

    void PrintDetails()
    {
        planetTitle.text = PlanetData.NameTitle;
        Debug.Log(PlanetData.NameTitle);
        planetFeatures.text = PlanetData.PrintFeatures();
        Debug.Log(PlanetData.PrintFeatures());
    }

}
