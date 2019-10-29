using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSharedColor : MonoBehaviour
{
    [SerializeField] private Color color;
    [SerializeField] private SharedColor sharedColor;

    private Color previousColor;

    private void Awake()
    {
        previousColor = color; 
    }
    public void ChangeColor()
    {
        sharedColor.value = color;
    }
    private void Update()
    {
        if(previousColor != color)
        {
            ChangeColor(); 
        }

        previousColor = color; 
    }
}
