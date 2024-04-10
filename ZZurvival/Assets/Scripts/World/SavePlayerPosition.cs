using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerPosition : MonoBehaviour
{
    public Transform player;
    Vector3 playerPosition;
    Quaternion playerRotation;

    void Start()
    {
        if (PlayerPrefs.HasKey("playerStarted"))
        {
            player.gameObject.SetActive(false);
            player.position = new Vector3(PlayerPrefs.GetFloat("playerPositionX"), PlayerPrefs.GetFloat("playerPositionY"), PlayerPrefs.GetFloat("playerPositionZ"));
            player.rotation = new Quaternion(PlayerPrefs.GetFloat("playerRotationX"), PlayerPrefs.GetFloat("playerRotationY"), PlayerPrefs.GetFloat("playerRotationZ"), PlayerPrefs.GetFloat("playerRotationW"));
            player.gameObject.SetActive(true);
        }
        if (!PlayerPrefs.HasKey("playerStarted"))
        {
            PlayerPrefs.SetInt("playerStarted", 1);
            PlayerPrefs.Save();
        }
    }

    void Update()
    {
        playerPosition = player.position;
        playerRotation = player.rotation;
        PlayerPrefs.SetFloat("playerPositionX", playerPosition.x);
        PlayerPrefs.SetFloat("playerPositionY", playerPosition.y);
        PlayerPrefs.SetFloat("playerPositionZ", playerPosition.z);
        PlayerPrefs.SetFloat("playerRotationX", playerRotation.x);
        PlayerPrefs.SetFloat("playerRotationY", playerRotation.y);
        PlayerPrefs.SetFloat("playerRotationZ", playerRotation.z);
        PlayerPrefs.SetFloat("playerRotationW", playerRotation.w);
        PlayerPrefs.Save();
        //Debug.Log("X:" + PlayerPrefs.GetFloat("playerPositionX") + "Y:" + PlayerPrefs.GetFloat("playerPositionY") + "Z:" + PlayerPrefs.GetFloat("playerPositionZ"));
    }
}