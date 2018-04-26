using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : MonoBehaviour {

    [SerializeField]
    private Text _recognizedText;

    [SerializeField]
    private Image _recImg;

    public void RegisterStart()
    {
        _recImg.color = Color.red;
    }

    public void RegisterEnd()
    {
        _recImg.color = Color.grey;
    }

    public void RegisterText(string txt)
    {
        _recognizedText.text += txt + " ";
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
