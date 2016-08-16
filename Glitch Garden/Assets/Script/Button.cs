using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button : MonoBehaviour {
    public GameObject defenderPrefab;

    private Button[] buttonArray;

    private Text costText;
    public static GameObject selectedDefender; //singleton

	// Use this for initialization
	void Start () {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        costText = GetComponentInChildren<Text>();
        if (!costText) { Debug.LogWarning(name + " has no cost text."); }

        costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnMouseDown() {
        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
        print(selectedDefender);
    }
}
