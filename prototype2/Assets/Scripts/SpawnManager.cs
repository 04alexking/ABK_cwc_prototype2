using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Array containing our animal Prefabs
    public GameObject[] animalPrefabs;

    // prefab for the hurt animal (for horizontal spawns)
    public GameObject hurtAnimal;

    // range in which the animals can spawn
    private float spawnRangeX = 10;
    // position on the Z-axis in which the animals spawn
    private float spawnPosZ = 20;
    // delay before spawning the first animal
    private float startDelay = 2;
    // delay between animal spawns
    private float spawnInterval = 1.5f;


    // interval for wave spawning
    public float waveSpawnInterval = 10.0f;
    // random time offset for wave spawning
    public float waveSpawnTimeVariance = 10.0f;
    // min and max amount of animals per wave
    public int minAnimalsPerWave = 3;
    public int maxAnimalsPerWave = 6;

    // range for animal spawns per wave
    public float waveSpawnRange = 2.0f;
    // spawn distance for wave spawns
    public float waveSpawnOffset = 17.0f;

    void Start() {
        // Make the spawn function run every spawnInterval seconds, with a starting delay of startDelay
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        // Also start the coroutine that spawns horizontal animals
        StartCoroutine(SpawnHorizontal());
    }

    // Update is called once per frame
    void Update()
    {
        // do nothing
    }

    void SpawnRandomAnimal() {
        // randomly select which animal to spawn
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        // randomize the spawning position
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0.0f, spawnPosZ);
        // spawn the animal prefab
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    // coroutine that spawns animals horizontally in waves:
    private IEnumerator SpawnHorizontal() {
        // wait for some time before starting
        yield return new WaitForSeconds(10);
        // forever...
        while (true) {
            SpawnWave();
            // wait for a random amount of time,  based on the interval
            yield return new WaitForSeconds(waveSpawnInterval + Random.Range(0.0f, waveSpawnTimeVariance));
        }
    }

    // coroutine to actually spawn the animals
    private void SpawnWave() {
        // randomly select the number of animals to spawn, within the range
        int numOfAnimals = Random.Range(minAnimalsPerWave, maxAnimalsPerWave);
        // repeat for every animal:
        for (int i = 0; i < numOfAnimals; i++) {
            // set direction (1 or -1) based on a random 50/50 chance
            float direction = (Random.Range(0.0f, 1.0f) < 0.5f)?-1:1;
            // set position to be the offset, multiplied by the direction, and add a random offset in the range
            float offset = (waveSpawnOffset * direction) + Random.Range(-waveSpawnRange, waveSpawnRange);
            // set spawn position to the offset, with a random variance
            Vector3 spawnPos = new Vector3(offset, 0.0f, Random.Range(-waveSpawnRange * 2.0f, waveSpawnRange * 2.0f));
            // set rotation to be left or right, based on the direction
            Quaternion rotation = Quaternion.Euler(0, 180 + (90 * direction), 0);

            // spawn the animal!
            Instantiate(hurtAnimal, spawnPos, rotation);
        }
    }
}
