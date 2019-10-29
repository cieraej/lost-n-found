using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Curves;
public class AnimateTransformToLocalVector : MonoBehaviour
{
    /// <summary>
    /// Duration of the change.
    /// </summary>
    [SerializeField] private float _duration = 1f;

    [SerializeField] private Vector3 _moveTo = Vector3.zero;
    /// <summary>
    /// Animation curve it will follow.
    /// </summary>
    [SerializeField] private Curve _curve;


    /// <summary>
    /// Matches position.
    /// </summary>
    [ContextMenu("Animate Position")]
    public void AnimatePosition()
    {
        StartCoroutine(CalculateCurve.AnimatePosition(_curve, this.transform, this.transform.localPosition, _moveTo, _duration, true));
    }

    public static IEnumerator AnimatePosition(Curve curve, Transform toMove, Vector3 origin, Vector3 target, float duration, bool shouldClamp, bool local)
    {
        float currentDuration = 0;
        while (currentDuration < duration)
        {
            currentDuration += Time.deltaTime;

            if (shouldClamp)
            {
                if (!local)
                {
                    toMove.position = Vector3.Lerp(origin, target, curve.Evaluate(currentDuration / duration));
                }
                else
                {
                    toMove.localPosition = Vector3.Lerp(origin, target, curve.Evaluate(currentDuration / duration));

                }
            }
            else
            {
                if (!local)
                {
                    toMove.position = Vector3.LerpUnclamped(origin, target, curve.Evaluate(currentDuration / duration));
                }
                else
                {
                    toMove.localPosition = Vector3.LerpUnclamped(origin, target, curve.Evaluate(currentDuration / duration));
                }
            }
            yield return null;
        }
    }

    /// <summary>
    /// Matches Rotation.
    /// </summary>
    [ContextMenu("Animate Rotation")]
    public void AnimateRotation()
    {
       // StartCoroutine(CalculateCurve.AnimateRotation(_curve, _toMove, _toMove.rotation, _moveTo.rotation, _duration, true));
    }
}
