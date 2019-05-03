using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDisabler : MonoBehaviour
{
    public string[] tags;//add the tags wanted in editor

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with object tagged \" " + collision.tag + " \".");
        for (int i = 0; i < tags.Length; i++)
        {
            if (collision.transform.CompareTag(tags[i]))
            {
                collision.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Tag \" " + collision.tag + "\" is not on the list for tags to be disabled");
            }
        }
    }
}
