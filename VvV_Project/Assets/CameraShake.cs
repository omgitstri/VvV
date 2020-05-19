using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
    private Vector3 originalPos;

    private void Start() {
        originalPos = transform.localPosition;
    }

    public IEnumerator Shake(float duration, float magnitude) {
        float elapsed = 0f;
        while (elapsed < duration) {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        ResetPos();
    }

    private void ResetPos() {
        transform.localPosition = originalPos;
    }
}
