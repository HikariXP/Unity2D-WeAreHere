using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    //个体区
    public AudioClip MainMusic;
    public AudioClip PlayingMusic;

    //数值区
    public int launchTime = 0;

    public int ClownFish = 0;
    public int Salmo_salar = 0;
    public int Shark = 0;
    public int Atlanticbluefin_tuna = 0;


    [Serializable] //序列化，才能显示在层次面板上
    public struct Map
    {
        public string Name;  //名称
        public string Id;    //id
        public Sprite map;
    }

    public Map[] maps;

    [Serializable] //序列化，才能显示在层次面板上
    public struct Fish
    {
        public string FishName;  //名称
        public string FishId;    //id
        public int AppearArea;
        public float chance;
        public GameObject theFish;
    }

    public Fish[] fish;

    public int skyNumber;

    public int seaId = 1;

    public int fishHaveFound = 0;
    //判定区
    public bool isFirstPlaying = true;

    public bool isMainMoveToRightWay = false;

    public bool isGameMoveToRightWay = false;

    public bool isbusy = false;

    public bool isMainLoaded = false;

    public bool isPause = false;

    public bool isIntroducing = false;

    public bool isSelectLevel = false;

    public bool isBookIng = false;

    public bool isMainStart = false;

    public bool isCatchPushed = false;

    public bool isGameLoaded = false;

    public bool isGameStart = false;

    public bool isNearMine = false;

    public bool isConfirmGameOver = false;

    public bool isGameOver = false;

    public bool goingToExit = false;

    public bool isMoveToBook = false;

    public void Awake()
    {
        LoadGame();
    }

    private void Start()
    {
        skyNumber = UnityEngine.Random.Range(1, 5);
    }

    public void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Main")
        {
            gameObject.GetComponent<AudioSource>().clip = MainMusic;
        }
        if (scene.name == "Playing")
        {
            gameObject.GetComponent<AudioSource>().clip = PlayingMusic;
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            if (!goingToExit&&(Input.GetKeyDown(KeyCode.Escape)))
            {
                goingToExit = true;
            }
            if (goingToExit&& (Input.GetKeyDown(KeyCode.Escape)))
            {
                goingToExit = false;
            }
            if (isPause && (Input.GetKeyDown(KeyCode.Escape))&&!goingToExit)
            {
                isPause = false;
            }
        }
    }

    private SaveProject CreateSaveGameObject()
    {
        SaveProject save = new SaveProject();
        return save;
    }
    public void SaveGame()
    {
        // 1
        SaveProject save = CreateSaveGameObject();
        save.launchTime = this.launchTime;
        save.fishHaveFound = this.fishHaveFound;
        save.clownFish = this.ClownFish;
        save.Salmo_salar = this.Salmo_salar;
        save.Shark = this.Shark;
        save.Atlanticbluefin_tuna = this.Atlanticbluefin_tuna;
        save.isFirstLaunch = this.isFirstPlaying;
        // 2
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        // 3
        
        Debug.Log("Game Saved");
    }
    public void LoadGame()
    {
        // 1
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            // 2
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            SaveProject save =(SaveProject)bf.Deserialize(file);
            this.launchTime = save.launchTime;
            this.fishHaveFound = save.fishHaveFound;
            this.Atlanticbluefin_tuna = save.Atlanticbluefin_tuna;
            this.Shark = save.Shark;
            this.Salmo_salar = save.Salmo_salar;
            this.ClownFish = save.clownFish;
            this.isFirstPlaying = save.isFirstLaunch;
            file.Close();

            // 3
            Debug.Log("Game Loaded");

            
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }
}
