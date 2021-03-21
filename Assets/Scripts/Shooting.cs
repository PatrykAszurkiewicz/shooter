using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject shot;
    public GameObject SoundEffect;
    private Transform playerPos;

    private void Start()
    {
        playerPos = GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !PauseMenu.GameIsPaused)
        {
            Instantiate(shot, playerPos.position, Quaternion.identity);
            Instantiate(SoundEffect, playerPos.position, Quaternion.identity);
        }
    }
}
