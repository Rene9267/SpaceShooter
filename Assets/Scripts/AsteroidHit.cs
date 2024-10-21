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


        if (GameController.currentGameStatus == GameState.Playing)
        {
            float distanceFromPlayer = Vector3.Distance(transform.position, Vector3.zero);
            int bonusPoints = (int)distanceFromPlayer;
            int asteroidScore = 10 * bonusPoints;

            //Set the popup text
            popUpCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = asteroidScore.ToString();
            //instantiate popup canvas
            GameObject asteroidPopUp = Instantiate(popUpCanvas, transform.position, Quaternion.identity);

            //adjust the scale of the popup
            asteroidPopUp.transform.localScale = new Vector3(transform.localScale.x * (distanceFromPlayer / 10), transform.localScale.y * (distanceFromPlayer / 10), transform.localScale.z * (distanceFromPlayer / 10));

            gameController.UpdatePlayerScore(asteroidScore);

        }

        Destroy(this.gameObject);

    }

}
