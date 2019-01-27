using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM_Behavior : MonoBehaviour
{
    //Create a reference to this object that we can access from anywhere
    public static GM_Behavior instance;

    private int rayDist = 30;

    public Camera Cam;

    public Transform cursorObj;
    private GameObject MG_Cam;
    private GameObject lastInteracted;

    private RaycastHit hit;
    [HideInInspector]
    public Ray ray;
    [HideInInspector]
    public RaycastHit[] allHits;

    public const string DISHES = "DishesMG";
    public const string FIREPLACE = "FireplaceMG";
    public const string PICTURE = "PictureMG";
    public const string VACUUM = "VacuumMG";

    public enum Minigames
    {
        None,
        Dishes,
        Cleaning,
        Picture,
        Fireplace,
        Vacuum
    }

    public Minigames currentMG;
    private string currentMGScene;

    void Start()
    {
        Cam = Camera.main;
        instance = this;
        MG_Cam = GameObject.Find("MG Cam");
    }


    void Update()
    {

    }

    void FixedUpdate()
    {
        MonitorMousePos();
    }

    private void MonitorMousePos()
    {
        Debug.DrawLine(ray.origin, ray.GetPoint(rayDist), Color.blue);
        ray = Cam.ScreenPointToRay(Input.mousePosition);
        allHits = Physics.RaycastAll(ray);

        if (currentMG == Minigames.None)
        {
            if (Physics.Raycast(ray, out hit, rayDist))
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    //print(hit.collider);

                    if (lastInteracted)
                    {
                        lastInteracted.SendMessage("Deselect", SendMessageOptions.DontRequireReceiver);
                    }

                    lastInteracted = hit.collider.gameObject;
                    lastInteracted.SendMessage("OnSelected", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
        else if (currentMG == Minigames.Dishes)
        {
            if (Physics.Raycast(ray, out hit, rayDist))
            {

                if (Input.GetKey(KeyCode.Mouse0))
                {
                    //print(hit.collider);

                    if (hit.collider.tag == "Dishes")
                    {
                        hit.collider.gameObject.SendMessage("Clean", SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
        }
        else if (currentMG == Minigames.Picture)
        {
            if (Physics.Raycast(ray, out hit, rayDist, 1, QueryTriggerInteraction.Collide))
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    print(hit.collider);

                    //if (hit.collider.tag == "Dishes")
                    //{
                    //    hit.collider.gameObject.SendMessage("Clean, SendMessageOptions.DontRequireReceiver");
                    //}
                }
            }
        }
        else if (currentMG == Minigames.Fireplace)
        {
        }
        else if (currentMG == Minigames.Vacuum)
        {

        }
    }

    public void BeginMG(Minigames minigame)
    {
        string minigameScene = "";
        string title = "";
        string description = "";

        switch(minigame)
        {
            case Minigames.Dishes:
                minigameScene = DISHES;
                title = "Wash your dishes";
                description = "Clean to clean off spots";
                break;
            case Minigames.Picture:
                minigameScene = PICTURE;
                title = "Straighten the photo";
                description = "Use the buttons to adjust the photo's rotation";
                break;
            case Minigames.Vacuum:
                minigameScene = VACUUM;
                title = "Vacuum the carpet";
                description = "Move the cursor to vacuum up junk";
                break;
            case Minigames.Fireplace:
                minigameScene = FIREPLACE;
                title = "Light the fireplace";
                description = "Click and drag to move objects into the fireplace";
                break;
        }

        currentMG = minigame;
        currentMGScene = minigameScene;

        LoadFader.instance.FadeIn(() => {
            SceneManager.LoadScene(minigameScene, LoadSceneMode.Additive);
            MinigameText.instance.DisplayInstructions(title, description);
            LoadFader.instance.FadeOut();
        });
    }

    public void CompleteMinigame()
    {
        MinigameText.instance.MinigameFinished();
        LoadFader.instance.FadeIn(() =>
        {
            CozyMeter.instance.AddMeter(25f);
            currentMG = Minigames.None;
            SceneManager.UnloadSceneAsync(currentMGScene);
            LoadFader.instance.FadeOut();
            MinigameText.instance.HideFinishedText();
            CompleteButton.instance.Hide();
        });
    }
}
