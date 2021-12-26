using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Base class for all Planet
public class Planet : MonoBehaviour
{
    public string NameTitle { get; set; }
    protected List<string> AtmosphereComponents { get; set; }
    protected float[] TemperatureRange { get; set; }
    protected float DayLength { get; set; }
    protected float AvgSunlightADay { get; set; }
    protected string Inhabited { get; set; }
    protected float Size { get; set; }
    protected int SceneNumber { get; set; }

    public virtual void Init(string planetName = "Unknown")
    {
        NameTitle = planetName;
        AtmosphereComponents = new List<string>() { "Atmosphere components:\n","Oxygen - 60%", "Carbondioxide - 30%", "other - 10%" };
        TemperatureRange = new float[2] { Mathf.Round(Random.Range(-200.0f, 0)), Mathf.Round(Random.Range(0, 200.0f))};
        DayLength = Mathf.Round(Random.Range(3.0f, 48.0f));
        AvgSunlightADay = Mathf.Round(Random.Range(1.0f, DayLength));
        Inhabited = "Unknown";
        // not to be displayed
        Size = 1.0f;
        SceneNumber = 0;
    }
    //Places all features in one string with line breaks included
    public string PrintFeatures()
    {
        string allFeatures;

        allFeatures = $"{Iterator(AtmosphereComponents)}\n\n" +
                      $"Temperature range: {TemperatureRange[0]}°C, {TemperatureRange[1]}°C\n\n" +
                      $"Day length: {DayLength} gHours\n\n" +
                      $"Average sunlight a day: {AvgSunlightADay} gHours\n\n" +
                      $"Inhabited: {Inhabited}";

        return allFeatures;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual string Iterator(List<string> listContent)
    {
        string result = "";
        
        foreach (string item in listContent)
        {
            result += $"{ item } \n";
        }
        
        return result;
    }
}
