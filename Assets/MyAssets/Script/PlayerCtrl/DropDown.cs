using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class DropDown : MonoBehaviour
{
    public string onWayPlatformLayerName;
    public string playerLayerName;

    private void Start()
    {
        onWayPlatformLayerName = "OneWayPlatform";
        playerLayerName = "Player";
    }
    private void Update()
    {
        if (Input.GetAxis("Vertical") < 0)
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(playerLayerName), LayerMask.NameToLayer(onWayPlatformLayerName), true); 
        }
        else
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(playerLayerName), LayerMask.NameToLayer(onWayPlatformLayerName), false);
        }
    }
}
