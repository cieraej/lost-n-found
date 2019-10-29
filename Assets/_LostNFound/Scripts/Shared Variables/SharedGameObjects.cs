using UnityEngine;
[CreateAssetMenu(menuName = "Shared/GameObject Array")]
public class SharedGameObjects: ScriptableObject
{
    [SerializeField] private GameObject[] _objects;

    GameObject temp; 
    public void InstantiateRandom(Vector3 position)
    {
        temp = Instantiate(_objects[Random.Range(0, _objects.Length)]);
        temp.transform.position = position;
    }

}