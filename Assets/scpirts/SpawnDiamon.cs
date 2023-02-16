using UnityEngine;

public class SpawnDiamon : MonoBehaviour
{
    public GameObject[] diamondPrefabs;
    public float spawnRadius = 100f;
    public int maxDiamonds = 100;
    public Transform player;

    public int numDiamonds = 0;

    void Update()
{
    if (numDiamonds < maxDiamonds && GameObject.FindAnyObjectByType<GameManager>().isGameStart)
    {
        Vector3 spawnPosition = Random.insideUnitSphere * spawnRadius;
        spawnPosition.y = 0f;

        RaycastHit hit;
        if (Physics.Raycast(player.position + spawnPosition + Vector3.up * 100f, Vector3.down, out hit, 200f))
        {
            Vector3 targetPosition = hit.point;

            int prefabIndex = Random.Range(0, diamondPrefabs.Length);
            GameObject diamond = Instantiate(diamondPrefabs[prefabIndex], targetPosition, Quaternion.identity);

            numDiamonds++;
        }
    }
}
}
