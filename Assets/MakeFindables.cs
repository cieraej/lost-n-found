using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MakeFindables : MonoBehaviour
{
    public int FindablesToMake = 10;

    public GameObject[] Findables;

    public GameObject DesiredFindable;

    public List<GameObject> ToFind;

    public bool isGenerated = false;

    public GameObject prevDesired;

    public int findCount;
    private int prevFindCount = 0;
    bool started = false;
    [SerializeField] private UnityEvent _onEndGame;

    public void StartGame()
    {
        if (!started)
        {
            started = true;
            DesiredFindable.GetComponent<FindableActions>().OnDesired();
            StartCoroutine(Finding());
        }
    }

    IEnumerator Finding()
    {
        while (findCount != 0)
        {
            if (DesiredFindable == null)
            {
                findCount--;
                DesiredFindable = ToFind[findCount];
                DesiredFindable.GetComponent<FindableActions>().OnDesired();
            
            }
            yield return new WaitForEndOfFrame();
        }
        // everything has been found
        while (DesiredFindable != null)
        {
            yield return new WaitForEndOfFrame();
        }
            Debug.Log("Everything has Been found");
        _onEndGame.Invoke(); 
        ToFind.Clear();
    }


    [ContextMenu("Generate Findables")]
    public void GenerateFindables()
    {
        if (findCount == 0)
        {
            for (int i = 0; i < FindablesToMake; i++)
            {
                var generated = Instantiate(Findables[(int)Random.Range(0, Findables.Length)]);
                generated.SetActive(true);
                generated.transform.parent = this.transform;
                ToFind.Add(generated);
                DesiredFindable = generated;
                findCount++;

            }
            prevFindCount = findCount;
            prevDesired = DesiredFindable;
            findCount--;
        }
        else
        {
            Debug.LogError("Have to find everything first before generating more!");
        }


    }
}
