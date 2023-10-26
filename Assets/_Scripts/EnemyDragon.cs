using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDragon : MonoBehaviour
{
    public GameObject DragonEggPrefab;
    public float Speed = 1f;
    public float TimeBetweenEggDrops = 1f;
    public float LeftRightDistance = 10f;
    public float ChanceDirection = 0.1f;
    private GSheets gSheet;
    
    void Start()
    {
        gSheet = GameObject.FindGameObjectWithTag("GSheet").GetComponent<GSheets>();
        StartCoroutine(GetValues());
    }

    private IEnumerator GetValues()
    {
        yield return StartCoroutine(gSheet.Load());

        int levelIndex = LevelData.LevelIndex;

        Speed = gSheet.SpeedData[levelIndex];
        TimeBetweenEggDrops = gSheet.TimeBetweenEggDropsData[levelIndex];
        LeftRightDistance = gSheet.LeftRightDistanceData[levelIndex]; 
        ChanceDirection = gSheet.ChanceDirectionData[levelIndex];       

        Invoke("DropEgg", 2f);
    }

    void DropEgg()
    {
        Vector3 myVector = new Vector3(0.0f, 5.0f, 0.0f);
        GameObject egg = Instantiate<GameObject>(DragonEggPrefab);
        egg.transform.position = transform.position + myVector;
        Invoke("DropEgg", TimeBetweenEggDrops);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += Speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -LeftRightDistance)
        {
            Speed = Mathf.Abs(Speed);
        }
        else if (pos.x > LeftRightDistance)
        {
            Speed = -Mathf.Abs(Speed);
        }
    }

    private void FixedUpdate()
    {
        if (Random.value < ChanceDirection)
        {
            Speed *= -1;
        }
    }
}
