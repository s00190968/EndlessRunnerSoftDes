using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayerAlongXaxis : MonoBehaviour
{
    public float Distance = 10;//how distance from this to player
    PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x - Distance, 0, 0);
    }
}
