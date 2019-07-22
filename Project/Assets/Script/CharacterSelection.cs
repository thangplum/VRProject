﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{

    private GameObject[] characterList;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        characterList = new GameObject[2];
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }
        foreach(GameObject go in characterList)
        {
            go.SetActive(false);
        }
        if (characterList[0])
        {
            characterList[0].SetActive(true);
        }
    }

    public void ToggleLeft()
    {
        characterList[index].SetActive(false);
        index--;
        if (index < 0)
        {
            index = characterList.Length - 1;
        }
        characterList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        characterList[index].SetActive(false);
        index++;
        if (index < 0)
        {
            index = characterList.Length + 1;
        }
        characterList[index].SetActive(true);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Terrain");
    }
}
