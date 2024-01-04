using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject block;

    public int blocksToSpawn;

    public List<GameObject> spawnedBlocks;


    private float timer;
    public float timerLength;
    // Start is called before the first frame update
    void Start()
    {
        timer = timerLength;
        for (int i = 0; i < blocksToSpawn; i++)
        {
            GameObject spawnedBlock = Instantiate(block, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f)), transform.rotation);
            spawnedBlock.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            spawnedBlocks.Add(spawnedBlock);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) || timer <= 0)
        {
            foreach (GameObject block in spawnedBlocks)
            {
                Destroy(block);
            }
            spawnedBlocks.Clear();

            for (int i = 0; i < blocksToSpawn; i++)
            {
                GameObject spawnedBlock = Instantiate(block, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f)), transform.rotation);
                spawnedBlock.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                spawnedBlocks.Add(spawnedBlock);
            }
            timer = timerLength;
        }
    }
}
