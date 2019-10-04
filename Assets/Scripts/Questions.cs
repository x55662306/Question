using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Questions : MonoBehaviour {

    public class questionSample
    {
        public string question;
        public bool used;
        public int classNum;

        public questionSample(string q, bool u, int n)
        {
            this.question = q;
            this.used = u;
            this.classNum = n;
        }
    }

    //UI
    Text questionText;

    public List<questionSample> allQuestions = new List<questionSample>();

    // Use this for initialization
    void Start ()
    {
        
        //UI
        questionText = GameObject.Find("QuestionText").GetComponent<Text>();

        string filePath = Application.dataPath + "/StreamingAssets";
        string nameAndPath = filePath + "/" + "Question.txt";//存檔的位置加檔名
        //StreamReader _streamReader = File.OpenText(nameAndPath);
        StreamReader _streamReader = new System.IO.StreamReader(nameAndPath, System.Text.Encoding.Default);
        while (!_streamReader.EndOfStream)
        {
            string class_num = _streamReader.ReadLine();
            string data1 = _streamReader.ReadLine();
            string data2 = _streamReader.ReadLine();
            string data3 = _streamReader.ReadLine();
            string data4 = _streamReader.ReadLine();
            questionSample q = new questionSample(data1+"\n"+data2 + "\n" + data3 + "\n" + data4, false, int.Parse(class_num));
            allQuestions.Add(q);
        }
        _streamReader.Close();//記得要關閉，不然會報錯 
        //GetQuestion(11);
    }
	
    public void GetQuestion(int class_num)
    {
        questionSample q = allQuestions.Find((x) => (x.classNum == class_num && x.used == false));
        q.used = true;
        questionText.text = q.question;
    }

	// Update is called once per frame
	void Update ()
    {
		
	}
}
