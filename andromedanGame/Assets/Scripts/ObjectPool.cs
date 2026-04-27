using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;

    [SerializeField]
    public int poolAmount = 30;
    private List<GameObject> pool;

    private void Awake()
    {
        pool = new List<GameObject>();

        for (int i = 0; i < poolAmount; i++)
        {
            GameObject newObject = Instantiate(prefab);
            newObject.SetActive(false);
            pool.Add(newObject);
        }

    }

    public GameObject GetObject()
    {
        foreach (GameObject newObj in pool) {

            if (!newObj.activeInHierarchy)
            {
                newObj.SetActive(true);
                return newObj;
            }
        }

        GameObject secondObj = Instantiate(prefab);
        secondObj.SetActive(true);
        pool.Add(secondObj);
        return secondObj;
    }
}
