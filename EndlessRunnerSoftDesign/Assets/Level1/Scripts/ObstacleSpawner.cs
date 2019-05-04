using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] Objects;//objects that wll be spawned randomly
    public float SpawnOffsetX;
    public float SpawnPosY = -2.25f;

    public float SpawnTime;

    public bool Stop = false;

    int randomObject;

    // Use this for initialization
    void Start()
    {
        //instantiate all of the game objets and unactivate them
        foreach (GameObject obj in Objects)
        {
            Instantiate(obj, new Vector3(SpawnOffsetX, SpawnPosY, 0), Quaternion.identity);
            obj.SetActive(false);
            obj.transform.parent = transform;
        }
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(SpawnTime);//wait for startTime to be over and start the while loop
        Vector3 Pos;

        while (!Stop)
        {
            //hmm this might cause some objects to be called again while they're aready active on the map
            randomObject = Random.Range(0, Objects.Length);

            Vector2 bottomRightCorner = new Vector2(1, 0);
            Vector2 edgyVectorRight = Camera.main.ViewportToWorldPoint(bottomRightCorner);//bottom right corner of the camera view

            if (!Objects[randomObject].activeSelf)//if object is not active it can be reactivated and moved to new position
            {
                //random position between the player and spawn value
                Pos = new Vector3((Random.Range(edgyVectorRight.x, SpawnOffsetX + edgyVectorRight.x)), SpawnPosY, 0);

                Objects[randomObject].transform.position = Pos;//moves the object to position Pos
                Objects[randomObject].SetActive(true);//activate the object
                yield return new WaitForSeconds(SpawnTime);//wait the spawnTime until going back to beginning of this while
            }
        }
    }

}
