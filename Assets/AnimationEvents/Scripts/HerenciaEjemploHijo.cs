using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerenciaEjemploHijo : HerenciaEjemplo
{
    public string updateMessage;

    protected override void Start()
    {
        base.Start();
        Debug.Log(myObject.name + " says goodbye");
    }

    private void Update()
    {
        Debug.Log(updateMessage);
    }


}
