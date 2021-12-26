using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Planet2 : MonoBehaviour
{
    public Planet PlanetData { get; set; }
    private TextMeshProUGUI planetTitle;
    private TextMeshProUGUI planetFeatures;
    public Planet2()
    {
        PlanetData = new Planet();
    }

    private void Awake()
    {

        planetTitle = GameObject.Find("PlanetNameTitle").GetComponent<TextMeshProUGUI>();
        planetFeatures = GameObject.Find("Features").GetComponent<TextMeshProUGUI>();
        PlanetData.Init("Second Planet");
        Debug.Log("Second Planet Awake");

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
