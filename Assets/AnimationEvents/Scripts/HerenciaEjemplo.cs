using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerenciaEjemplo : MonoBehaviour
{
    public GameObject myObject;

    protected virtual void Start()
    {
        Debug.Log(myObject.name + " says hello");
    }

}
