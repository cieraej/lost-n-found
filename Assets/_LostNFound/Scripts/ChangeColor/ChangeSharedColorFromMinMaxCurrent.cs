using UnityEngine;
using Curves;

public class ChangeSharedColorFromMinMaxCurrent : MonoBehaviour
{
    [SerializeField] private SharedColor _sharedColor;
    [SerializeField] private SharedGradient _colorGrandient;
    [SerializeField] private Curve _curve;
    [SerializeField] private SharedNormalisedFloat value; 

    void Update()
    {
        print("Clamped Normal " + value.NormaliseClamped() + " current " + value.value);
            _sharedColor.value = _colorGrandient.sharedGradient.Evaluate(_curve.Evaluate(value.NormaliseClamped()));
    }
}
