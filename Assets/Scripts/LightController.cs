using UnityEngine;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{
    [SerializeField] private GameObject currentLight;
    [SerializeField] private Color[] colors;
    //1800k = candle light / 2700k = soft warm / 5250k = standard / 6500k = white
    //10.000k = cold / 20.000k = maxcold
    [SerializeField] private float[] temperatures;
    [SerializeField] private Slider temperatureSlider;
    [SerializeField] private Slider horizontalSlider;
    [SerializeField] private Slider verticalSlider;

    private int colorIndex = 0; 
    private int temperatureIndex = 0;

    //Schaltet Licht an/aus
    public void ChangeLightState()
    {
        if (currentLight.gameObject.activeInHierarchy)
            currentLight.gameObject.SetActive(false);     
        else
            currentLight.gameObject.SetActive(true);
    }

    //wechselt die Farbe des Lichts anhand des Indexer
    public void ChangeLightColor()
    {
        int maxIndex = colors.Length -1;

        if (colorIndex == maxIndex)
            colorIndex = 0;
        else
            colorIndex++;

        //testen ob es funzt? 
        currentLight.GetComponent<Light>().color = colors[colorIndex];
    }

    //wechselt die Temperatur des Lichtes
    public void ChangeLightTemperature()
    {
        int maxIndex = temperatures.Length - 1;

        if (temperatureIndex == maxIndex)
            temperatureIndex = 0;
        else
            temperatureIndex++;

        //testen ob es funzt? 
        currentLight.GetComponent<Light>().colorTemperature = temperatures[temperatureIndex];
    }

    //wechselt die Intensität des Lichtes anhand des Sliders
    public void ChangeLightIntensity()
    {
       currentLight.GetComponent<Light>().intensity = temperatureSlider.value;
    }

    //lässt das Licht rotieren
    public void ChangeLightDirection()
    {
        Vector3 newDirection = new Vector3(horizontalSlider.value, verticalSlider.value, 0.0f);
        currentLight.transform.Rotate(newDirection * Time.deltaTime);
    }
}
