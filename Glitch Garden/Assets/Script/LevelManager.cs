using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;

    void Start() {
        if (autoLoadNextLevelAfter <= 0){
            Debug.Log("Level auto load disabled!\n Use a positive number in seconds");
        }
        else{
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
	}

	public void QuitRequest(){
        Debug.Log("Move Back Start: " + name);
        Application.LoadLevel(name);
    }

    public void LoadNextLevel() {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

}
