using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(HapticFeedback))]
public class HapticFeedbackEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        HapticFeedback myScript = (HapticFeedback)target;

        if (GUILayout.Button("Vibrate"))
        {
            myScript.Vibrate();
        }
    }
}
#endif

[CreateAssetMenu(menuName = "Feedback/Haptics")]
public class HapticFeedback : ScriptableObject
{
    [MinMaxRange(0, 1)]
    [SerializeField] private RangedFloat _frequency;

    [MinMaxRange(0, 1)]
    [SerializeField] private RangedFloat _amplitude;

    [MinMaxRange(0, 2)]
    [SerializeField] private RangedFloat _time;


    [SerializeField] public OVRInput.Controller controllerMask;
    
    public void Vibrate()
    {
        OVRInput.SetControllerVibration(Random.Range(_frequency.minValue, _frequency.maxValue), Random.Range(_amplitude.minValue, _amplitude.maxValue), controllerMask);
       
    }

    public IEnumerator WaitASec()
    {
        yield return new WaitForSeconds(Random.Range(_time.minValue, _time.maxValue));
         OVRInput.SetControllerVibration(0, 0, controllerMask);
    }
}