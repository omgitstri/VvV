using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpGeneric : MonoBehaviour
{
    public enum EVariables { Float, Int, vector2, vector3, color };

    public EVariables lerpType = EVariables.vector2;
    [SerializeField] float lerpDuration = 3f;

    [HideInInspector] public float lerpFloatA;
    [HideInInspector] public float lerpFloatB;

    [HideInInspector] public int lerpIntA;
    [HideInInspector] public int lerpIntB;

    [HideInInspector] public Vector2 lerpVector2A;
    [HideInInspector] public Vector2 lerpVector2B;

    [HideInInspector] public Vector3 lerpVector3A;
    [HideInInspector] public Vector3 lerpVector3B;

    [HideInInspector] public Color lerpColorA;
    [HideInInspector] public Color lerpColorB;

    public float a = 0f;
    private MeshRenderer meshrender = null;

    void Start()
    {
        meshrender = GetComponent<MeshRenderer>();
    }

    [ContextMenu(nameof(StartLerp))]
    public void StartLerp(float _lerpDuration)
    {
        lerpDuration = _lerpDuration;
        StartCoroutine(nameof(LerpVector2));
    }


    private IEnumerator LerpVector2()
    {
        while (a < lerpDuration)
        {
            a = Mathf.Clamp(a, 0, lerpDuration);
            a += Time.deltaTime;
            meshrender.material.SetTextureOffset("_BaseMap", Vector2.Lerp(lerpVector2A, lerpVector2B, a / lerpDuration));
            yield return new WaitForEndOfFrame();
        }
    }

}
