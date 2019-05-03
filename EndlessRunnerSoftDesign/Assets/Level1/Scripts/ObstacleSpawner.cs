using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] Objects;//objects that wll be spawned randomly
    public float SpawnOffsetX;
    public float SpawnPosY = -2.25f;

    public static float SpawnTime;

    public bool Stop = false;

    int randomObject;

    Transform player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //instantiate all of the game objets and unactivate them
        foreach (GameObject obj in Objects)
        {
            Instantiate(obj, new Vector3(SpawnPosY, SpawnOffsetX, 0), Quaternion.identity);
            obj.SetActive(false);
            obj.transform.parent = transform;
        }
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(SpawnTime);//wait for startTime to be over and start the while loop

        while (!Stop)
        {
            //hmm this might cause some objects to be called again while they're aready active on the map
            randomObject = Random.Range(0, Objects.Length);

            if(Objects[randomObject].activeInHierarchy == false)//if object is not active it's not in the view and can be reactivated and moved to new position
            {
                //random position between the player and spawn value
                Vector3 Pos = new Vector3(Random.Range(player.position.x, SpawnOffsetX) + 20, SpawnPosY, 0);

                Objects[randomObject].transform.position = Pos;//moves the object to position Pos
                Objects[randomObject].SetActive(true);//activate the object
                yield return new WaitForSeconds(SpawnTime);//wait the spawnTime until going back to beginning of this while
            }
        }
    }

}
