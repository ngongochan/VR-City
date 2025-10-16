using System.Collections;
using System.Collections.Generics;
using UnityEngine;
using UnityEngine.UI;

// UI > Text (Legacy): basketballGameScore
// [Canvas Scaler] UI Scale Mode: Scale With Screen Size?
             //    Reference Resolution

// Create Empty: BasketballScorekeeper
// [Script] BasketballScorekeeper.cs

// Trigger: invisible collider, used to let us know that two objects have touched
// put a trigger inside the rim by Create Empty with a collider (e.g, Box Collider or Capsule Collider), isTrigger = true
// use Detect.cs (Script) as a component for this GameObject

public class BasketballScorekeeper : MonoBehaviour {
    public int basketballScore;
    public Text scoreText; // reference basketballGameScore (Text (Legacy))

    // run this function from other scripts -> set to public
    public addScore() {


        basketballScore += 1;
        scoreText.text = basketballScore.ToString();

    }
}