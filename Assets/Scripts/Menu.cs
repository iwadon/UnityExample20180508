using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    AudioClip[] clips;
    [SerializeField]
    AudioSource src;

    int _clipIdx;
    string _labelString;

    // Use this for initialization
    void Start()
    {
        _clipIdx = 0;
        UpdateLabelString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_clipIdx > 0)
            {
                --_clipIdx;
            }
            else
            {
                _clipIdx = clips.Length - 1;
            }
            UpdateLabelString();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_clipIdx < clips.Length - 1)
            {
                ++_clipIdx;
            }
            else
            {
                _clipIdx = 0;
            }
            UpdateLabelString();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            src.clip = clips[_clipIdx];
            src.Play();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            src.Stop();
        }
    }

    void OnGUI()
    {
        GUILayout.Label(_labelString);
        GUILayout.Label("[←][→] ... AudioClipを選択");
        GUILayout.Label("[Z] ... 再生開始");
        GUILayout.Label("[X] ... 再生停止");
    }

    void UpdateLabelString()
    {
        _labelString = (_clipIdx + 1) + "/" + clips.Length + " " + clips[_clipIdx].name;
    }
}
