using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] Object;//objects that wll be spawned randomly
    public int HowManyObjects = 5;

    public float SpawnOffsetX = 5;
    public float SpawnPosY = -2.25f;

    public float SpawnTime;

    public bool Stop = false;

    int randomObject;

    List<GameObject> objects;

    // Use this for initialization
    void Start()
    {
        objects = new List<GameObject>();

        //instantiate all of the game objets and unactivate them
        foreach(GameObject obj in Object)
        {
            
            for (int i = 0; i < HowManyObjects; i++)
            {
                GameObject temp = Instantiate(obj, new Vector3(SpawnOffsetX, SpawnPosY, 0), Quaternion.identity);

                temp.transform.SetParent(transform);
                objects.Add(temp);
                temp.SetActive(false);
            }
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
            randomObject = Random.Range(0, objects.Count);

            Vector2 bottomRightCorner = new Vector3(1, 0, 0); //bottom righ corner of camera
            Vector3 edgyVectorRight = Camera.main.ViewportToWorldPoint(bottomRightCorner);//bottom right corner of the camera view

            if (!objects[randomObject].activeSelf)//if object is not active it can be reactivated and moved to new position
            {
                edgyVectorRight = Camera.main.ViewportToWorldPoint(bottomRightCorner);//bottom right corner of the camera view

                //random position between the right side of the viewport and spawn value
                Pos = new Vector3((Random.Range(edgyVectorRight.x, SpawnOffsetX +edgyVectorRight.x)) +10, SpawnPosY, 0);

                Debug.Log("EDGY: " + edgyVectorRight);
                Debug.Log("POS:" + Pos);

                objects[randomObject].transform.position = Pos;//moves the object to position Pos
                objects[randomObject].SetActive(true);//activate the object
                yield return new WaitForSeconds(SpawnTime);//wait the spawnTime until going back to beginning of this while
            }
        }
    }

}
