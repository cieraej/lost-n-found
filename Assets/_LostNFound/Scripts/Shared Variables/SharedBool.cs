using UnityEngine;
[CreateAssetMenu(menuName = "Shared/Boolean")]
public class SharedBool: ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string developerDescription = "";
#endif
    public bool variable;

}