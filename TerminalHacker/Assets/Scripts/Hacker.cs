using System;
using UnityEngine;




public class Hacker : MonoBehaviour {

    // Game configuration data. Doesn't change
    public string[,] passwordArraylvl1 = new string[,] { { "arlybri", "library" }, { "enifmist", "feminist" }, { "agenv", "vegan" }, { "adornedot", "deodorant" } };
    public string[,] passwordArraylvl2 = new string[,] { { "aimilncr", "criminal" }, { "odtun", "donut" }, { "ferritingnp", "fingerprint" }, { "chadsnuff", "handcuffs" } };

    int[] arrayOne = new int[] { 1, 2, 3, 4, 5, 6 };
    int[] arrayTwo;


    public string[] singleArray = new string[] {"farm", "tuckit", "spanky"};

    //game state. Changes as game is played.
    int level;
    string lvlGreeting;
    string lvl1Encrypt;
    string lvl1Answer;
    string lvl2Encrypt;
    string lvl2Answer;
    int lvl1Index;
    int lvl2Index;

    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    static string word = "20";
    int number = int.Parse(word);

    //Executes once at beginning
    void Start()
    {
        ShowMainMenu();
        print(number);
        print("passwordArraylvl1 dimension0 " + passwordArraylvl1.GetLength(0));
        print("passwordArraylvl1 dimension1 " + passwordArraylvl1.GetLength(1));
        print("singleArray Rank " + singleArray.Rank);
    }

    private void Update()
    {
        lvl1Index = UnityEngine.Random.Range(0, passwordArraylvl1.GetLength(0));
        print("lvl1Index = " + lvl1Index);
    }
    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        level = 0;
        currentScreen = Screen.MainMenu;
        Terminal.WriteLine("Welcome " + Environment.UserName + "!");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police department");
        Terminal.WriteLine("Type 'Menu' to return to the main menu");
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
            switch(level)
            {
                case 1:
                    Trylvl1(input);
                    break;
                case 2:
                    Trylvl2(input);
                    break;
                default:
                    Debug.LogError("Invalid level number");
                    break;
            }
            
            /*
            if (level == 1)
            {
                Trylvl1(input);
            }
            else if (level == 2)
            {
                Trylvl2(input);
            }
            */
        }
 
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input =="2");

        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please make a valid selection");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        lvl1Index = UnityEngine.Random.Range(0, passwordArraylvl1.GetLength(0));
        lvl2Index = UnityEngine.Random.Range(0, passwordArraylvl2.GetLength(0));

        switch (level)
        {
            case 1:
                lvl1Encrypt = passwordArraylvl1[lvl1Index, 0];
                lvl1Answer = passwordArraylvl1[lvl1Index, 1];
                Terminal.WriteLine("Encrypted password = " + lvl1Encrypt);
                Terminal.WriteLine("Hack the password.");
                break;
            case 2:
                lvl2Encrypt = passwordArraylvl2[lvl2Index, 0];
                lvl2Answer = passwordArraylvl2[lvl2Index, 1];
                Terminal.WriteLine("Encrypted password = " + lvl2Encrypt);
                Terminal.WriteLine("Hack the password.");
                break;
            default:
                break;
        }
        /*
        if (level == 1)
        {
            lvl1Encrypt = passwordArraylvl1[randomNum, 0];
            lvl1Answer = passwordArraylvl1[randomNum, 1];
            Terminal.WriteLine("Encrypted password = " + lvl1Encrypt);
            Terminal.WriteLine("Hack the password.");
        }
        else if (level == 2)
        {
            lvl2Encrypt = passwordArraylvl2[randomNum, 0];
            lvl2Answer = passwordArraylvl2[randomNum, 1];
            Terminal.WriteLine("Encrypted password = " + lvl2Encrypt);
            Terminal.WriteLine("Hack the password.");
        }
        */

    }

    void Trylvl1(string input)
    {
        if (input == lvl1Answer)
        {
            currentScreen = Screen.Win;
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Wrong! The sushi is spoiled! Try AGAIN!");
        }
    }

    private static void DisplayWinScreen()
    {
        Terminal.WriteLine("You Win!!");
    }

    void Trylvl2(string input)
    {
        if (input == lvl2Answer)
        {
            currentScreen = Screen.Win;
            Terminal.WriteLine("You Win!!");
        }
        else
        {
            Terminal.WriteLine("Wrong! The sushi is spoiled! Try AGAIN!");
        }
    }
}
