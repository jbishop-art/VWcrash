using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class DetectHit : MonoBehaviour
{
    private bool whirl;
    private bool boxSideHit;
    private bool powerBoxSideHit;
    private GameObject boxTgt;
    private int powerUpPiece = 0;
    private bool powerMode;
    private bool powerPieceSwitch;

    private void Start()
    {

        whirl = false;
        boxSideHit = false;
        powerBoxSideHit = false;
        powerMode = false;
        powerPieceSwitch = false;

    }

    void OnCollisionEnter(Collision col)
    {
        //Box Top & Bottom hit.
        if (col.gameObject.tag == "BoxTopBottom")
        {
            //Destroy box vfx instantiate goes here.
            Destroy(col.gameObject, 0.5f);
        }

        //Box Sides hit.
        if (col.gameObject.tag == "BoxSides")
        {
            boxTgt = col.gameObject;
            boxSideHit = true;
        }
        else
        {
            boxSideHit = false;
        }

        //Power Box Top & Bottom hit.
        if (col.gameObject.tag == "PowerBoxTopBottom")
        {
            //Destroy box vfx instantiate goes here.
            Destroy(col.gameObject, 0.5f);
            powerPieceSwitch = true;
            StartCoroutine(powerPieceTimer());
            Debug.Log("PowerUP Pieces 2: " + powerUpPiece);
        }

        //Power Box Sides hit.
        if (col.gameObject.tag == "PowerBoxSides")
        {
            boxTgt = col.gameObject;
            powerBoxSideHit = true;
        }


        //Hit bad things.
        if (col.gameObject.tag == "Bad")
        {
            Destroy(gameObject, 1.0f);
            SceneManager.LoadScene("scene01");
        }

        //Detects if on platform and makes parent.
        if (col.gameObject.tag == "Platform")
        {
            transform.parent = col.gameObject.transform;
        }
        else
        {
            transform.parent = null;
        }
    }

    void Update()
    {
        //Detect whirl attack.
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(whirlTimer());
        }

        //If whirl attack and touching box side destory box.
        if (boxSideHit && whirl)
        {
            //Destroy box vfx instantiate goes here.
            Destroy(boxTgt);
        }

        //If whirl attach and touching Power Box sides destory Power box.
        if (powerBoxSideHit && whirl)
        {
            //Destroy power box vfx instantiate goes here.
            Destroy(boxTgt);
            powerPieceSwitch = true;
            StartCoroutine(powerPieceTimer());
            Debug.Log("PowerUP Pieces 1: " + powerUpPiece);
        }

        //If 3 power ups are collected, enter power mode.
        if (powerUpPiece == 3)
        {
            powerUpPiece = 0;
            //Instantiate power mode vfx.
            
        }
    }

    IEnumerator whirlTimer()
    {
        whirl = true;
        yield return new WaitForSeconds(0.0f);
        whirl = false;
    }

    IEnumerator powerModeTimer()
    {
        powerMode = true;
        Debug.Log("Enter power mode");
        yield return new WaitForSeconds(20);
        powerMode = false;
        Debug.Log("Exit power mode");
    }
    
    IEnumerator powerPieceTimer()
    {
        yield return new WaitForSeconds(0.25f);

       
        powerPieceSwitch = false;

        yield return new WaitForSeconds(1f);
        powerUpPiece = powerUpPiece + 1;
    }
    
}
