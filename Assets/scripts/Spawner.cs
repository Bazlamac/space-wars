using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject astroPrefab;
    public float spawnInterval = 2f;
    public float minX = -8f;
    public float maxX = 8f;
    public float spawnY = 6f;
    

    void Start()
    {
        InvokeRepeating("Spawn", 1f, spawnInterval);
    }

    void Spawn()
    {
        Vector2 pos = new Vector2(Random.Range(minX, maxX), spawnY);
        Instantiate(astroPrefab, pos, Quaternion.identity);
    }
}
