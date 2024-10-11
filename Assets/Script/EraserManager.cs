using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class EraserManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;

    public bool PlayerTurn = true;

    public bool TurnDone = false;

    private bool DoneTurnForEnemy = false;

    public UnityEvent Win;
    public UnityEvent Lose;

   
    public void EndTurn()
    {
        TurnDone = true;
    }

    private void Update()
    {
        if (PlayerTurn)
        {
            DoneTurnForEnemy = false;
            Player.GetComponent<PlayerEraserController>().enabled = true;
            if (TurnDone)
            {
                TurnDone = false;

                if ((0 - Mathf.Abs(Player.transform.rotation.eulerAngles.z) < 0.5 && 0 - Mathf.Abs(Player.transform.rotation.eulerAngles.z) > -0.5) ||
                    (180 - Mathf.Abs(Player.transform.rotation.eulerAngles.z) < 0.5 && 180 - Mathf.Abs(Player.transform.rotation.eulerAngles.z) > -0.5) ||
                    (360 - Mathf.Abs(Player.transform.rotation.eulerAngles.z) < 0.5 && 360 - Mathf.Abs(Player.transform.rotation.eulerAngles.z) > -0.5))
                {
                    //Debug.Log(Math.Round(Player.transform.position.y, 1) + " " + Math.Round(Enemy.transform.position.y, 1));

                    if (Math.Round(Player.transform.position.y,1) > Math.Round(Enemy.transform.position.y, 1) && Math.Round(Player.transform.position.y, 1) - Math.Round(Enemy.transform.position.y, 1) > 0.1f)
                    {
                        //Player Win
                        Debug.Log("------------PLAYER-----------");
                        Debug.Log("Player Pos: " + Math.Round(Player.transform.position.y, 1));
                        Debug.Log("Enemy Pos: " + Math.Round(Enemy.transform.position.y, 1));
                        Debug.Log("Player Rot: " + Mathf.Abs(Player.transform.rotation.eulerAngles.z));
                        Debug.Log(0 - Mathf.Abs(Player.transform.rotation.eulerAngles.z));
                        Debug.Log(180 - Mathf.Abs(Player.transform.rotation.eulerAngles.z));
                        Debug.Log(360 - Mathf.Abs(Player.transform.rotation.eulerAngles.z));
                        Debug.Log("Player Win");
                        Win.Invoke();
                    }
                }
                PlayerTurn = !PlayerTurn;
            }
        }
        else
        {
            Player.GetComponent<PlayerEraserController>().enabled = false;
            if (!DoneTurnForEnemy)
            {
                Enemy.GetComponent<EraserForce>().FlickEraer(Enemy.transform.position + (Enemy.transform.position - Player.transform.position).normalized * 2.0f + new Vector3(0,-0.5f,0));
                DoneTurnForEnemy = true;
            }
            if (TurnDone)
            {

                if ((0 - Mathf.Abs(Enemy.transform.rotation.eulerAngles.z) < 0.5 && 0 - Mathf.Abs(Enemy.transform.rotation.eulerAngles.z) > -0.5) || 
                    (180 - Mathf.Abs(Enemy.transform.rotation.eulerAngles.z) < 0.5 && 180 - Mathf.Abs(Enemy.transform.rotation.eulerAngles.z) > -0.5) || 
                    (360 - Mathf.Abs(Enemy.transform.rotation.eulerAngles.z) < 0.5 && 360 - Mathf.Abs(Enemy.transform.rotation.eulerAngles.z) > -0.5))
                {
                    //Debug.Log(Math.Round(Player.transform.position.y, 1) + " " + Math.Round(Enemy.transform.position.y, 1));
                    if (Math.Round(Enemy.transform.position.y, 1) > Math.Round(Player.transform.position.y, 1) && Math.Round(Enemy.transform.position.y, 1) - Math.Round(Player.transform.position.y, 1) > 0.1f)
                    {
                        Debug.Log("------------ENEMY-----------");
                        Debug.Log("Player Pos: " + Math.Round(Player.transform.position.y, 1));
                        Debug.Log("Enemy Pos: " + Math.Round(Enemy.transform.position.y, 1));
                        Debug.Log("Enemy Rot: " + Mathf.Abs(Enemy.transform.rotation.eulerAngles.z));
                        Debug.Log(0 - Mathf.Abs(Enemy.transform.rotation.eulerAngles.z));
                        Debug.Log(180 - Mathf.Abs(Enemy.transform.rotation.eulerAngles.z));
                        Debug.Log(360 - Mathf.Abs(Enemy.transform.rotation.eulerAngles.z));
                        Debug.Log("Enemy Win");
                        Lose.Invoke();
                    }
                    
                }
                PlayerTurn = !PlayerTurn;
                TurnDone = false;
                Player.GetComponent<PlayerEraserController>().oneClick = false;
            }
        }
    }

 
}
