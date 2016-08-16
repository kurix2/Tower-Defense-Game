using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float levelSeconds = 100;
    private Slider slider;
    private bool isEndOfLevel = false;
    private LevelManager levelManager;
    private AudioSource audioSource;
    private GameObject winLabel;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        winLabel = GameObject.Find("You Win");
        FindYouWin();
        winLabel.SetActive(false);
    }

    private void FindYouWin() {
        if (!winLabel)
        {
            Debug.LogWarning("Please create You Win object");
        }
    }

    // Update is called once per frame
    void Update () {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;

        bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds);
        if ( timeIsUp && !isEndOfLevel) {
            audioSource.Play();
            winLabel.SetActive(true);
            Invoke("LoadNextLevel", audioSource.clip.length);
            isEndOfLevel = true;
        }
 
	}

    void LoadNextLevel() {
        levelManager.LoadNextLevel();
    }
}
