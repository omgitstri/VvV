using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{
    /* The toolbox used to reference & call most managers by using Toolbox.GetInstance.[class name]().functionName();
        
        - Available class references are shown after the Awake function
        
     */

    private static Toolbox _instance = null;

    public static Toolbox GetInstance {
        get {
            if (Toolbox._instance == null) {
                var goToolbox = new GameObject(nameof(Toolbox));
                //DontDestroyOnLoad(goToolbox);
                Toolbox._instance = goToolbox.AddComponent<Toolbox>();
            }
            return Toolbox._instance;
        }
    }

    [SerializeField] private SceneLoader manager = null;
    [SerializeField] private EnemyStatsManager statsManager = null;
    [SerializeField] private GameObject soundManager = null;
    [SerializeField] private GameObject uIManager = null;
    [SerializeField] private MusicManager musicManager = null;
    [SerializeField] private GameObject screenFade = null;


    void Awake()
    {
        //Instantiate(soundManager, this.gameObject.transform);

        if (Toolbox._instance != null)
        {
            Destroy(this.gameObject);
        }

        //manager = GameObject.FindGameObjectWithTag("Manager");

        if (manager == null) {
            var go = new GameObject(nameof(manager));
            go.transform.SetParent(transform);
            manager = go.AddComponent<SceneLoader>();
        }

        if (statsManager == null) {
            var go = new GameObject(nameof(statsManager));
            go.transform.SetParent(transform);
            statsManager = go.AddComponent<EnemyStatsManager>();
        }

        if (soundManager == null)
        {
            soundManager = Instantiate(Resources.Load(nameof(SoundManager), typeof(GameObject)) as GameObject);
            soundManager.transform.SetParent(transform);
        }

        if (musicManager == null) {
            if (soundManager != null) {
                musicManager = soundManager.GetComponent<MusicManager>();
            }
        }

        if (uIManager == null)
        {
            uIManager = Instantiate(Resources.Load(nameof(UIManager), typeof(GameObject)) as GameObject);
            uIManager.transform.SetParent(transform);
        }
        
        if (screenFade == null) {
            screenFade = Instantiate(Resources.Load(nameof(ScreenFade), typeof(GameObject)) as GameObject);
            screenFade.transform.SetParent(transform);
        }

    }

    public SceneLoader GetScene()
    {
        return manager;
    }

    public EnemyStatsManager GetStats() {
        return statsManager;
    }

    public SoundManager GetSound()
    {
        return soundManager.GetComponent<SoundManager>();
    }

    public MusicManager GetMusic() {
        return musicManager.GetComponent<MusicManager>();
    }

    public UIManager GetUI()
    {
        return uIManager.GetComponent<UIManager>();
    }

    public ScreenFade GetFade() {
        return screenFade.GetComponent<ScreenFade>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.F1)) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            manager.GetComponent<SceneLoader>().LoadScene("SceneLoadingGym");
        }    
    }

}