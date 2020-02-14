using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeManager : MonoBehaviour
{
    public Collider col;
    public GameObject cube;
    public Transform target;
    public List<Transform> list;
    public int spawnCount = 2000;
    public List<float> a;
    bool fly;
    float timer;

    public Image image;
    public Text text;

    int killCount;

    [ContextMenu("kill")]
    public void KillCount()
    {
        killCount++;
    }

    [ContextMenu("MurderChildren")]
    public void Kill()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }

    [ContextMenu("Spawn")]
    public void SpawnRandom()
    {
        list.Clear();
        a.Clear();
        for (int i = 0; i < spawnCount; i++)
        {
            GameObject newcube = Instantiate<GameObject>(cube, transform);
            newcube.transform.position = new Vector3(Random.Range(col.bounds.min.x, col.bounds.max.x), /*Random.Range(col.bounds.min.y, col.bounds.max.y)*/ 0.5f, Random.Range(col.bounds.min.z, col.bounds.max.z));
            list.Add(newcube.transform);
        }

        for (int i = 0; i < spawnCount; i++)
        {
            a.Add(Random.Range(-10f, 0f));
        }
    }

                float t = 0f;
    void Update()
    {
        if (timer >11)
        {
                t += Time.deltaTime;
                fly = false;
                image.color = Color.Lerp(new Color(0, 0, 0, 0), new Color(0, 0, 0, 1), t);
                text.color = Color.Lerp(new Color(1, 1, 1, 0), new Color(1, 1, 1, 1), t);
        }
        if (killCount >= 5)
        {
            fly = true;
            target.gameObject.SetActive(true);
            killCount = -1;
        }



        if (fly)
        {
            if (timer <= 11)
            {
                timer += Time.deltaTime;
            }
            
            for (int i = 0; i < spawnCount; i++)
            {
                a[i] += Time.deltaTime;
                list[i].position = Vector3.Slerp(list[i].position, target.position + Vector3.up * 2, a[i]);

                if (a[i] >= 1)
                {
                    list[i].GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
    }
}
