using System.Collections;
using System.Collections.Generics;
using UnityEngine;
using UnityEngine.UI;

public class Detect {
    // remember to add a tag to BasketballScorekeeper() e.g., Score
    // so the two scripts know and talk to each other
    public BasketballScorekeeper Score;

    void Start() {
        Score = GameObject.FindGameObjectWithTag("Score").GetComponent<BasketballScorekeeper>();
    }

    OnTriggerEnter(Collider collider) {
        // What's a layer?
        // if (collider.GameObject.layer == 3), say we set "ball" to 3
        Score.addScore();
    }
}