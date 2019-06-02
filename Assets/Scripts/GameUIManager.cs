using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;
    public Text timeText;
    public Text perspectiveChargesText;
    public Text levelCompleteText;

    void Start() {
        Instance = this;
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
