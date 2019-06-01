using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject playerPrefab;

    void Start()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
}
