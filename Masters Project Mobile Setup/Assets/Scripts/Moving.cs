using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Moving : MonoBehaviour
{
    public AudioSource ClickSound;
    float distance = 10;

    private void OnMouseDrag()
    {

        if (StaticPlayer.playerState == StaticPlayer.PlayerState.shovelState)
        {
            
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            ClickSound.pitch = Random.Range(0.8f, 1.2f);
            ClickSound.Play();

            transform.position = objectPos;


            if (transform.position.x > 5)
                transform.position = new Vector3(5, transform.position.y, transform.position.z);
            if (transform.position.x < -6)
                transform.position = new Vector3(-6, transform.position.y, transform.position.z);

            if (transform.position.y > 2)
                transform.position = new Vector3(transform.position.x, 2, transform.position.z);
            if (transform.position.y < -2)
                transform.position = new Vector3(transform.position.x, -2, transform.position.z);


        }
    }

}

