using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject createA()
    {
        return Resources.Load<GameObject>("a");
    }
    public GameObject createB()
    {
        return Resources.Load<GameObject>("b");
    }
    public GameObject createC()
    {
        return Resources.Load<GameObject>("c");
    }
    public List<GameObject> level1 = new List<GameObject>();
    public List<GameObject> level2 = new List<GameObject>();
    public List<GameObject> level3 = new List<GameObject>();
    GameObject currentBox;
    [SerializeField]
    GameObject displayGameObject;
    Text text;
    int boxCount = 0;
    int level = 0;
    // Start is called before the first frame update
    void spawnBox()
    {
        currentBox = Instantiate(Resources.Load<GameObject>("box"));
        boxCount += 1;
    }
    
    void deleteBox()
    {
        Destroy(currentBox);
        currentBox = null;
    }
    void populateList(int a, int b, int c, List<GameObject> list)
    {
        for(int i = 0; i < a; i ++)
        {
            list.Add(createA());
        }
        for (int i = 0; i < b; i++)
        {
            list.Add(createB());
        }
        for (int i = 0; i < c; i++)
        {
            list.Add(createC());
        }
    }

    void setText()
    {
        text.text = $"Current level: {level} Boxes on this level: {boxCount}";
    }
    void Start()
    {
        text = displayGameObject.GetComponent<Text>();
        populateList(2, 6, 2, level1);
        populateList(5, 10, 5, level2);
        populateList(12, 12, 6, level3);
    }

    void fillBoxes()
    {
        if(level1.Count > 0)
        {
            level = 1;
            tryPutItemInBox();
        }
        else if(level2.Count >0)
        {
            level = 2;
        }
        else if(level3.Count >0)
        {
            level = 3;
        }
    }

    void tryPutItemInBox()
    {
        if(currentBox == null)
        {
            spawnBox();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        fillBoxes();
        setText();
    }
}
