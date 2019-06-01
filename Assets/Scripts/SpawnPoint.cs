using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject playerPrefab;

    void Start()
    {
        //Spawn the player
        Instantiate(playerPrefab, transform.position, transform.rotation);
    }
}
