using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Noise;
using System.Linq;

//[ExecuteInEditMode]
public class RandomGeneration : MonoBehaviour
{
    public GameObject[] prefabAssets;
    public float[] chance;

    public int NoiseHeight;
    public int NoiseWidth;
    public int NoiseOctaves;
    public Texture2D noiseTexture;
    public float frequency = 0.5f;
    public float amplitude = 1f;
    public float scale = 1f;
    public float bias;

     void Start()
    {
        // Generate random game objects within the Perlin noise
        RandomGenerateObjects();
        NoisePreview();
    }

    public float[,] GenerateNoiseMap(int width, int height, int octaves)
    {
        float _frequency = frequency;
        float _amplitude = amplitude;

        var data = new float[width , height];
        var min = float.MaxValue;
        var max = float.MinValue;

        Noise2d.Reseed();

        for (var octave = 0; octave < octaves; octave++)
        {
            for (int i=0;i<width;i++)
                {
                    for (int j=0;j<height;j++)
                    {
                        var noise = Noise2d.Noise(i*_frequency*1f/width, j*_frequency*1f/height);
                        noise = data[j, i] += noise * _amplitude;

                        min = Mathf.Min(min, noise);
                        max = Mathf.Max(max, noise);
                    }
                }
            _frequency *= 2;
            _amplitude /= 2;
        }

         for (int i=0;i<width;i++)
                {
                    for (int j=0;j<height;j++)
                    {
                        data[j,i] = (data[j,i] - min) / (max - min);
                    }
                }

        return data;
    }

    public void NoisePreview()
    {
        if (noiseTexture != null && (noiseTexture.width != NoiseWidth || noiseTexture.height != NoiseHeight))
        {
            noiseTexture = null;
        }

        if (noiseTexture == null)
        {
            noiseTexture = new Texture2D(NoiseWidth,NoiseHeight);
        }

        float[,] Noise = GenerateNoiseMap(NoiseWidth, NoiseHeight, NoiseOctaves);
        Color[] Colors = new Color[NoiseWidth * NoiseHeight];
        for (int i = 0; i < NoiseWidth; i++)
        {
            for (int j = 0; j < NoiseHeight; j++)
            {
                Colors[j*NoiseHeight+i] = new Color(Noise[i,j],Noise[i,j],Noise[i,j],1);
            }
        }
        noiseTexture.SetPixels(Colors);
        noiseTexture.Apply();
    }

    // Generate random GameObjects within the Perlin Noise
public void RandomGenerateObjects()
{
    // Generate the noise map
    float[,] noiseMap = GenerateNoiseMap(NoiseWidth, NoiseHeight, NoiseOctaves);

    // Spawn GameObjects within the noise
    for (int i = 0; i < NoiseWidth; i++)
    {
        for (int j = 0; j < NoiseHeight; j++)
        {
            // Generate a random value and compare it to the noise value at this point
            float randomValue = UnityEngine.Random.Range(0f, 1f);
            if (noiseMap[i,j] - bias > randomValue)
            {
                // Choose a random prefab from the list and instantiate it
                int randomIndex = UnityEngine.Random.Range(0, prefabAssets.Length);
                GameObject spawnedObject = Instantiate(prefabAssets[randomIndex], new Vector3(i,j,0), Quaternion.identity);

                // Determine whether to destroy the spawned object based on the chance array
                float randomChance = UnityEngine.Random.Range(0f, 1f);
                if (randomChance > chance[randomIndex])
                {
                    Destroy(spawnedObject);
                }
            }
        }
    }
}


}

