using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class BrickSpawner : MonoBehaviour
{
    public BrickBehaviour brickPrefab;
    
    public int width;
    public int height;
    
    public float horizontalMargin;
    public float verticalMargin;

    //private Vector2 spawnPosition;

    private void Start()
    {
       // SetupExistingBricksInScene();
        SpawnBricks();
        SetupExistingBricksInScene();
    }

    public void Update()
    {
        OnBrickHit();
    }

    private void SetupExistingBricksInScene()
    {
        BrickBehaviour[] existingBricks = FindObjectsOfType<BrickBehaviour>();
        for (int i = 0; i < existingBricks.Length; i++)
        {
            existingBricks[i].SetSpawner(this);
            existingBricks[i].transform.SetParent(transform);
        }
    }

    private void SpawnBricks()
    {
        Vector3 placeBricks = Vector3.zero;

        for (int y = 0; y < height; ++y) 
        { 
            for (int x = 0; x < width; ++x)
            {
                BrickBehaviour newBrick = Instantiate(brickPrefab, transform.position - new Vector3(width/2, height/2,0) - new Vector3(horizontalMargin * 2,verticalMargin,0) + placeBricks, Quaternion.identity); 
                // Instantiate(brickPrefab, spawnPosition + new Vector2(x,y), Quaternion.identity);
                
                newBrick.SetSpawner(this); 
                newBrick.transform.SetParent(transform);

                placeBricks += Vector3.right * horizontalMargin;
            }
            placeBricks.x = 0;
            placeBricks += Vector3.up * verticalMargin;
        }
    }

    public void OnBrickHit()
    {
        if (IsGameWon())
        {
            LoadNextScene();
        }
    }

    private bool IsGameWon()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                return false;
            }
        }

        return true;
    }

    private void LoadNextScene()
    {
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

        currentSceneBuildIndex++;

        if (currentSceneBuildIndex >= SceneManager.sceneCountInBuildSettings)
        {
            currentSceneBuildIndex = 0;
        }

        SceneManager.LoadScene(currentSceneBuildIndex);
    }
    
    private void OnDrawGizmos()
    { 
        Vector3 placeBricks = Vector3.zero;
        for (int y = 0; y < height; ++y)
        {
            for (int x = 0; x < width; ++x)
            {
                Gizmos.DrawWireCube(transform.position - new Vector3(width/2, height/2,0) - new Vector3(horizontalMargin * 2,verticalMargin,0) + placeBricks, brickPrefab.transform.localScale);
                placeBricks += Vector3.right * horizontalMargin;
                
            }
            placeBricks.x = 0;
            placeBricks += Vector3.up * verticalMargin;
        }
    }
}
