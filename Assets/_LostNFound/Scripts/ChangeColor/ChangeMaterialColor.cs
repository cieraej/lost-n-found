using UnityEngine;

using Curves;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(ChangeMaterialColor))]
public class ChangeMaterialColorEditor : Editor
{

    /// <summary>
    /// Buttons to be pressed on the inspector GUI 
    /// </summary> ]
    public override void OnInspectorGUI()
    {
        var showStopLoopButton = false;
        DrawDefaultInspector();

        ChangeMaterialColor myScript = (ChangeMaterialColor)target;

        if (GUILayout.Button("Animate Color"))
        {
            myScript.AnimateColor();
        }
        
        if (!showStopLoopButton)
        {

            if (GUILayout.Button("Loop Color"))
            {
                myScript.StartLooping();
                showStopLoopButton = true;
            }
        }
        else
        {
            if (GUILayout.Button("Stop Looping"))
            {
                myScript.StopLooping();
                showStopLoopButton = false;
            }
        }
    }
}
#endif

public class ChangeMaterialColor : MonoBehaviour
{
    [SerializeField]
    private Renderer _rendererToChange;
    [SerializeField]
    private int _rendererIndex = 0; 
  private Material _materialToChange;
    [SerializeField] private string _propertyToChange = "_Color";
    [SerializeField] private float _animationDuration = 2f;
    [SerializeField] private float _loopSensitivity = .5f;
    [SerializeField] private Curve _curve;
    [SerializeField] private SharedGradient _colorGradient;
    private Color _startColor;

    /// <summary>
    /// Enable the keywords for the material.
    /// </summary>
    private void Awake()
    {
        _materialToChange = _rendererToChange.materials[_rendererIndex];
        _materialToChange.EnableKeyword(_propertyToChange);
        _startColor = _materialToChange.GetColor(_propertyToChange);
    }

    private void OnApplicationQuit()
    {
        _materialToChange.SetColor(_propertyToChange, _startColor);
    }

    [ContextMenu("Animate Color")]
    public void AnimateColor()
    {
        StartCoroutine(CalculateCurve.AnimateColor(_curve, _materialToChange, _propertyToChange, _colorGradient.sharedGradient, _animationDuration));
    }

    public void StartLooping()
    {
        StartCoroutine(LoopColor());
    }

    public void StopLooping()
    {
        StopCoroutine(LoopColor());
    }

    private IEnumerator LoopColor()
    {
        while (true)
        {
            _materialToChange.SetColor(_propertyToChange, _colorGradient.sharedGradient.Evaluate(Mathf.PingPong(Time.time * _loopSensitivity, 1)));
            yield return null;
        }
    }
}
