using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour {

    [SerializeField]
    private Button startBtn;

	// Use this for initialization
	void Start () {
        startBtn.onClick.AddListener(LoadMainGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LoadMainGame()
    {
        SceneManager.LoadScene(1);
    }
}
