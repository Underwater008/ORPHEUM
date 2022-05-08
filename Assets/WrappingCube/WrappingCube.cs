using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrappingCube : MonoBehaviour
{
    [SerializeField]
    private Material cubeMaterial;
    [SerializeField]
    private string cubeName;
    private GameObject cube;
    private MeshRenderer meshRenderer;
    private Bounds bounds;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        CreateWrappingCube();
    }

    private void CreateWrappingCube()
    {
        //Save object's previous rotation and make zero the object rotation
        Quaternion objRotation = transform.rotation;
        transform.eulerAngles = Vector3.zero;
        //Calculate the bounds of the object and make a cube
        bounds = meshRenderer.bounds;
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = cubeName;
        cube.GetComponent<MeshRenderer>().material = cubeMaterial;
        //Position and Scale the cube
        cube.transform.position = bounds.center;
        cube.transform.localScale = bounds.size;
        //Parent the cube to the object
        cube.transform.parent = gameObject.transform;

        //Restore object's previous rotation
        transform.rotation = objRotation;
    }

}
