using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelayButtonHACK : MonoBehaviour
{
    Button button;

    private void Start()
    {
        button = GameObject.Find("Button").GetComponent<Button>();
    }

    public void StartDelay()
    {
        StartCoroutine(nameof(IStartDelay));
    }

    private IEnumerator IStartDelay()
    {
        float elapsedTime = 0f;
        float _waitTime = 3f;
        while (elapsedTime < _waitTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        button.interactable = true;
    }
}