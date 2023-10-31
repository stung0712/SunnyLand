using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offset;
    [SerializeField] private float offsetSmoothing;
    private Vector3 playerPosition;
         
    
    private void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        if(player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x+offset, playerPosition.y, playerPosition.z);
        } else
        {
            playerPosition = new Vector3(playerPosition.x-offset,playerPosition.y, playerPosition.z);
        }

        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing*Time.deltaTime);
    }
}
