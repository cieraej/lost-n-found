using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Curves
{
    [CreateAssetMenu(menuName = "Curve/Simple")]
    public class Curve : ScriptableObject
    {
        [SerializeField] private AnimationCurve _animationCurve = new AnimationCurve(new Keyframe(0, 0, 1, 1), new Keyframe(1, 1, 1, 1));

        public float Evaluate(float percent)
        {
            return _animationCurve.Evaluate(percent);
        }

        public float EvaluateWithParameter(float percent, float min, float max )
        {
           return (_animationCurve.Evaluate(percent) * (max - min)) + min;
        }
    }
}
