namespace UnityEvents
{
    using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
    [CustomEditor(typeof(OnDisableInvokeUnityEvent))]
    public class OnDisableInvokeUnityEventEditor : InvokeUnityEventEditor
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
    public class OnDisableInvokeUnityEvent : InvokeUnityEvent
    {
        /// <summary>
        /// Invokes Unity Event on Disable.
        /// </summary>
        private void OnDisable()
        {
            InvokeEvent();
        }
    }
}
