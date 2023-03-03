using UnityEngine;

public class SpamEnemy : MonoBehaviour
{
    [SerializeField]
    GameObject enemy_0;
    [SerializeField]
    GameObject enemy_1;
    [SerializeField]
    GameObject enemy_2;
    [SerializeField]
    GameObject enemy_3;

    [SerializeField]
    float timeSam0;
    [SerializeField]
    float timeSam1;
    [SerializeField]
    float timeSam2;
    [SerializeField]
    float timeSam3;

    float screenLeft, screenTop, screenRight, screenBottom;
    float time0;
    float time1;
    float time2;
    float time3;

    // Start is called before the first frame update
    void Start()
    {
        float screenZ = -Camera.main.transform.position.z;
        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 upperRightCornerScreen = new Vector3(Screen.width, Screen.height, screenZ);
        Vector3 lowerLeftCornerWorld = Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
        Vector3 upperRightCornerWorld = Camera.main.ScreenToWorldPoint(upperRightCornerScreen);
        screenLeft = lowerLeftCornerWorld.x;
        screenRight = upperRightCornerWorld.x;
        screenTop = upperRightCornerWorld.y;
        screenBottom = lowerLeftCornerWorld.y;

        time0 = timeSam0;
        time1 = timeSam1;
        time2 = timeSam2;
        time3 = timeSam3;
    }

    // Update is called once per frame
    void Update()
    {
        time0 += Time.deltaTime;
        time1 += Time.deltaTime;
        time2 += Time.deltaTime;
        time3 += Time.deltaTime;

        
        if(time0 >= timeSam0)
        {
            Vector2 position = new Vector2(Random.Range(screenLeft - 0.5f, screenRight + 0.5f), Random.Range(screenBottom - 0.5f, screenTop + 0.5f));
            GameObject gameObject = Instantiate(enemy_0);
            gameObject.transform.position = position;
            time0 = 0;
        }

        if (time1 >= timeSam1)
        {
            Vector2 position = new Vector2(Random.Range(screenLeft - 0.5f, screenRight + 0.5f), Random.Range(screenBottom - 0.5f, screenTop + 0.5f));
            GameObject gameObject = Instantiate(enemy_1);
            gameObject.transform.position = position;
            time1 = 0;
        }

        if (time2 >= timeSam2)
        {
            Vector2 position = new Vector2(Random.Range(screenLeft - 0.5f, screenRight + 0.5f), Random.Range(screenBottom - 0.5f, screenTop + 0.5f));   
            GameObject gameObject = Instantiate(enemy_2);
            gameObject.transform.position = position;
            time2 = 0;
        }
        if (time3 >= timeSam3)
        {
            Vector2 position = new Vector2(Random.Range(screenLeft - 0.5f, screenRight + 0.5f), Random.Range(screenBottom - 0.5f, screenTop + 0.5f));
            GameObject gameObject = Instantiate(enemy_3);
            gameObject.transform.position = position;
            time3 = 0;
        }

    }
}
