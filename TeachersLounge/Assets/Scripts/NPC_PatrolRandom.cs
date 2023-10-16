using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class NPC_PatrolRandomPoints : MonoBehaviour {

       public float speed = 10f;
       private float waitTime;
       public float startWaitTime = 2f;

       public Transform[] moveSpots;
       private int randomSpot;

       //public Animator anim;
       private Vector3 theScale;
       private Renderer rend;
       private GameHandler gameHandler;
       public bool LeftRightCreature = true;
       public bool isAttacking = false;
       public int damage = 10;

       void Start(){
              waitTime = startWaitTime;
              randomSpot = Random.Range(0, moveSpots.Length);
              //anim = GetComponentInChildren<Animator>();
              theScale = transform.localScale;
              rend = GetComponentInChildren<Renderer>();
              if (GameObject.FindWithTag ("GameHandler") != null) {
                  gameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
              }
       }

       void Update(){
              //move enemy to the destination (appears to stay put if there is no destination)
              transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

              if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f){
                     if (waitTime <= 0){
                            //assign new destination
                            randomSpot = Random.Range(0, moveSpots.Length);
                            waitTime = startWaitTime;
                            //anim.SetBool("Walk", true);
                     } else {
                            //no new destination (stop moving) until time runs out
                            waitTime -= Time.deltaTime;
                            //anim.SetBool("Walk", false);
                     }
              }

              //flip display of enemies that move left-to-right, based on movement direction vector
              if (LeftRightCreature== true){
                     //capture direction
                     Vector3 posA = transform.position;
                     Vector3 posB = moveSpots[randomSpot].position;
                    //Destination - Origin
                     Vector3 dir = (posB - posA).normalized;
                     Debug.Log("Enemy direction: " + dir);

                     float moveDirection = dir.x;
                     if (moveDirection < 0){
                            transform.localScale = theScale * 1;
                     }
                     else if (moveDirection > 0){
                            transform.localScale = theScale;
                     }
                     else { }
              }
       }

       //Injure the Player on contact:
       public void OnCollisionEnter2D(Collision2D collision){
              if (collision.gameObject.tag == "Player") {
                     isAttacking = true;
                     //anim.SetBool("Attack", true);
                     gameHandler.playerGetHit(damage);
                     //rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
                     //StartCoroutine(HitEnemy());
              }
       }

       public void OnCollisionExit2D(Collision2D collision){
              if (collision.gameObject.tag == "Player") {
                     isAttacking = false;
                     //anim.SetBool("Attack", false);
              }
       }

       IEnumerator HitEnemy(){
              yield return new WaitForSeconds(0.5f);
              rend.material.color = Color.white;
       }

}