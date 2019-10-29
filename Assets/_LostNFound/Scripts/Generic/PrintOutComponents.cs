using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor (typeof(PrintOutComponents))]
public class PrintOutComponentsEditor : Editor
{
	/// <summary>
	/// Buttons to be pressed on the inspector GUI 
	/// </summary> 

	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector ();

		PrintOutComponents myScript = (PrintOutComponents)target;

		if (GUILayout.Button ("Print Components")) {
			myScript.PrintComponents ();
		}
	}
}
#endif

public class PrintOutComponents : MonoBehaviour {

    Component[] ComponentArray;

	public void PrintComponents () {

        ComponentArray =  GetComponents<Component>();

        for(var i = 0; i < ComponentArray.Length; i++)
        {
            print("Component at [" + i + "] is :  " + ComponentArray[i]);
        }
	}
	
}
