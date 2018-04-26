using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;

public class SpeechRecognizer : MonoBehaviour {

    private DictationRecognizer _recognizer;

    [SerializeField]
    private bool _debugUI = false;

    [SerializeField]
    private TestUI _test;

    private bool _rec = false;

	// Use this for initialization
	void Start () {

        //SetUP
        _recognizer = new DictationRecognizer();

        _recognizer.DictationResult += (text, confidence) =>
        {
            Debug.LogFormat("Dictation result: {0}", text);
            if (_debugUI)
                _test.RegisterText(text);
        };

        _recognizer.DictationError += (error, hresult) =>
        {
            Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
        };

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_rec)
                StopRecognition();
            else
                StartRecognition();
        }
	}

    public void StartRecognition()
    {
        _rec = true;
        _recognizer.Start();
        if (_debugUI)
            _test.RegisterStart();
    }

    public void StopRecognition()
    {
        _rec = false;
        _recognizer.Stop();
        if (_debugUI)
            _test.RegisterEnd();
    }
}
