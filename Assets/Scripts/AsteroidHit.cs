using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Asteroidhit : MonoBehaviour
{
    [SerializeField] private GameObject asteroidExploson;
    [SerializeField] private GameController gameController;
    [SerializeField] private GameObject popUpCanvas;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void AsteroidDestroyed()
    {
        Instantiate(asteroidExploson, transform.position, transform.rotation);

        float distanceFromPlayer = Vector3.Distance(transform.position, Vector3.zero);
        int bonusPoints = (int)distanceFromPlayer;
        int asteroidScore = 10 * bonusPoints;

        //Set the popup text
        popUpCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = asteroidScore.ToString();
        //instantiate popup canvas
        GameObject AsteroidPopUp = Instantiate(popUpCanvas,transform.position,Quaternion.identity);
        //adjust the scale of the popup
        AsteroidPopUp.transform.localScale = 

        gameController.UpdatePlayerScore(asteroidScore);

        Destroy(this.gameObject);
    }

}
