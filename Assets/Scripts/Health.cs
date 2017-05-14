using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
	public int health, maxHealth;
    public GM myGM;
    public int lastWhoHitMe, whoAmI;
    public RawImage[] healthUI;
    
    Color red = new Color(255, 0, 0);
    Color black = new Color(0, 0, 0);
    // Use this for initialization
    void Start () {
       ResetHealth();
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0) {
            
            myGM.Respawn(gameObject, whoAmI, lastWhoHitMe);
            
        }
	}
	public void GotHit(int damage, int whoHitMe) {
      
            health -= damage;
            lastWhoHitMe = whoHitMe;
            if (health > 0) {
                healthUI[health].GetComponent<RawImage>().color = black;
            }
        
	}
    public void ResetHealth () {
        health = maxHealth;
        healthUI[0].GetComponent<RawImage>().color = red;
        healthUI[1].GetComponent<RawImage>().color = red;
        healthUI[2].GetComponent<RawImage>().color = red;
        
    }
}
