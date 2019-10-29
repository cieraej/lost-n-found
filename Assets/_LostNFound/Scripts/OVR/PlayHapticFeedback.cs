using System.Collections;
using UnityEngine;

public class PlayHapticFeedback : MonoBehaviour
{
    public float _frequency = .5f;
    public float _amplitude = .5f;
    public float _length = .5f;

    [SerializeField] public OVRInput.Controller controllerMask;


    public void PlayFeedback()
    {
        StopAllCoroutines();
        OVRInput.SetControllerVibration(_frequency, _amplitude, controllerMask);
        StartCoroutine(Wait());

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(_length);
        OVRInput.SetControllerVibration(0, 0, controllerMask);


    }
}