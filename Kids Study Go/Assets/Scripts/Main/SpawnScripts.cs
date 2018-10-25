using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnScripts : MonoBehaviour
{

    public bool enableSpawn = false;
    public GameObject SpawnObject1; //Prefab을 받을 public 변수 입니다.
    public GameObject SpawnObject2;
    public GameObject SpawnObject3;
    public GameObject obj;
    int time = 0;
    int spawnnum = 0;
    System.Random num = new System.Random();

    public string[] WholeData;

    void Start()
    {
        StartCoroutine(RandomSpawn());
    }

    void Update()
    {

    }

    Vector3 Setpos()
    {
        float PosX = UnityEngine.Random.Range(-1f, 1f);
        float PosY = UnityEngine.Random.Range(-2f, 2f);

        Vector3 Pos = new Vector3(PosX, PosY, 0);
        Pos.z = 0;

        return Pos;
    }

    IEnumerator RandomSpawn()
    {

        WWWForm form = new WWWForm();
        form.AddField("Output_user", LoginManager.webRequest.text.ToString());

        WWW UserData = new WWW("http://13.125.210.53/kids/main/QuizSpawn.php", form);
        yield return UserData;

        while (true)
        {
            time = num.Next(0, 3);
            switch (time % 3)
            {
                case 0:
                    Instantiate(SpawnObject1, Setpos(), Quaternion.identity);
                    SpawnObject1.SetActive(true);
                    break;
                case 1:
                    Instantiate(SpawnObject2, Setpos(), Quaternion.identity);
                    SpawnObject2.SetActive(true);
                    break;
                case 2:
                    if (Int32.Parse(UserData.text) != 0)
                    {
                        Instantiate(SpawnObject3, Setpos(), Quaternion.identity);
                        SpawnObject3.SetActive(true);
                    }
                    break;
            }

            yield return new WaitForSeconds(7f); //생성쿨타임
        }
    }
}

/*
void Start()
{
    InvokeRepeating("SpawnEnemy", 1, 10); //1초후 부터, SpawnEnemy함수를 10초마다 반복해서 실행 시킵니다.
}

void Update()
{

}

void SpawnEnemy()
{
    float randomX = Random.Range(0f, 1f); //적이 나타날 X좌표를 랜덤으로 생성해 줍니다.(20~180)
    float randomY = Random.Range(0f, 1f); //적이 나타날 Y좌표를 랜덤으로 생성해 줍니다.(30~320)

    Vector3 worldPos = Camera.main.ViewportToWorldPoint(new Vector3(randomX, randomY, 0f));
    worldPos.z = 0f;

    if (enableSpawn)
    {
        GameObject enemy = (GameObject)Instantiate(SpawnObject, worldPos, Quaternion.identity); //랜덤한 위치와, 지정된 좌표에서 Enemy를 하나 생성해줍니다.
        //print(worldPos); //test code
        SpawnObject.SetActive(true);
    }
}
*/

/*
public bool enableSpawn = false;
        public GameObject Enemy; //Prefab을 받을 public 변수 입니다.
        void SpawnEnemy()
        {
            float randomX = Random.Range(-0.5f, 0.5f); //적이 나타날 X좌표를 랜덤으로 생성해 줍니다.
            if (enableSpawn)
            {
                GameObject enemy = (GameObject)Instantiate(Enemy, new Vector3(randomX, 0.5f, 0f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
            }
        }
        void Start()
        {
            InvokeRepeating("SpawnEnemy", 3, 1); //3초후 부터, SpawnEnemy함수를 1초마다 반복해서 실행 시킵니다.
        }
        void Update()
        {

        }
*/

/*
    [게임오브젝트].GetComponent<Image>().sprite = Resources.Load("[이미지경로]", typeof(Sprite)) as Sprite;
    
    Sprite[] sprites = Resources.LoadAll<Sprite>("[이미지경로]");
*/

