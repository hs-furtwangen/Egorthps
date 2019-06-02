using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatUi : MonoBehaviour
{
    public Color[] Colors =
    {
        Color.white,
        Color.red,
        Color.green,
        Color.blue,
        Color.yellow,
        Color.magenta
    };

    public float duration = 0.1f;

    public Color lastColor;
    public Color currentColor;
    public Color nextColor;

    public Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        img.color = currentColor;
    }

    IEnumerator SwitchColor()
    {
        float startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            currentColor = Color.Lerp(lastColor, nextColor, (Time.time - startTime) / duration);
            yield return null;
        }

        lastColor = currentColor;
    }

    public void NextColor()
    {
        StopAllCoroutines();

        nextColor = Colors[Mathf.RoundToInt(Random.Range(0, Colors.Length - 1))];

        while (lastColor == nextColor)
        {
            nextColor = Colors[Mathf.RoundToInt(Random.Range(0, Colors.Length - 1))];
        }

        lastColor = img.color;

        StartCoroutine(SwitchColor());
    }
}
