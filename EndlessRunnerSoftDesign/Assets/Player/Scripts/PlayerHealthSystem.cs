using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : HealthSystem
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // all enemies deal damage
            //get script from enemy and take damage value from there
            //decrease health by the damage value in enenmy
            //collision.GetComponent<ObstacleDyingScript>()
            DecreaseHealth();
        }
        if (collision.CompareTag("Poison"))//when player hit's poison obstacle
        {

        }
        if (collision.CompareTag("Harmful Obstacle"))//when player hits an obstacle that is supposed to deal damage.
        {
            DecreaseHealth();
        }
    }
}