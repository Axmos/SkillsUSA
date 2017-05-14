using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {
    public GameObject[] spawnPoints;
    public float score1, score2, winNumber, killReward;
    public Text score1Text, score2Text, winText;
    public bool gameOver;
    public Button menuButton, playAgainButton;
    KingHill myKingHill;
    
	// Use this for initialization
	void Start () {
        myKingHill = GameObject.FindGameObjectWithTag("KingHill").GetComponent<KingHill>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (gameOver == false) {
            score1Text.text = "Player 1: " + score1.ToString("F0");
            score2Text.text = "Player 2: " + score2.ToString("F0");
            if (score1 >= winNumber) {
                winText.text = "Player 1 Wins!";
                winText.color = score1Text.color;
                gameOver = true;
            } else if (score2 >= winNumber) {
                winText.text = "Player 2 Wins!";
                winText.color = score2Text.color;
                gameOver = true;
            }
        } else {
            menuButton.gameObject.SetActive(true);
            playAgainButton.gameObject.SetActive(true);
        }
    } 
    

    public void Respawn(GameObject catapult, int whoIsYou, int whoKillYou) {
        if(whoKillYou == 1) {
            score1 += killReward;
        } else if (whoKillYou == 2) {
            score2 += killReward;
        }
        catapult.SetActive(false);
        myKingHill.playersInCircle.Remove(catapult);
        catapult.transform.position = spawnPoints[whoIsYou].GetComponent<Transform>().position;
        catapult.GetComponent<Health>().ResetHealth();
        catapult.SetActive(true);
    }
    public void AddScore(float addThis, int toThisPlayer) {
        if(toThisPlayer == 1) {
            score1 += addThis;
        } else if(toThisPlayer == 2) {
            score2 += addThis;
        }
    }
}
