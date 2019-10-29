using System.Collections;
using UnityEngine;

public class PlaceInEnviroment : MonoBehaviour
{
    public float min, max;
    public float spaceBetweenPoints = .01f;
    public bool placeOnEnable = true;

   void OnEnable()
    {
        if(placeOnEnable)
        {
            Place();
        }
    }
    [ContextMenu("Place")]
    public void Place()
    {
        StartCoroutine(Placing()); 
    }

    IEnumerator Placing()
    {
        Vector3 tempPosition = RandomPositionWithinRange(min, max, Camera.main.transform);

        while (!IsRandomPoint(tempPosition, spaceBetweenPoints))
        {
            tempPosition = RandomPositionWithinRange(min, max, Camera.main.transform);
            yield return new WaitForEndOfFrame(); 
        }

        transform.position = tempPosition;
    }
    Vector3 RandomPositionWithinRange(float minDistance, float maxDistance, Transform origin)
    {
        if (minDistance > maxDistance)
        {
            Debug.LogError("min Distance is greater than max Distance");
        }

        if (minDistance < 0 || maxDistance < 0)
        {
            Debug.LogError("Distances cannot be negative");
        }
        // need to make sure min and max distance are less than eachother
        Vector3 randomPosition = new Vector3(RandomSign() * RandomFromOriginPoint(origin.position.x, minDistance, maxDistance),
                                             RandomSign() * RandomFromOriginPoint(origin.position.y, minDistance, maxDistance),
                                             RandomSign() * RandomFromOriginPoint(origin.position.z, minDistance, maxDistance));

        return randomPosition;
    }

    public float RandomFromOriginPoint(float origin, float min, float max)
    {
        return Random.Range(origin + min, origin + max);
    }

    public int RandomSign()
    {
        return Random.Range(0, 2) * 2 - 1;
    }

    public bool IsRandomPoint(Vector3 positionPoint, float spaceBetweenPoints)
    {
        Collider[] hitColliders = Physics.OverlapSphere(positionPoint, spaceBetweenPoints);
        
        if (hitColliders.Length == 0)
        {
            return true;
        }

        return false;
    }
}
