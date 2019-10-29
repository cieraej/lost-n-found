namespace UnityEvents
{
    using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
    [CustomEditor(typeof(OnCollisionInvokeUnityEvent))]
    public class OnCollisionInvokeUnityEventEditor : InvokeUnityEventEditor
    {
        /// <summary>
        /// Inherits the Parent's GUI
        /// </summary> 
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }
#endif
    [RequireComponent(typeof(Collider))]
    public class OnCollisionInvokeUnityEvent : InvokeUnityEvent
    {
        /// <summary>
        /// Plays the collision event
        /// </summary>
        void OnCollisionEnter(Collision collision)
        {
            InvokeEvent();
        }
    }
}





