using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour{
    public Vector3 Offset;
    public Player player;

    public void Update(){

        transform.position = player.transform.position + Offset;
    }

}
