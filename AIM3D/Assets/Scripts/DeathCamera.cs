﻿using UnityEngine;
using System.Collections;

public class DeathCamera : MonoBehaviour {

    private float camSpeed = 50f;
    private Camera deathCamera;
    private GameObject player;
    private GameObject spawnPoint;
    private RespawnScript respawn;
    private float timer;

    void OnEnable()
    {
        spawnPoint = GameObject.FindWithTag(Tags.respawnTag);
        respawn = spawnPoint.GetComponent<RespawnScript>();
        player = GameObject.FindWithTag(Tags.playerTag);
        deathCamera = GetComponent<Camera>();
    }

    void Update()
    {
        if(player != null)
        {
            transform.position = player.transform.position;
            transform.rotation = player.transform.rotation;
        }
    }

    public void MoveCamBack()
    {
        deathCamera.enabled = true;
        StartCoroutine("MoveBack");
    }

    IEnumerator MoveBack()
    {
        //move back camera for 150 frames (approximately 2-3 seconds)
        for (int i = 0; i < 150; i++ )
        {
            transform.position -= transform.forward * Time.deltaTime * camSpeed;
            yield return new WaitForSeconds(0f);
        }

        //respawn
        respawn.Respawn();
        yield return new WaitForSeconds(0f);
    }
}