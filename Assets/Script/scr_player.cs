using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scr_player : MonoBehaviour {

    public float speed = 1;
    public GameObject[] goChange;
    public GameObject goManager;
    public int tfMax;
    public Text txtTf;

    private float maxspeed;
    private bool canChange = true;

    // Use this for initialization
    void Start ()
    {
        goManager = GameObject.FindGameObjectWithTag("manager");
        txtTf = GameObject.FindGameObjectWithTag("uiTf").GetComponent<Text>();
        txtTf.text = tfMax.ToString();
        maxspeed = speed;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Change(0);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            Change(1);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            Change(2);

        if (Input.GetKeyDown(KeyCode.R))
            Application.LoadLevel(Application.loadedLevel);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(movV, 0f, -movH);

        transform.position += movement * speed * Time.deltaTime;
    }

    void Change(int i)
    {
        if (tfMax > 0)
        {
            foreach(GameObject go in goChange)
            {
                go.SetActive(false);
            }

            goChange[i].SetActive(true);
            tfMax--;
            txtTf.text = tfMax.ToString();

        }

}

void OnTriggerEnter(Collider col)
    {
        if (col.tag == "score")
        {
            goManager.GetComponent<scr_GameManager>().TakeScore();
            Destroy(col.gameObject);
        }
    }

}
