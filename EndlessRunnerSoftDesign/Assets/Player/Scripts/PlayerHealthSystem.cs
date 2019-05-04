using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : HealthSystem
{
    //animations
    PlayerAnimationManager aniMan;

    int timer = 0;

    private void Start()
    {
        aniMan = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimationManager>();
        Health = 1f;
        IsAlive = true;
    }

    private void Update()
    {
        if (aniMan.WasHit && timer > 100)
        {
            aniMan.WasHit = false;
            timer = 0;
        }
        timer++;

        if (!IsAlive)
        {
            SceneMaster.OpenMainMenu();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("player colliding with " + collision.tag + ", animan was hit: " + aniMan.WasHit);

        if (collision.CompareTag("Enemy"))
        {
            // all enemies deal damage
            //get script from enemy and take damage value from there
            //decrease health by the damage value in enenmy
            //collision.GetComponent<EnemyController>()
            DecreaseHealth();
            aniMan.WasHit = true;
        }
        if (collision.CompareTag("Poison"))//when player hit's poison obstacle
        {
            aniMan.WasHit = true;
        }
        if (collision.CompareTag("Harmful Obstacle"))//when player hits an obstacle that is supposed to deal damage.
        {
            DecreaseHealth();
            aniMan.WasHit = true;
        }
        if (collision.CompareTag("Potion"))//gain health
        {
            IncreaseHealth();
        }
    }
}