using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This is the script for the Game Controller. It will generate the note at runtime 
//and keep track of the score and the combo
public class GameController : MonoBehaviour
{
    public AudioSource theMusic; // The Music that is played during the game
    public Animator anim; //animator for the scene trans Animation
    public bool start; // check is the game start

    public BeatScroller beatScro;// reference to the bat Scroller
    public static GameController instance;

    public int curScore;
    public int scorePreNote = 100;
    public int curCombo = 0; // current combo
    public int highestCombo = 0; //keep track of the highest combo this turn

    public GameObject noteSheet;
    public GameObject leftkey; // reference to the left Note
    public Vector3 leftnotepos;
    public GameObject upkey; // reference to the up Note
    public Vector3 upnotepos;
    public GameObject downkey; // reference to the down Note
    public Vector3 downnotepos;
    public GameObject rightkey; // reference to the right Note
    public Vector3 rightnotepos;

    //// reference to the four Activaor
    public GameObject leftActivaor;
    public GameObject upActivaor;
    public GameObject downActivaor;
    public GameObject rightActivaor;
    // The Height that note being generate
    public Vector3 noteGenerateHeight;

    public GameObject scoretext; //GameObject of the text of score
    public GameObject combotext;//GameObject of the text of combo

    SceneManage sm;// reference to Scene Manager
    int level; // level of difficulty
    bool end = false;

    void Start()
    {
        instance = this;
        sm = FindObjectOfType<SceneManage>();
        sm.anim = anim;
        theMusic.clip = sm.selectMusic.musicClip;// get the Music Clip from scene Manager 
        level = sm.level; // get the levle value from scene Manager 
    }

    void FixedUpdate()
    {
        NotepositionUpdate(); // Update the position for note generation each frame
    }

    void Update()
    {

        if (!start)
        {
            // Start the Game by pressed any key
            if (Input.anyKeyDown)
            {
                start = true;
                beatScro.start = true;
                theMusic.Play(); // Play the music once the game start 
                if (level == 0) // Start to generate note depends on the level of difficulty
                {
                    StartCoroutine(GenerateNoteEasy()); // Easy mode
                }
                else
                {
                    StartCoroutine(GenerateNoteHard());// Hard mode
                }

            }
        }
        else
        {
            //Change the skybox
            RenderSettings.skybox.SetFloat("_AtmosphereThickness", Mathf.Sin(Time.time * Mathf.Deg2Rad * 100 * 0.2f) + 2f);

            //if music finished playing, end the game and goes to the end Scne
            if (!theMusic.isPlaying && !end)
            {
                end = true;
                // check is current combo larger than the current highestCombo, if true, change the current highestCombo to current Combo
                if (curCombo > highestCombo)
                {
                    highestCombo = curCombo;
                }
                sm.score = curScore; // set the value of the scene Manager 
                sm.combo = highestCombo;
                sm.ToEndScene(); // Move to end scene
            }
        }
    }

    // Generate Note for the Easy level, There will only be one note fall at each time for the this mode 
    private IEnumerator GenerateNoteEasy()
    {
        while (start)
        {

            yield return new WaitForSeconds(beatScro.bpm / 2); // Wait for each beat
            GameObject newNote = null;
            int random = Random.Range(0, 4); // make a random seed number that the generate based on
            switch (random)
            {
                //Generate left note
                case 0:
                    newNote = Instantiate(leftkey, noteSheet.GetComponent<Transform>());
                    newNote.transform.position = leftnotepos;
                    break;
                //Generate up note
                case 1:
                    newNote = Instantiate(upkey, noteSheet.GetComponent<Transform>());
                    newNote.transform.position = upnotepos;
                    break;
                //Generate down note
                case 2:
                    newNote = Instantiate(downkey, noteSheet.GetComponent<Transform>());
                    newNote.transform.position = downnotepos;
                    break;
                //Generate right note
                case 3:
                    newNote = Instantiate(rightkey, noteSheet.GetComponent<Transform>());
                    newNote.transform.position = rightnotepos;
                    break;

            }

        }

    }

    // Generate Note for the Hard level, There will be two note fall at the same time for the this mode 
    private IEnumerator GenerateNoteHard()
    {
        while (start)
        {

            yield return new WaitForSeconds(beatScro.bpm / 2); // Wait for each beat
            GameObject newNote = null;
            int random = Random.Range(0, 5); // make a random seed number that the generate based on
            switch (random)
            {
                //Generate left & up note
                case 0:
                    newNote = Instantiate(leftkey, noteSheet.GetComponent<Transform>());
                    newNote.transform.position = leftnotepos;
                    newNote = Instantiate(upkey, noteSheet.GetComponent<Transform>());
                    newNote.transform.position = upnotepos;
                    break;
                case 1:
                    newNote = Instantiate(leftkey, noteSheet.GetComponent<Transform>());
                    newNote.transform.position = leftnotepos;
                    newNote = Instantiate(downkey, noteSheet.GetComponent<Transform>());
                    newNote.transform.position = downnotepos;
                    break;
                case 2:
                    newNote = Instantiate(leftkey, noteSheet.GetComponent<Transform>());
                    newNote.transform.position = leftnotepos;
                    newNote = Instantiate(rightkey, noteSheet.GetComponent<Transform>());
                    newNote.transform.position = rightnotepos;
                    break;
                case 3:
                    newNote = Instantiate(upkey, noteSheet.GetComponent<Transform>());
                    newNote.transform.position = upnotepos;
                    newNote = Instantiate(downkey, noteSheet.GetComponent<Transform>());
                    newNote.transform.position = downnotepos;
                    break;
                case 4:
                    newNote = Instantiate(upkey, noteSheet.GetComponent<Transform>());
                    newNote.transform.position = upnotepos;
                    newNote = Instantiate(rightkey, noteSheet.GetComponent<Transform>());
                    newNote.transform.position = rightnotepos;
                    break;
                case 5:
                    newNote = Instantiate(downkey, noteSheet.GetComponent<Transform>());
                    newNote.transform.position = downnotepos;
                    newNote = Instantiate(rightkey, noteSheet.GetComponent<Transform>());
                    newNote.transform.position = rightnotepos;
                    break;
            }

        }

    }

    // Update the current position for the note to be generate. Which is the position of the Activator plus the height
    public void NotepositionUpdate()
    {
        leftnotepos = leftActivaor.transform.position + noteGenerateHeight;
        upnotepos = upActivaor.transform.position + noteGenerateHeight;
        downnotepos = downActivaor.transform.position + noteGenerateHeight;
        rightnotepos = rightActivaor.transform.position + noteGenerateHeight;
    }

    // this is called when player hit the note.
    public void NoteHit()
    {
        curCombo++; // plus combo
        curScore += scorePreNote * curCombo;
        scoretext.GetComponent<Text>().text = "Score: " + curScore; // Set the text 
        combotext.GetComponent<Text>().text = "Combo: " + curCombo;
    }

    // this is called when player miss the note.
    public void NoteMiss()
    {
        // check is current combo larger than the current highestCombo, if true, change the current highestCombo to current Combo
        if (curCombo > highestCombo)
        {
            highestCombo = curCombo;
        }
        curCombo = 0; // resest the current combo 
        combotext.GetComponent<Text>().text = "Combo: " + curCombo;
    }
}