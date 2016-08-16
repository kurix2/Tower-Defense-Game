using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {

    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        GameObject.FindObjectOfType<MusicManager>();
        if (musicManager) {
            float volume = PlayerPrefsManager.GetMasterVolume();
            musicManager.SetVolume(volume);
        } else {
            Debug.LogWarning("No music manager found in Start Scene\nCannot set volume");
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
