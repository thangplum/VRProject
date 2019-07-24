using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject player;
    public Vector3 spawnValues;
    public float spawnValue;
    public float wait;
    public float startWait;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(SpawnerManager());
    }

    // Update is called once per frame
    void Update()
    {
        startWait = Random.Range(0f, 5f);
    }

    IEnumerator SpawnerManager()
    {
        Debug.Log("Hit");
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            Vector3 spawnPos = new Vector3(Random.Range(player.transform.position.x - 101, player.transform.position.x + 101), player.transform.position.y, Random.Range(player.transform.position.z - 101, player.transform.position.z + 101));
            Instantiate(enemies[0], spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(startWait);
        }
    }
}
