namespace UnityEvents
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Events;

    #if UNITY_EDITOR
    using UnityEditor;
    [CustomEditor(typeof(InvokeUnityEvent))]
    public class InvokeUnityEventEditor : Editor
    {
        
    /// <summary>
    /// Buttons to be pressed on the inspector GUI 
    /// </summary> ]
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            InvokeUnityEvent myScript = (InvokeUnityEvent)target;

         if (GUILayout.Button("Invoke Event"))
            {
            myScript.InvokeEvent();
        }
        }
    }
    #endif


    /// <summary>
    /// Simple script. Just Invokes a Unity Event. Can add delay between events if desired!
    /// </summary>
    public class InvokeUnityEvent : MonoBehaviour
    {
        /// <summary>
        /// Unity Event to invoke
        /// </summary>
        [SerializeField] private UnityEvent _toInvoke;
        /// <summary>
        /// Whether or not you want to invoke the event. 
        /// </summary>
        [SerializeField] private bool _addDelay = false;
        /// <summary>
        /// Delay between events (Optional).
        /// </summary>
        [SerializeField] private float _delay = 1f;
        /// <summary>
        /// Private, only changed if _addDelay is true!
        /// </summary>
        private bool _canInvoke = true;
        private WaitForSeconds _waitDelay;

        /// <summary>
        /// Grabs wait delay and makes it new. Small optimization for the garbage collector.
        /// </summary>
        private void Awake()
        {
            _waitDelay = new WaitForSeconds(_delay);
        }

        /// <summary>
        /// Just Invokes the event.
        /// </summary>
        public void InvokeEvent()
        {
            if (_canInvoke)
            {
                _toInvoke.Invoke();
                if (_addDelay)
                {
                    StartCoroutine(WaitDelay());
                }
            }

        }
        /// <summary>
        /// Well wait the delay before the event can invoke again. 
        /// </summary>
        /// <returns></returns>
        private IEnumerator WaitDelay()
        {
            _canInvoke = false;
            yield return _waitDelay;
            _canInvoke = true;
        }

    }
}