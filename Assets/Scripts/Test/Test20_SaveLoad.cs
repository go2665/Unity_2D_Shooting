using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;

public class Test20_SaveLoad : TestBase
{
    public int score = 12345;
    public bool isStartDie = false;

    Player player;
    ScoreText scoreText;
    RankPanel rankPanel;

#if UNITY_EDITOR

    private void Start()
    {
        player = GameManager.Instance.Player;
        scoreText = GameManager.Instance.ScoreText;

        rankPanel = FindFirstObjectByType<RankPanel>();
        rankPanel.Test_DefaultRankPanel();

        if (isStartDie)
        {
            player.TestDeath();
        }
    }

    protected override void OnTest1(InputAction.CallbackContext context)
    {
        rankPanel.Test_UpdateRankPanel(score);
    }

    protected override void OnTest2(InputAction.CallbackContext context)
    {
        rankPanel.Test_Save();
    }

    protected override void OnTest3(InputAction.CallbackContext context)
    {
        rankPanel.Test_Load();
    }

    protected override void OnTest4(InputAction.CallbackContext context)
    {
        Debug.Log("저장하기");
        //System.IO.File.WriteAllText("a.txt", "Hello");

        // Application.dataPath : 에디터에서 실행했을 때는 Assets 폴더를 의미, 빌드해서 실행 했을 때는 "실행파일이름_Data" 폴더를 의미
        //System.IO.File.WriteAllText($"{Application.dataPath}/a.txt", "Hello");  

        //System.IO.File.WriteAllText($"{Application.dataPath}/Save/a.txt", "Hello");   // 폴더가 없어서 죽음

        if(Directory.Exists($"{Application.dataPath}/Save"))
        {
            Debug.Log("Assets 폴더안에 Save 폴더가 있다.");
        }
        else
        {
            Debug.Log("Assets 폴더안에 Save 폴더가 없다.");
            Directory.CreateDirectory($"{Application.dataPath}/Save");
        }

        File.WriteAllText($"{Application.dataPath}/Save/a.txt", "Hello");   // 폴더가 없었더라도 새로 만드니까 OK
    }

    protected override void OnTest5(InputAction.CallbackContext context)
    {
        Debug.Log("불러오기");
        string result = System.IO.File.ReadAllText("a.txt");
        Debug.Log($"{result} 읽음");
    }


#endif
}
