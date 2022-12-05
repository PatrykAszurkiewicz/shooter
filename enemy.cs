using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    private Transform playerPos;
    private Player player;
    public GameObject Killeffect;

    private RipplePostProcessor camRipple;

    private Shake shake;
    
    

    private void Start()
    {
        camRipple = Camera.main.GetComponent<RipplePostProcessor>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            Instantiate(Killeffect, transform.position, Quaternion.identity);
            player.currentHealth--;
            Destroy(gameObject);
        }
        if (other.CompareTag("Projectile"))
        {
            Score.scoreValue += 1;
            camRipple.RippleEffect();
            shake.CamShake();
            Instantiate(Killeffect, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}
