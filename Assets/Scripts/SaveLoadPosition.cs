using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadPosition : MonoBehaviour
{
    public Transform player;
    public Transform guardian;
    Vector3 playerPosition;
    Vector3 guardianPosition;



	public void SaveGame()
    {
        playerPosition = player.position;
        guardianPosition = guardian.position;
        PlayerPrefs.SetFloat("playerPositionX", playerPosition.x);
        PlayerPrefs.SetFloat("playerPositionY", playerPosition.y);
        PlayerPrefs.SetFloat("playerPositionZ", playerPosition.z);
        PlayerPrefs.SetFloat("guardianPositionX", guardianPosition.x);
        PlayerPrefs.SetFloat("guardianPositionY", guardianPosition.y);
        PlayerPrefs.SetFloat("guardianPositionZ", guardianPosition.z);
        PlayerPrefs.Save();

    }


    public void LoadGame()
    {

        player.position = new Vector3(PlayerPrefs.GetFloat("playerPositionX"), PlayerPrefs.GetFloat("playerPositionY"), PlayerPrefs.GetFloat("playerPositionZ"));
        guardian.position = new Vector3(PlayerPrefs.GetFloat("guardianPositionX"), PlayerPrefs.GetFloat("guardianPositionY"), PlayerPrefs.GetFloat("guardianPositionZ"));

    }

}
