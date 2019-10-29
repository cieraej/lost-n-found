using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public void StartGame()
    {
        if (!started)
        {
            started = true;
            DesiredFindable.GetComponent<FindableActions>().OnDesired();
            StartCoroutine(WaitAndPrint());
        }
    }

    IEnumerator WaitAndPrint()
    {
        while (findCount != 0)
        {
            if (DesiredFindable == null && findCount != 0)
            {


                DesiredFindable = ToFind[findCount];
                DesiredFindable.GetComponent<FindableActions>().OnDesired();
                findCount--;


            }
            yield return new WaitForSeconds(1);
        }

        Debug.Log("FOUND EVERYTHING!!");
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
