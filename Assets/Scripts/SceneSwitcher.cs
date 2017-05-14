using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour {
    public static SceneSwitcher instance;

    // Use this for initialization
    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            DestroyImmediate(gameObject);
        }
        
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GoToGame () {
        SceneManager.LoadScene("test");
    }
    public void GoToMenu () {
        SceneManager.LoadScene("Menu");
    }
    public void GoToCredits() {
        SceneManager.LoadScene("Credits");
    }
}
