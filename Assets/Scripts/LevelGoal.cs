using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGoal : MonoBehaviour
{
    public string nextSceneToLoad;
    public AudioSource levelFinishedAudioSource;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !levelFinishedAudioSource.isPlaying)
        {
            levelFinishedAudioSource.Play();
            GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>().volume = 0.3f;
            GameUIManager.Instance.ShowLevelCompleteText(true);
            StartCoroutine(LoadSceneAsyncAndWaitForAudio());
        }
    }

    IEnumerator LoadSceneAsyncAndWaitForAudio()
    {
        AsyncOperation asyncLoadOperation = SceneManager.LoadSceneAsync(nextSceneToLoad);
        asyncLoadOperation.allowSceneActivation = false;

        while (levelFinishedAudioSource.isPlaying)
        {
            Debug.Log("still playing");
            yield return null;
        }

        Debug.Log("Loading next level");
        asyncLoadOperation.allowSceneActivation = true;
    }
}
