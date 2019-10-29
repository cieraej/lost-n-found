using UnityEngine;
[CreateAssetMenu(menuName = "Shared/Vector3")]
public class SharedVector3: ScriptableObject
{
#if UNITY_EDITOR
    public string DeveloperDescription = "";
#endif
    public Vector3 variable;

}