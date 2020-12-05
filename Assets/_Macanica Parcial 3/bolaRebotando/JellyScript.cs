using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyScript : MonoBehaviour
{
    [SerializeField]
    float bounceSpeed;
    [SerializeField]
    float fallForce;
    [SerializeField]
    float stiffness;

    private MeshFilter meshF;
    private Mesh mesh;

    JellyVertex[] jellyVertices;
    Vector3[] currentMeshVertices;

    // Start is called before the first frame update
    void Start()
    {
        meshF = GetComponent<MeshFilter>();
        mesh = meshF.mesh;
        GetVertices();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateVerteces();
    }

    private void GetVertices()
    {
        jellyVertices = new JellyVertex[mesh.vertices.Length];
        currentMeshVertices = new Vector3[mesh.vertices.Length];

        for(int i = 0; i < mesh.vertices.Length; i++)
        {
            jellyVertices[i] = new JellyVertex(i, mesh.vertices[i]);
            currentMeshVertices[i] = mesh.vertices[i];
        }
    }

    private void UpdateVerteces()
    {
        for (int i = 0; i < jellyVertices.Length; i++)
        {
            jellyVertices[i].UpdateVel(bounceSpeed);
            jellyVertices[i].Settle(stiffness);

            jellyVertices[i].nowVetexPos += jellyVertices[i].nowVelocity * Time.deltaTime;
            print("Antes: " + currentMeshVertices[i]);
            currentMeshVertices[i] = jellyVertices[i].nowVetexPos;
            print("Despues: "+currentMeshVertices[i]);
        }

        mesh.vertices = currentMeshVertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] collisionPts = collision.contacts;
        for(int i = 0; i < collisionPts.Length; i++)
        {
            Vector3 inputPts = collisionPts[i].point + (collisionPts[i].point * 0.1f);
            print(inputPts + " index: "+ i);
            ApplyPressere2Point(inputPts, fallForce);
            
        }
    }

    public void ApplyPressere2Point(Vector3 inputPt,float force)
    {
        for(int i = 0; i < jellyVertices.Length; i++)
        {
            jellyVertices[i].ApplyPress(transform, inputPt, force);
        }
    }

    public class JellyVertex
    {
        public int vertexIndex;
        public Vector3 initVetexPos;
        public Vector3 nowVetexPos;

        public Vector3 nowVelocity;

        public JellyVertex(int _vetexI, Vector3 _initVertexP)
        {
            vertexIndex = _vetexI;
            initVetexPos = _initVertexP;
            nowVetexPos = _initVertexP;
            nowVelocity = Vector3.zero;
        }

        public Vector3 GetNowDisplacement()
        {
            return nowVetexPos - initVetexPos;
        }

        public void UpdateVel(float _bounce)
        {
            nowVelocity = nowVelocity - GetNowDisplacement() * _bounce * Time.deltaTime;
        }

        public void Settle(float _stiffness)
        {
            nowVelocity *= 1.0f - _stiffness * Time.deltaTime;
        }

        public void ApplyPress(Transform _transform, Vector3 _position, float _pressure)
        {
            Vector3 distanceVerPos = nowVetexPos - _transform.InverseTransformPoint(_position);
            float adaptPress = _pressure / (1.0f + distanceVerPos.sqrMagnitude);
            float vel = adaptPress * Time.deltaTime;
            nowVelocity += distanceVerPos.normalized * vel;
        }
    }
}
