using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    [SerializeField] LayerMask layer = ~0;

    int triggeredCount = 2;

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (layer == (layer | 1 << other.gameObject.layer))
        {
            triggeredCount -= 1;
            if (triggeredCount <= 0)
            {
                Invoke(nameof(TriggerEndGame), 3f);
            }
        }
    }

    private void TriggerEndGame()
    {
        Toolbox.GetInstance.GetScene().LoadScene("Victory");
    }

    private void OnTriggerExit(Collider other)
    {
        if (layer == (layer | 1 << other.gameObject.layer))
            triggeredCount++;
    }
}
