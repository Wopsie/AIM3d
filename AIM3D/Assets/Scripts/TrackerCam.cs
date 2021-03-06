﻿using UnityEngine;
using System.Collections;

public class TrackerCam : MonoBehaviour 
{
    private GameObject player;

    void Start()
    {
        //run refind player upon receiving event from player
        Plane.OnRenable += RefindPlayer;
        RefindPlayer();
    }

	void FixedUpdate () 
    {
        if(player != null)
        {
            //track player with camera
            Vector3 moveCamTo = player.transform.position - player.transform.forward * 10f + Vector3.up * 7f;
            float bias = 0.80f;
            Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1f - bias);
            Camera.main.transform.LookAt(player.transform.position + player.transform.forward * 60f);
        }
	}

    void OnDisable()
    {
        Plane.OnRenable -= RefindPlayer;
    }

    public void RefindPlayer()
    {
        //get player instance
        player = GameObject.FindWithTag(Tags.playerTag);
        Debug.Log(gameObject.tag + "found player");
    }
}
