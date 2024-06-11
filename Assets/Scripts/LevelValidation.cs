using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelValidation : MonoBehaviour
{
    [SerializeField] Vector3 finalPos = new Vector3(100, -50, 33);
    public GameObject validationScreenUi;
    public GameObject EndScreenUi;
    public int nextSceneLoad;
    public int validationRange = 10;
    private Vector3 initObjectPos;

    void Start()
    {
        initObjectPos=transform.rotation.eulerAngles;
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void reinitLevel() {
        Quaternion rot=new Quaternion();
        rot.eulerAngles = initObjectPos;
        transform.rotation=rot;
    }

    void Update()
    {
        if (transform.rotation.eulerAngles.y>finalPos.y - validationRange & transform.rotation.eulerAngles.y<finalPos.y + validationRange){
            if (transform.rotation.eulerAngles.z>finalPos.z - validationRange & transform.rotation.eulerAngles.z<finalPos.z + validationRange){
                if (transform.rotation.eulerAngles.x>finalPos.x - validationRange & transform.rotation.eulerAngles.x<finalPos.x + validationRange){
                    Quaternion rot=new Quaternion();
                    rot.eulerAngles = finalPos;
                    transform.rotation=rot;
                    if(SceneManager.GetActiveScene().buildIndex == 4) {
                        Time.timeScale = 0f;
                        EndScreenUi.SetActive(true);
                    }
                    else {
                        if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                        {
                            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                        }
                        validationScreenUi.SetActive(true);
                        Time.timeScale = 0f;
                    }
                }
            }
        }
    }

    void FixedUpdate(){
        if (Input.GetKeyDown(KeyCode.R)){
            Debug.Log("Reset");
            reinitLevel();
        }
    }
}
