using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Moving3 : MonoBehaviour
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


            if (transform.position.x > -4)
                transform.position = new Vector3(-4, transform.position.y, transform.position.z);
            if (transform.position.x < -15)
                transform.position = new Vector3(-15, transform.position.y, transform.position.z);

            if (transform.position.y > -10)
                transform.position = new Vector3(transform.position.x, -10, transform.position.z);
            if (transform.position.y < -14)
                transform.position = new Vector3(transform.position.x, -14, transform.position.z);


        }
    }

}
