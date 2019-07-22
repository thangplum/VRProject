using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject player;
    public float placeX;
    public float placeZ;
    // Start is called before the first frame update
    void Start()
    {
        placeX = Random.Range(542, 562);
        placeZ = Random.Range(260, 300);
        player.transform.position = new Vector3(placeX, 101, placeZ);
    }
}
