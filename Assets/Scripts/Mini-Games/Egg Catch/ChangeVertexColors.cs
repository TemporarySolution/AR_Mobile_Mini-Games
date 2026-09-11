using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ChangeVertexColors : MonoBehaviour
{
    public Color newColor = Color.red; // Color to apply to the chicken

    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter != null)
        {
            Mesh mesh = meshFilter.mesh;

            if (mesh.colors.Length > 0)
            {
                Color[] colors = mesh.colors;

                for (int i = 0; i < colors.Length; i++)
                {
                    UnityEngine.Debug.Log(colors[i]);
                    colors[i] = newColor;
                }

                mesh.colors = colors;
                UnityEngine.Debug.Log("Vertex colors updated!");
            }
            else
            {
                UnityEngine.Debug.LogWarning("No vertex colors found in the mesh.");
            }
        }
        else
        {
            UnityEngine.Debug.LogWarning("MeshFilter not found!");
        }
    }
}

