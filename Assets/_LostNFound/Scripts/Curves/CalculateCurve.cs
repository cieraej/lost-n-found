using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Curves
{
    public class CalculateCurve : MonoBehaviour
    {
        public static IEnumerator AnimatePosition(Curve curve, Transform toMove, Vector3 origin, Vector3 target, float duration, bool shouldClamp)
        {
            float currentDuration = 0;
            while (currentDuration < duration)
            {
                currentDuration += Time.deltaTime;

                if (shouldClamp)
                {
                    toMove.position = Vector3.Lerp(origin, target, curve.Evaluate(currentDuration / duration));
                }
                else
                {
                    toMove.position = Vector3.LerpUnclamped(origin, target, curve.Evaluate(currentDuration / duration));
                }
                yield return null;
            }
        }


        public static IEnumerator AnimateRotation(Curve curve, Transform toMove, Quaternion origin, Quaternion target, float duration, bool shouldClamp)
        {
            float currentDuration = 0;
            while (currentDuration < duration)
            {
                currentDuration += Time.deltaTime;
                if (shouldClamp)
                {
                    toMove.rotation = Quaternion.Lerp(origin, target, curve.Evaluate(currentDuration / duration));
                }
                else
                {
                    toMove.rotation = Quaternion.LerpUnclamped(origin, target, curve.Evaluate(currentDuration / duration));
                }
                yield return null;
            }
        }


        public static IEnumerator AnimateScale(Curve curve, Transform toMove, Vector3 origin, Vector3 target, float duration, bool shouldClamp)
        {
            float currentDuration = 0;
            while (currentDuration < duration)
            {
                currentDuration += Time.deltaTime;
                if (shouldClamp)
                {
                    toMove.localScale = Vector3.Lerp(origin, target, curve.Evaluate(currentDuration / duration));
                }
                else
                {
                    toMove.localScale = Vector3.LerpUnclamped(origin, target, curve.Evaluate(currentDuration / duration));
                }
                yield return null;
            }
        }


        public static IEnumerator AnimateColor(Curve curve, Material material, string property , Gradient gradient, float duration)
        {
            float currentDuration = 0;
            while (currentDuration < duration)
            {
                currentDuration += Time.deltaTime;
                material.SetColor(property, gradient.Evaluate(curve.Evaluate(currentDuration / duration)));
                yield return null;
            }
        }
    }
}
