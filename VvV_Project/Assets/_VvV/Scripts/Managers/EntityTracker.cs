using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityTracker : MonoBehaviour
{
    private static EntityTracker _instance = null;
    public static EntityTracker Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject(nameof(EntityTracker)).AddComponent<EntityTracker>();
            }
            return _instance;
        }
    }

    private Dictionary<string, GameObject> entityDictionary = new Dictionary<string, GameObject>();

    public void AddEntity(string key, GameObject value)
    {
        if (!entityDictionary.ContainsKey(key))
        {
            entityDictionary.Add(key, value);
        }
    }

    public void RemoveEntity(string key)
    {
        if (entityDictionary.ContainsKey(key))
        {
            entityDictionary.Remove(key);
        }
    }

    public GameObject FindEntity(string key)
    {
        GameObject go = null;

        if (entityDictionary.ContainsKey(key))
        {
            go = entityDictionary[key];
        }

        return go;
    }
}
