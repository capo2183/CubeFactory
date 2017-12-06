using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    public int lSize, wSize, hSize;

    private Vector3[] vertices;

    private void Awake()
    {
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        WaitForSeconds wait = new WaitForSeconds(0.05f);

        vertices = new Vector3[(lSize + 1) * (wSize + 1) * (hSize + 1)];
        for (int h = 0; h <= hSize; h++)
        {
            for (int w = 0; w <= wSize; w++)
            {
                for (int l = 0; l <= lSize; l++)
                {
                    int idx = h * (lSize + 1)  * (wSize + 1) + w * (lSize + 1) + l;
                    vertices[idx] = new Vector3(l, h, w);
                    yield return wait;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
            return;

        Gizmos.color = Color.black;
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }
}
