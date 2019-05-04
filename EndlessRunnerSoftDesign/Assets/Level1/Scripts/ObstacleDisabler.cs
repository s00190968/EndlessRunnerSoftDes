using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDisabler : MonoBehaviour
{
    public string[] Tags;//add the tags wanted in editor

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < Tags.Length; i++)
        {
            if (collision.transform.CompareTag(Tags[i]) && collision.gameObject.activeSelf == true)//if collision tag is found from list and the object is active
            {
                collision.gameObject.SetActive(false);
                i = Tags.Length;
            }
        }
    }
}
