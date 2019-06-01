using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkenCubes : MonoBehaviour
{
    private Color color;
    private Material mat;

    public bool LerpRed;
    public bool LerpGreen;
    public bool LerpBlue;

    public float SpeedFactor;

    private Vector2 rBounds;
    private Vector2 gBounds;
    private Vector2 bBounds;

    private float rSpeed;
    private float rLerp;
    private float gSpeed;
    private float gLerp;
    private float bSpeed;
    private float bLerp;

    // Start is called before the first frame update
    void Start()
    {
        mat = this.GetComponent<Renderer>().material;
        color = Color.black;

        if (LerpRed)
        {
            rLerp = Random.value;
            rBounds.x = Random.value;
            rBounds.y = Random.value;

            rSpeed = Random.Range(-1, 1);

            if (rBounds.y < rBounds.x)
            {
                var tmp = rBounds.y;
                rBounds.y = rBounds.x;
                rBounds.x = tmp;
            }
        }

        if (LerpGreen)
        {
            gLerp = Random.value;
            gBounds.x = Random.value;
            gBounds.y = Random.value;

            gSpeed = Random.Range(-1, 1);

            if (gBounds.y < gBounds.x)
            {
                var tmp = gBounds.y;
                gBounds.y = gBounds.x;
                gBounds.x = tmp;
            }
        }

        if (LerpBlue)
        {
            bLerp = Random.value;
            bBounds.x = Random.value;
            bBounds.y = Random.value;

            bSpeed = Random.Range(-1, 1);

            if (bBounds.y < bBounds.x)
            {
                var tmp = bBounds.y;
                bBounds.y = bBounds.x;
                bBounds.x = tmp;
            }
        }

        mat.SetColor("_EmissionColor", color);
    }

    // Update is called once per frame
    void Update()
    {
        if (LerpRed)
        {
            rLerp = rLerp + (rSpeed * SpeedFactor * Time.deltaTime);

            if (rLerp >= 1 || rLerp <= 0)
                rSpeed *= -1;

            rLerp = Mathf.Clamp01(rLerp);
        }
        if (LerpGreen)
        {
            gLerp = gLerp + (gSpeed * SpeedFactor * Time.deltaTime);

            if (gLerp >= 1 || gLerp <= 0)
                gSpeed *= -1;

            gLerp = Mathf.Clamp01(gLerp);
        }
        if (LerpBlue)
        {
            bLerp = bLerp + (bSpeed * SpeedFactor * Time.deltaTime);

            if (bLerp >= 1 || bLerp <= 0)
                bSpeed *= -1;

            bLerp = Mathf.Clamp01(bLerp);
        }

        color.r = Mathf.Lerp(rBounds.x, rBounds.y, rLerp);
        color.g = Mathf.Lerp(gBounds.x, gBounds.y, gLerp);
        color.b = Mathf.Lerp(bBounds.x, bBounds.y, bLerp);

        mat.SetColor("_EmissionColor", color);
    }
}
