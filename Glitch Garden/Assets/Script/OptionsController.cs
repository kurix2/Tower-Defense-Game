using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;
    public Slider diffSlider;
    public LevelManager levelManager;

    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        diffSlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
        musicManager.SetVolume(volumeSlider.value);
        
    }

    public void SaveAndExit() {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(diffSlider.value);
        levelManager.LoadLevel("01a_Start");
    }

    public void SetDefaults() {
        volumeSlider.value = 0.8f;
        diffSlider.value = 2f;
    }
}
