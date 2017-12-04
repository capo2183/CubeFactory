using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Grid : MonoBehaviour {
    public int xSize, ySize;

    private Vector3[] vertices;

    private void Awake()
    {
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        WaitForSeconds wait = new WaitForSeconds(0.05f);

        vertices = new Vector3[(xSize + 1) * (ySize + 1)];
        for(int j=0; j<ySize; j++)
        {
            for(int i=0; i< xSize; i++)
            {
                int idx = j * xSize + i;
                vertices[idx] = new Vector3(i, j);
                yield return wait;
            }
        }
    }

    private void OnDrawGizmos()
    { 
        if(vertices == null)
            return;

        Gizmos.color = Color.black;
        for(int i=0; i<vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }
}
