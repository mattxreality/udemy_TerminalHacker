using System;
using UnityEngine;




public class Hacker : MonoBehaviour {

    // Game configuration data. Doesn't change
    const string fail = "Wrong! The sushi is spoiled! Try AGAIN!";
    public string[,] passwordArraylvl1 = new string[,] { { "arlybri", "library" }, { "enifmist", "feminist" }, { "agenv", "vegan" }, { "adornedot", "deodorant" } };
    public string[,] passwordArraylvl2 = new string[,] { { "stloipirgp", "pistolgrip" }, { "aimilncr", "criminal" }, { "odtun", "donut" }, { "ferritingnp", "fingerprint" }, { "chadsnuff", "handcuffs" } };
    public string[,] passwordArraylvl3 = new string[,] { { "lucod", "cloud" }, { "saw", "aws" }, { "erzau", "azure" } };

    //game state. Changes as game is played.
    int level;
    string lvl1Encrypt;
    string lvl1Answer;
    string lvl2Encrypt;
    string lvl2Answer;
    string lvl3Encrypt;
    string lvl3Answer;
    int lvl1Index;
    int lvl2Index;
    int lvl3Index;

    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    //Executes once at beginning
    void Start()
    {
        ShowMainMenu();
    }

    private void Update()
    {
        //lvl1Index = UnityEngine.Random.Range(0, passwordArraylvl1.GetLength(0));
        //print("lvl1Index = " + lvl1Index);
    }


    //this should only decide how to handle user input, not actually do it
    void OnUserInput(string input)
    {
        if (input == "menu")
        {

            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            Terminal.ClearScreen();
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            switch (level)
            {
                case 1:
                    Trylvl1(input);
                    break;
                case 2:
                    Trylvl2(input);
                    break;
                case 3:
                    Trylvl3(input);
                    break;
                default:
                    Debug.LogError("Invalid level number");
                    break;
            }
        }

    }

    void ShowMainMenu()
    {
        level = 0;
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome " + Environment.UserName + "!");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police department");
        Terminal.WriteLine("Press 3 for cloud services");
        Terminal.WriteLine("Enter your selection:");
    }

    void ReturnToMenu()
    {
        Terminal.WriteLine("Type 'Menu' to return to the main menu");
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input =="3");

        if (isValidLevelNumber)
        {
            level = int.Parse(input); //converts string into int
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please make a valid selection");
        }
    }

    void AskForPassword()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Password;
        
        switch (level)
        {
            case 1:
                lvl1Index = UnityEngine.Random.Range(0, passwordArraylvl1.GetLength(0));
                lvl1Encrypt = passwordArraylvl1[lvl1Index, 0];
                lvl1Answer = passwordArraylvl1[lvl1Index, 1];
                Terminal.WriteLine("Encrypted password = " + lvl1Encrypt);
                Terminal.WriteLine("Hack the password.");
                break;
            case 2:
                lvl2Index = UnityEngine.Random.Range(0, passwordArraylvl2.GetLength(0));
                lvl2Encrypt = passwordArraylvl2[lvl2Index, 0];
                lvl2Answer = passwordArraylvl2[lvl2Index, 1];
                Terminal.WriteLine("Encrypted password = " + lvl2Encrypt);
                Terminal.WriteLine("Hack the password.");
                break;
            case 3:
                lvl3Index = UnityEngine.Random.Range(0, passwordArraylvl3.GetLength(0));
                lvl3Encrypt = passwordArraylvl3[lvl3Index, 0];
                lvl3Answer = passwordArraylvl3[lvl3Index, 1];
                Terminal.WriteLine(@"
::::::::::::::::::::::::::::
::::                   :::::
:::::   CLOUD SERVICE   ::::
::::       CONSOLE     :::::
:::::                   ::::
::::                   :::::
::::::::::::::::::::::::::::
");
                Terminal.WriteLine("Encrypted password = " + lvl3Encrypt);
                Terminal.WriteLine("Hack the password.");
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void Trylvl1(string input)
    {
        if (input == lvl1Answer)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

 void FailMessage()
    {
        Terminal.WriteLine(fail);
    }

    void Trylvl2(string input)
    {
        if (input == lvl2Answer)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine(fail);
            AskForPassword();
        }
    }
    void Trylvl3(string input)
    {
        if (input == lvl3Answer)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine(fail);
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        LevelReward();
        ReturnToMenu();
    }

    void LevelReward()
    {
       
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a rabbit!!");
                Terminal.WriteLine(@"
     \\
      \\_
      ( _\
      / \__
     / _/``
    {\  )_
");
                break;
            case 2:
                Terminal.WriteLine("Have a squirrell!!");
                Terminal.WriteLine(@"
     __  (\_ 
    (_ \ ( '> 
      ) \/_)=
      (_(_ )_
");
                break;
            case 3:
                Terminal.WriteLine("Have a Cloud Service!!");
                Terminal.WriteLine(@"
,--.:::::::::::::::::::::
    )::::::::::::::::::::
  _'-. _:::::::::::::::::
 (    ) ),--.::::::::::::
             )-._::::::::
_________________):::::::
:::::::::::::::::::::::::
");
                break;
        }
    }
}
