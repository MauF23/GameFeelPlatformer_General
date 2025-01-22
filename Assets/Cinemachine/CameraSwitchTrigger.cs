using Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchTrigger : MonoBehaviour
{
    public int cameraToSwitch; 
    public Collider2D cameraTrigger;

    protected virtual void Start()
    {
        //Asegurarse que el collider del script sea un trigger
        cameraTrigger.isTrigger = true;
    }

    /// <summary>
    /// Si el jugador entra al trigger se cambia la cámara por la especificada en la variable cameraToSwitch
    /// </summary>
    /// <param name="collision"></param>
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            CameraManager.instance.CameraSwitch(cameraToSwitch);
        }
    }

}
