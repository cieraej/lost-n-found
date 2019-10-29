using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTextMeshColor : MonoBehaviour {

    public Gradient colorGradient;
    public float min, max;
    public float changeSensitity = 100f; 
    public SharedFloat _colorValue;
    public TextMesh textMesh;
  
    private void Update()
    {
        LerpColor();
    }
    public void LerpColor()
    {
        textMesh.color = Color.Lerp(textMesh.color, colorGradient.Evaluate(NormalizeValue(_colorValue.value, min, max)), Time.deltaTime* changeSensitity);
    }

    public static float NormalizeValue(float value, float min, float max)
    {
        return (value - min) / (max - min);
    }

}
