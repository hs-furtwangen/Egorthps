using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    private static GameUIManager _instance;
    public static GameUIManager Instance { get { return _instance; } }
    public Text timeText;
    public Text perspectiveChargesText;
    public Text levelCompleteText;

    void Awake() {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void SetTimeText(string newText) {
        timeText.text = newText;
    }

    public void SetPerspectiveChargesText(string newText) {
        perspectiveChargesText.text = newText;
    }

    public void ShowLevelCompleteText(bool value) {
        levelCompleteText.enabled = value;
    }
}
