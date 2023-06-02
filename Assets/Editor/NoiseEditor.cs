using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RandomGeneration))]
[CanEditMultipleObjects]
public class NoiseEditor : Editor 
{
    SerializedProperty tex1;
    //SerializedProperty tex2;
    void OnEnable()
    {
        tex1 = serializedObject.FindProperty("noiseTexture");
        //tex2 = serializedObject.FindProperty("TextureRef2");

    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        RandomGeneration t = (RandomGeneration)target;
        if(GUILayout.Button("Generate Perlin"))
        {
            ((RandomGeneration)t).NoisePreview();
        }
        //texture = (Texture2D)GUILayout.ObjectField("Add a Texture:",texture,typeof(Texture2D));
        GUILayout.Label(new GUIContent("Preview:"));
        if (tex1!=null)
        {
            
            GUILayout.Label((Texture2D)tex1.objectReferenceValue);
        }
        // GUILayout.Space(10);
        // if(GUILayout.Button("Generate Simplex"))
        // {
        //     ((RandomGeneration)t).RegenerateSimplex();
        // }
        // GUILayout.Label(new GUIContent("Preview:"));
        // if (tex1!=null)
        // {
        //     GUILayout.Label((Texture2D)tex2.objectReferenceValue);
        // }

    }
}