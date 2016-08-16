using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{

    public float fadeOutTime;

    private Image fadePanel;
    private Color currentColor = Color.black;

    // Use this for initialization
    void Start() {
        fadePanel = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update() {
        if (Time.timeSinceLevelLoad > fadeOutTime){
            //Fade out
            float alphaChange = Time.deltaTime / fadeOutTime;
            currentColor.a += alphaChange;
            fadePanel.color = currentColor;
        }
    }
}
