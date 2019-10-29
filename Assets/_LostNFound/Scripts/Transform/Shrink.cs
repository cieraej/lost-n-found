using System.Collections;
using UnityEngine;


public class Shrink : MonoBehaviour
{
    
	public void ShrinkToZeroScaleTimed (float duration)
	{
		if (gameObject.activeInHierarchy) {
			StopAllCoroutines ();
			StartCoroutine (ChangingScale (Vector3.zero, duration));
		}
	}

	IEnumerator ChangingScale (Vector3 ChangeScaleToThis, float TimeOfChange)
	{
		float elapsedTime = 0;
		while (elapsedTime < (TimeOfChange)) {
			elapsedTime += Time.deltaTime;
			transform.localScale = Vector3.Lerp (transform.localScale, ChangeScaleToThis, elapsedTime / TimeOfChange);
			yield return new WaitForEndOfFrame ();
		}

		yield return null;
	}

}
