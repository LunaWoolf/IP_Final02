using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public AudioSource theMusic;
    public Animator anim;
    public bool start;

    public BeatScroller beatScro;

    public static GameController instance;

    public int curScore;
    public int scorePreNote = 100;
    public int curCombo = 0;
    public int highestCombo = 0;

    public GameObject noteSheet;
    public GameObject leftkey;
    public Vector3 leftnotepos;
    public GameObject upkey;
    public Vector3 upnotepos;
    public GameObject downkey;
    public Vector3 downnotepos;
    public GameObject rightkey;
    public Vector3 rightnotepos;


    public GameObject leftActivaor;
    public GameObject upActivaor;
    public GameObject downActivaor;
    public GameObject rightActivaor;

    public Vector3 noteGenerateHeight;

    public GameObject scoretext;
    public GameObject combotext;

    SceneManage sm;

    int level;

    void Start()
    {
        instance = this;
		sm = FindObjectOfType<SceneManage>();
        sm.anim = anim;
        theMusic.clip = sm.selectMusic.musicClip;
        level = sm.level;
	}

    void FixedUpdate()
    {
        NotepositionUpdate();
    }

    void Update()
    {

        if (!start)
        {
			if (Input.anyKeyDown)
			{
				start = true;
				beatScro.start = true;

				theMusic.Play();
				if (level == 0)
				{
					StartCoroutine(GenerateNoteEasy());
				}
				else
				{
					StartCoroutine(GenerateNoteHard());
				}

			}
        }
        else
        {
            RenderSettings.skybox.SetFloat("_AtmosphereThickness", Mathf.Sin(Time.time * Mathf.Deg2Rad * 100 * 0.2f) + 2f);

            if (!theMusic.isPlaying)
            {
                if (curCombo > highestCombo)
                {
                    highestCombo = curCombo;
                }
                curScore = sm.score;
                highestCombo = sm.combo;
                sm.ToEndScene();
            }

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (curCombo > highestCombo)
            {
                highestCombo = curCombo;
            }
            sm.score = curScore;
            sm.combo = highestCombo;
            sm.ToEndScene();
        }

    }

    private IEnumerator GenerateNoteEasy()
    {
        while (start)
        {
            
            yield return new WaitForSeconds(beatScro.bpm/2);
            GameObject newNote = null;
            int random = Random.Range(0, 4);
            switch (random)
            {
                case 0:
                    newNote = Instantiate(leftkey, noteSheet.GetComponent<Transform>());
                    newNote.transform.position = leftnotepos;
                    break;
                case 1:
                    newNote = Instantiate(upkey, noteSheet.GetComponent<Transform>());
                    newNote.transform.position = upnotepos;
                    break;
                case 2:
                    newNote = Instantiate(downkey, noteSheet.GetComponent<Transform>());
                    newNote.transform.position = downnotepos;
                    break;
                case 3:
                    newNote = Instantiate(rightkey, noteSheet.GetComponent<Transform>());
                    newNote.transform.position = rightnotepos;
                    break;

            }
            
        } 

    }

    private IEnumerator GenerateNoteHard()
    {
        while (start)
        {

            yield return new WaitForSeconds(beatScro.bpm / 2);
            GameObject newNote = null;
            int random = Random.Range(0, 5);
            switch (random)
            {
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

    public void NotepositionUpdate()
    {
        leftnotepos = leftActivaor.transform.position + noteGenerateHeight;
        upnotepos = upActivaor.transform.position + noteGenerateHeight;
        downnotepos = downActivaor.transform.position + noteGenerateHeight;
        rightnotepos = rightActivaor.transform.position + noteGenerateHeight;
    }


    public void NoteHit()
    {
        curCombo++;
        curScore += scorePreNote * curCombo;
        scoretext.GetComponent<Text>().text = "Score: " + curScore;
        combotext.GetComponent<Text>().text = "Combo: " + curCombo;
    }

    public void NoteMiss()
    {
        if (curCombo > highestCombo)
        {
            highestCombo = curCombo;
        }
        curCombo = 0;
        combotext.GetComponent<Text>().text = "Combo: " + curCombo;
    }
}
