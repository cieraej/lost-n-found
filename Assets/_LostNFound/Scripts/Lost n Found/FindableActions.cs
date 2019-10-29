using UnityEngine;
using UnityEngine.Events;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(FindableActions))]
public class FindableStatesEventEditor : Editor
{

    /// <summary>
    /// Buttons to be pressed on the inspector GUI 
    /// </summary> ]
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        FindableActions myScript = (FindableActions)target;

        if (GUILayout.Button("On Generated"))
        {
            myScript.OnGenerated();
        }

        if (GUILayout.Button("On Desired"))
        {
            myScript.OnDesired();
        }

        if (GUILayout.Button("On Found"))
        {
            myScript.OnGenerated();
        }
    }
}
#endif

public class FindableActions : MonoBehaviour
{
    [SerializeField] private UnityEvent _onGenerated;

    [SerializeField] private UnityEvent _onDesired;

    [SerializeField] private UnityEvent _onFound;

    [SerializeField] private UnityEvent _onReturned;

    public float delayBeforeDestruct = 2; 

    [HideInInspector]
    public bool desired = false;

    private bool found = false; 

    private void OnEnable()
    {
        OnGenerated();
    }

    /// <summary>
    /// Plays the collision event
    /// </summary>
    void OnCollisionEnter(Collision collision)
    {
        if (desired)
        {
            Debug.Log("Collided with " + collision.transform.gameObject);

            if (collision.transform.CompareTag("hand"))
            {
                // collided with hand
                this.transform.parent = collision.transform;
                OnFound();
            }

            else if (collision.transform.CompareTag("base"))
            {
                // destroy the findable
                OnReturned();
            }
        }
    }

    public void OnGenerated()
    {
        _onGenerated.Invoke();
    }

    public void OnDesired()
    {
        desired = true;
        _onDesired.Invoke();
    }

    public void OnFound()
    {
        if (desired)
        {
            if (!found)
            {
                found = true;
                _onFound.Invoke();
            }
        }
    }

    public void OnReturned()
    {
        _onReturned.Invoke();
        this.transform.parent = null;
        StartCoroutine(WaitDelayThenDestroy());
    }

    IEnumerator WaitDelayThenDestroy()
    {
        yield return new WaitForSeconds(delayBeforeDestruct);
        Destroy(this.gameObject);
    }

}