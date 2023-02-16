using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameObject.FindAnyObjectByType<GameManager>().isGameStart){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            string color = GameObject.FindAnyObjectByType<GameManager>().mainColor;
            string[] colors = new string[] {"Green", "Red", "Blue"};
            if(gameObject.tag == color){
                GameObject.FindAnyObjectByType<GameManager>().InscreaseScore();
            }else{
                foreach(string col in colors){
                if(col == gameObject.tag){
                    GameObject.FindAnyObjectByType<GameManager>().Over();
                }
            }
            }
            GameObject.FindAnyObjectByType<SpawnDiamon>().numDiamonds --;
            Destroy(gameObject);
        }
    }
}
