using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DoubleLevelValidation : MonoBehaviour
{
    [SerializeField] Vector3 finalPosDouble = new Vector3(100, -50, 33);
    [SerializeField] Vector3 finalPosObject1 = new Vector3(100, -50, 33);
    [SerializeField] Vector3 finalPosObject2 = new Vector3(100, -50, 33);
    [SerializeField] Vector3 validationGape1 = new Vector3(20, 20, 20);
    [SerializeField] Vector3 validationGape2 = new Vector3(20, 20, 20);
    [SerializeField] Vector3 validationGapeDouble = new Vector3(20, 20, 20);
    public GameObject validationScreenUi;
    public GameObject EndScreenUi;
    public GameObject Object1;
    public GameObject Object2;
    public GameObject DoubleObjects;
    public int nextSceneLoad;
    private Vector3 initDoubleObjectRot;
    private Vector3 initDoubleObjectPos;
    private Vector3 initObject1Rot;
    private Vector3 initObject2Rot;

    void Start()
    {
        Debug.Log("TEST");
        initDoubleObjectPos = DoubleObjects.transform.position;
        initDoubleObjectRot = DoubleObjects.transform.rotation.eulerAngles;
        initObject1Rot = Object1.transform.rotation.eulerAngles;
        initObject2Rot = Object2.transform.rotation.eulerAngles;
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void ReinitLevel()
    {
        Quaternion rotDouble = Quaternion.Euler(initDoubleObjectRot);
        Quaternion rot1 = Quaternion.Euler(initObject1Rot);
        Quaternion rot2 = Quaternion.Euler(initObject2Rot);
        
        DoubleObjects.transform.rotation = rotDouble;
        DoubleObjects.transform.position = initDoubleObjectPos;
        Object1.transform.rotation = rot1;
        Object2.transform.rotation = rot2;
    }

    void ValidateLevel()
    {
        Quaternion rotDouble = Quaternion.Euler(finalPosDouble);
        Quaternion rot1 = Quaternion.Euler(finalPosObject1);
        Quaternion rot2 = Quaternion.Euler(finalPosObject2);
        
        DoubleObjects.transform.rotation = rotDouble;
        Object1.transform.rotation = rot1;
        Object2.transform.rotation = rot2;
        
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            Time.timeScale = 0f;
            EndScreenUi.SetActive(true);
        }
        else
        {
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
            Time.timeScale = 0f;
            validationScreenUi.SetActive(true);
        }
    }

    void ValidateDouble()
    {
        float bas = finalPosDouble.y - validationGapeDouble.y;
        float haut = finalPosDouble.y + validationGapeDouble.y;
        //Debug.Log("test bas: " + bas);
        //Debug.Log("test haut: " + haut);
        
        if (DoubleObjects.transform.rotation.eulerAngles.y > finalPosDouble.y - validationGapeDouble.y &&
            DoubleObjects.transform.rotation.eulerAngles.y < finalPosDouble.y + validationGapeDouble.y)
        {
            Debug.Log("Double Y correct");
            if (DoubleObjects.transform.rotation.eulerAngles.z > finalPosDouble.z - validationGapeDouble.z &&
                DoubleObjects.transform.rotation.eulerAngles.z < finalPosDouble.z + validationGapeDouble.z)
            {
                Debug.Log("Double Z correct");
                if (DoubleObjects.transform.rotation.eulerAngles.x > finalPosDouble.x - validationGapeDouble.x &&
                    DoubleObjects.transform.rotation.eulerAngles.x < finalPosDouble.x + validationGapeDouble.x)
                {
                    Debug.Log("Double X correct");
                    ValidateObject1();
                }
            }
        }
    }

    void ValidateObject1()
    {
        if (Object1.transform.rotation.eulerAngles.y > finalPosObject1.y - validationGape1.y &&
            Object1.transform.rotation.eulerAngles.y < finalPosObject1.y + validationGape1.y)
        {
            Debug.Log("1 Y correct");
            if (Object1.transform.rotation.eulerAngles.z > finalPosObject1.z - validationGape1.z &&
                Object1.transform.rotation.eulerAngles.z < finalPosObject1.z + validationGape1.z)
            {
                Debug.Log("1 Z correct");
                if (Object1.transform.rotation.eulerAngles.x > finalPosObject1.x - validationGape1.x &&
                    Object1.transform.rotation.eulerAngles.x < finalPosObject1.x + validationGape1.x)
                {
                    Debug.Log("1 X correct");
                    ValidateObject2();
                }
            }
        }
    }

    void ValidateObject2()
    {
        if (Object2.transform.rotation.eulerAngles.y > finalPosObject2.y - validationGape2.y &&
            Object2.transform.rotation.eulerAngles.y < finalPosObject2.y + validationGape2.y)
        {
            Debug.Log("2 Y correct");
            if (Object2.transform.rotation.eulerAngles.z > finalPosObject2.z - validationGape2.z &&
                Object2.transform.rotation.eulerAngles.z < finalPosObject2.z + validationGape2.z)
            {
                Debug.Log("2 Z correct");
                if (Object2.transform.rotation.eulerAngles.x > finalPosObject2.x - validationGape2.x &&
                    Object2.transform.rotation.eulerAngles.x < finalPosObject2.x + validationGape2.x)
                {
                    Debug.Log("2 X correct");
                    ValidateLevel();
                }
            }
        }
    }

    void Update()
    {
        // Uncomment for debugging purposes
        //Debug.Log("1" + Object1.transform.rotation.eulerAngles);
        //Debug.Log("2" + Object2.transform.rotation.eulerAngles);
        //Debug.Log("Double" + DoubleObjects.transform.rotation.eulerAngles);
        
        ValidateDouble();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reset");
            ReinitLevel();
        }
    }
}
