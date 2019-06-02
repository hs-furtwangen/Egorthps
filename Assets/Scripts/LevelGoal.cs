using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGoal : MonoBehaviour
{
    public AudioSource levelFinishedAudioSource;

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Player") && !levelFinishedAudioSource.isPlaying) {
            levelFinishedAudioSource.Play();
            GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>().volume = 0.3f;
            GameUIManager.Instance.ShowLevelCompleteText(true);
        }
    }
}
