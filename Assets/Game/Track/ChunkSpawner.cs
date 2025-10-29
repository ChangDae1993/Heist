using UnityEngine;
using System.Collections.Generic;

public class ChunkSpawner : MonoBehaviour
{
    [SerializeField] private GameConfig config;
    public RoadChunk chunkPrefab;
    public Transform player;

    private readonly Queue<RoadChunk> spawned = new();
    private float lastSpawnZ;

    void Start()
    {
        float len = config ? config.chunkLength : 30f;
        lastSpawnZ = 0f;

        for (int i = 0; i < (config ? config.initialChunks : 6); i++)
            SpawnAt(new Vector3(0f, 0f, lastSpawnZ += len));
    }

    void Update()
    {
        if (spawned.Count == 0 || !player) return;

        float len = config ? config.chunkLength : 30f;

        // 플레이어보다 충분히 뒤로 간 첫 청크 제거
        RoadChunk first = spawned.Peek();
        if (player.position.z - first.transform.position.z > len * 1.5f)
        {
            var old = spawned.Dequeue();
            Destroy(old.gameObject);

            // 새 청크 하나 생성 (고정 길이)
            lastSpawnZ += len;
            SpawnAt(new Vector3(0f, 0f, lastSpawnZ));
        }
    }

    private void SpawnAt(Vector3 pos)
    {
        var chunk = Instantiate(chunkPrefab, pos, Quaternion.identity, transform);
        spawned.Enqueue(chunk);
    }
}
