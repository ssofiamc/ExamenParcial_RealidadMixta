using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    GrabManager grabManager;
    BoxCollider boxCollider;
    Vector3 spawnerPosition;
    Quaternion spawnerRotation;


    [SerializeField] public string type = "Objeto";
    [SerializeField] public GameObject spawner;

    void Start()
    {
        spawnerPosition = spawner.transform.position;
        spawnerRotation = spawner.transform.rotation;
        boxCollider = GetComponent<BoxCollider>();
        grabManager = GameObject.Find("GrabManager").GetComponent<GrabManager>();
    }

    public void Grab()
    {
        if (grabManager.heldItem != null) //Si el agarre es diferente a null, hace que se pueda soltar el objeto
        {
            grabManager.heldItem.GetComponent<GrabObject>().Drop();
        }
        grabManager.heldItem = transform.gameObject;
        boxCollider.enabled = false;
    }

    public void Drop()
    {
        transform.position = spawnerPosition; //Copia las posiciones del spawn
        transform.rotation = spawnerRotation; //Copia las posiciones del spawn
        grabManager.heldItem = null;
        boxCollider.enabled = true;
    }

    public void Delete()
    {
        transform.position = spawnerPosition;
        transform.rotation = spawnerRotation;
        grabManager.heldItem = null;
        boxCollider.enabled = true;
        transform.gameObject.SetActive(false);
    }

    public void Respawn()
    {
        transform.position = spawnerPosition;
        transform.rotation = spawnerRotation;
        boxCollider.enabled = true;
        transform.gameObject.SetActive(true);
    }

    public void Place(Vector3 position)
    {
        transform.position = position;
        grabManager.heldItem = null;
        boxCollider.enabled = true;
    }

    public void OnPointerClickXR()
    {
        Grab();
    }
}
