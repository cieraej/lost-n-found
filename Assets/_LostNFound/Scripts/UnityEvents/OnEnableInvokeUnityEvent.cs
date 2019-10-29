namespace UnityEvents
{
    using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
    [CustomEditor(typeof(OnEnableInvokeUnityEvent))]
    public class OnEnableInvokeUnityEventEditor : InvokeUnityEventEditor
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

    public class OnEnableInvokeUnityEvent : InvokeUnityEvent
    {
        private void OnEnable()
        {
            InvokeEvent(); 
        }

    }
}
