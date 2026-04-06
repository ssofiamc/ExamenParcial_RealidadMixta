using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBehaviour : MonoBehaviour
{
    GrabManager grabManager;
    [SerializeField] GameObject holder; //Llama el empty
    
    public GameObject heldObject; // Objeto agarrado

    void Start()
    {
        grabManager = GameObject.Find("GrabManager").GetComponent<GrabManager>();
    }

    void FixedUpdate()
    {
        if (heldObject != null)
        {
            heldObject.transform.Rotate(Vector3.up * (10 * Time.deltaTime));
        }
    }

    public void OnPointerClickXR() //Esta es la función que se usa para interactuar con casi todo
    {
        if (grabManager.heldItem != null)
        {
            if (heldObject != null)
            {
                heldObject.GetComponent<GrabObject>().Respawn();
            }
            heldObject = grabManager.heldItem;
            grabManager.heldItem.GetComponent<GrabObject>().Place(holder.transform.position);
        }
        else
        {
            if (heldObject != null)
            {
                heldObject.GetComponent<GrabObject>().Grab();
                heldObject = null;
            }
        }
    }
}
