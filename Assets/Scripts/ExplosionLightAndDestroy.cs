using UnityEngine;
using System.Collections;

public class ExplosionLightAndDestroy : MonoBehaviour {

    public ParticleSystem p;
    public Light l;
    private float timer = 0f;
    private void Start()
    {

    }

    void Update ()
	{
        timer += Time.deltaTime;
        l.range = -16 * Mathf.Pow(timer, 2) + 24 * timer;

        if (!p.IsAlive())
        {
		    Destroy(transform.gameObject);
        }
	
	}
}
