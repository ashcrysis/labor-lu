using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Throw : MonoBehaviour
{
    private GameObject player;
    [SerializeField]private GameObject snowball;
    [SerializeField]private float force;
    [SerializeField]private Transform gunPoint;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        var playerFacingDir = player.GetComponent<Movement>().isFacingRight();
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            if (playerFacingDir != 0){
            var th_snowball = Instantiate(snowball,gunPoint.position,Quaternion.identity);
            th_snowball.GetComponent<Snowball>().force = force * playerFacingDir;
            }
        }
    }
}
