using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public GameObject[] prefabAssets;
    public float[] chance;
    public int worldWidth = 20;
    public int worldHeight = 20;
    public float noiseScale = 0.1f;
    public float threshold = 0.5f;

    private float[,] noiseMap;

    void Start()
    {
        GenerateNoiseMap();
        GenerateWorld();
    }

    void GenerateNoiseMap()
    {
        noiseMap = new float[worldWidth, worldHeight];

        for (int y = 0; y < worldHeight; y++)
        {
            for (int x = 0; x < worldWidth; x++)
            {
                float sampleX = x * noiseScale;
                float sampleY = y * noiseScale;
                float sum = 0;


                for (int i = 0; i < 9; i++)
                {
                    sum += Mathf.PerlinNoise(sampleX-noiseScale+(i%3)*noiseScale, sampleY-noiseScale+(i/3)*noiseScale);
                } 
                float noiseValue = sum/9;

                noiseMap[x, y] = noiseValue;

                Debug.Log(noiseValue);              
            }
        }
    }

    void GenerateWorld()
    {
        for (int y = 0; y < worldHeight; y++)
        {
            for (int x = 0; x < worldWidth; x++)
            {
                float noiseValue = noiseMap[x, y];

                if (noiseValue > threshold)
                {
                    int prefabIndex = Random.Range(0, prefabAssets.Length);
                    Vector3 position = new Vector3(x, y, 0);
                    Instantiate(prefabAssets[prefabIndex], position, Quaternion.identity);
                }
            }
        }
    }
}
