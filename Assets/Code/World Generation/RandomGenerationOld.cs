using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Noise;
using System.Linq;

[ExecuteInEditMode]
public class RandomGenerationOld : MonoBehaviour
{
    /*
    public GameObject[] prefabAssets;
    public float[] chance;
    
    public int NoiseHeight;
    public int NoiseWidth;
    public int NoiseOctaves;
    public Texture2D noiseTexture;
    public float frequency = 0.5f;
    public float amplitude = 1f;
    public float scale = 1f;

    // public void RegenerateSimplex()
    // {
    //     float[] colors = SimplexNoise.Calc1D(NoiseWidth,scale);
    //     if(TextureRef2==null)
    //     {
    //         TextureRef2 = new Texture2D(NoiseWidth,NoiseHeight);
    //     }
    //     //TextureRef2.SetPixels(colors);
    //     //TextureRef2.Apply();
    // }
    public float[,] GenerateNoiseMap(int width, int height, int octaves)
    {
        /// reset variables
        float _frequency = frequency;
        float _amplitude = amplitude;



        var data = new float[width , height];

        /// track min and max noise value. Used to normalize the result to the 0 to 1.0 range.
        var min = float.MaxValue;
        var max = float.MinValue;

        /// rebuild the permutation table to get a different noise pattern. 
        /// Leave this out if you want to play with changing the number of octaves while 
        /// maintaining the same overall pattern.
        Noise2d.Reseed();


        for (var octave = 0; octave < octaves; octave++)
        {
            /// parallel loop - easy and fast.
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
    */
}