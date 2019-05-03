using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : HealthSystem
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Enemy":// all enemies deal damage
                //get script from enemy and take damage value from there

                //decrease health by the damage value in enenmy
                DecreaseHealth();
                break;
            case "Poison"://when player hit's poison obstacle
                break;
            case "Harmful Obstacle"://when player hits an obstacle that is supposed to deal damage.
                DecreaseHealth();
                break;
        }
    }
}
