using UnityEngine;
using System.Collections;
 
[RequireComponent (typeof(Camera))]
public class MatrixBlender : MonoBehaviour
{
    Camera cam;

    AudioSource audioSource;

    public void Awake() {
        cam = GetComponent<Camera>();
        audioSource = GameController.Instance.GetComponent<AudioSource>();
    }

    public static Matrix4x4 MatrixLerp(Matrix4x4 from, Matrix4x4 to, float time)
    {
        Matrix4x4 ret = new Matrix4x4();
        for (int i = 0; i < 16; i++)
            ret[i] = Mathf.Lerp(from[i], to[i], time);
        return ret;
    }
 
    private IEnumerator LerpFromTo(Matrix4x4 src, Matrix4x4 dest, float duration, float timescale)
    {
        float startTime = Time.time;

        float timeFrom = Time.timeScale;

        while (Time.time - startTime < duration)
        {
            cam.projectionMatrix = MatrixLerp(src, dest, (Time.time - startTime) / duration);
            Time.timeScale = Mathf.Lerp(timeFrom, timescale, (Time.time - startTime) / duration);
            audioSource.pitch = Time.timeScale;
            yield return 1;
        }
        cam.projectionMatrix = dest;


    }
 
    public Coroutine BlendToMatrix(Matrix4x4 targetMatrix, float duration, float timescale)
    {
        StopAllCoroutines();
        return StartCoroutine(LerpFromTo(cam.projectionMatrix, targetMatrix, duration, timescale));
    }
}