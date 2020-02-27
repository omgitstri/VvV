using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private WeightTableScriptableObject weightTable = null;
    private void Start()
    {
        StartCoroutine(Autospawn());
    }

    IEnumerator Autospawn()
    {
        while (true)
        {
            var go = Instantiate(weightTable.PickFromWeight());
            go.transform.position = transform.position;
            yield return new WaitForSeconds(1);
        }
    }
}
