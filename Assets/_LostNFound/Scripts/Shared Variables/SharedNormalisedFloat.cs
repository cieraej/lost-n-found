using UnityEngine;
[CreateAssetMenu(menuName = "Float/MinMaxCurrent")]
public class SharedNormalisedFloat: SharedFloat
{
    [SerializeField] private float min;
    [SerializeField] private float max;

    public float normalised; 

    public float Normalise()
    {
        normalised = (value - min) / (max - min);
        return normalised; 
    }

    public float NormaliseClamped()
    {
        normalised = Mathf.Clamp01((value - min) / (max - min));
        return normalised; 
    }
}