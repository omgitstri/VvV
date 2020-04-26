using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.PlayerLoop;

// this toggles a component (usually an Image or Renderer) on and off for an interval to simulate a blinking effect
public class BlinkUIHealth : MonoBehaviour
{

    // Variables
    [SerializeField]
    private float initTime = 1f;
    [SerializeField]
    private float timer = 0f;
    public bool isBlinking = false;
    public GameObject sliderObject = null;

    private void Update()
    {
        BlinkingSlider(sliderObject, initTime);
    }

    public void BlinkingSlider(GameObject sliderObjectPara, float initTime)
    {
        sliderObject = sliderObjectPara;

        if (sliderObject != null)
        {
            if (isBlinking == true)
            {
                sliderObject.SetActive(true);
                timer -= Time.deltaTime;
            }

            if (timer <= 0)
            {
                sliderObject.SetActive(false);
                isBlinking = false;
                timer = initTime;
            }


        }

    }


}