using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    public float speed;
    private Transform playerPos;
    private Player player;
    public GameObject Killeffect;
    public int EnemyHealth;

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
            player.currentHealth--;
            Destroy(gameObject);
        }
        if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            camRipple.RippleEffect();
            shake.CamShake();
            EnemyHealth--;
            if(EnemyHealth <= 0)
            {
                Score.scoreValue += 1;
                Instantiate(Killeffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            
        }
    }

}
