using UnityEngine;
using UnityEngine.Events;

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

    [SerializeField]
    private AnimateTransformToLocalVector _matchTransform;


    public bool desired = false;
   private void OnEnable()
    {
        OnGenerated(); 
    }

    public Collider[] ToCollide;

    /// <summary>
    /// Plays the collision event
    /// </summary>
    void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < ToCollide.Length; i++)
        {
            if (collision.collider == ToCollide[i])
            {
                this.transform.parent = collision.transform;
                OnFound(); 
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
            _onFound.Invoke();
        }
    }

    public void OnReturned()
    {
        _onReturned.Invoke(); 
    }

}
