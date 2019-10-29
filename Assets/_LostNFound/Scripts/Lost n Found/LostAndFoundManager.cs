using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(LostAndFoundManager))]
public class LostAndFoundManagerEditor : Editor
{

    /// <summary>
    /// Buttons to be pressed on the inspector GUI 
    /// </summary> ]
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LostAndFoundManager myScript = (LostAndFoundManager)target;

        if (GUILayout.Button("On Start Game"))
        {
            myScript.StartGame(); 
        }

        if (GUILayout.Button("On End Game"))
        {
            myScript.EndGame();
        }
    }
}
#endif
public class LostAndFoundManager : MonoBehaviour
{
    [SerializeField] private UnityEvent _onStartGame;

    [SerializeField] private UnityEvent _onEndGame;


    public void StartGame()
    {
        _onStartGame.Invoke(); 
    }

    public void EndGame()
    {
        _onEndGame.Invoke();
    }
}
