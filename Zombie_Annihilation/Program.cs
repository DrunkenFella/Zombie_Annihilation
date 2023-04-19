using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(1000, 800, "Zombie Annihilation");
Raylib.SetTargetFPS(60);

//classes
Zombie z = new Zombie();

List<Zombie> zombies = new();
zombies.Add(new Zombie());


//Music
Raylib.InitAudioDevice();


//                                                  Textures
//Background
Texture2D backgroundStart = Raylib.LoadTexture("images/backgroundZombie.png");
Texture2D backgroundDeath = Raylib.LoadTexture("images/DeathScreen.png");
Texture2D backgroundDeath2 = Raylib.LoadTexture("images/ryan69.png");
Texture2D backgroundGame = Raylib.LoadTexture("images/GameBackground.png");
Texture2D backgroundShop = Raylib.LoadTexture("images/backgroundShop.png");


//Characters
//Player
Texture2D player = Raylib.LoadTexture("images/Player/Idle.png");
Texture2D playerRun = Raylib.LoadTexture("images/Player/Run.png");
Texture2D playerAttack1 = Raylib.LoadTexture("images/Player/Attack1.png");
Texture2D playerAttack2 = Raylib.LoadTexture("images/Player/Attack2.png");
Texture2D playerTakeHit = Raylib.LoadTexture("images/Player/Take Hit.png");
Texture2D playerDeath = Raylib.LoadTexture("images/Player/Death.png");


//Props
Texture2D applePie = Raylib.LoadTexture("images/Food/06_apple_pie_dish.png");
Texture2D bacon = Raylib.LoadTexture("images/Food/14_bacon_dish.png");
Texture2D burger = Raylib.LoadTexture("images/Food/16_burger_dish.png");
Texture2D steak = Raylib.LoadTexture("images/Food/96_stake_dish.png");
Texture2D Sword = Raylib.LoadTexture("images/Sword.png");


//Rects

//                                              cat 
Texture2D cat = Raylib.LoadTexture("images/cat_spritesheet.png");

//                                                     Values
string currentScene = "start"; //Start, game, shop, end
float speed = 3f;
int playerHealth = 100;
int playerHealthMax = 100;
int round = 1;


//timer 
float timerGame = 60;

Random generator = new Random();
int x = generator.Next(1, 600);
int y = generator.Next(1, 600);



//                                                   Recs
Rectangle playerRect = new Rectangle(0, 0, player.width, player.height);
Rectangle trapRect = new Rectangle(550, 500, 64, 64);

while (Raylib.WindowShouldClose() == false)
{
    // Logic 
    Control(ref currentScene, speed, playerHealth, ref timerGame, ref playerRect);

    // Grafik
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);

    if (currentScene == "game")
    {
        Raylib.DrawTexture(backgroundGame,
        0,
        0,
        Color.WHITE);

        Raylib.DrawTexture(player,
          (int)playerRect.x,
          (int)playerRect.y,
          Color.WHITE);

        if (timerGame >= 0)
        {
            timerGame -= Raylib.GetFrameTime();
            Raylib.DrawText($"{(int)timerGame}", 80, 50, 40, Color.WHITE);
            Raylib.DrawText($"Round {round}", 80, 600, 40, Color.WHITE);
            Raylib.DrawText($"Player health = {playerHealth}", 600, 50, 40, Color.WHITE);
            foreach (Zombie zombie in zombies)
            {
                zombie.health = 50 + 2 * round;
            }


        }
        else if (timerGame <= 0)
        {
            currentScene = "shop";
            round++;
        }

    }
    else if (currentScene == "start")
    {
        Raylib.DrawTexture(backgroundStart,
            0,
            0,
            Color.WHITE);
        Raylib.DrawText("Press [ENTER] to start", 500, 600, 40, Color.BLACK);

        Raylib.DrawText("Press [Q]", 40, 40, 40, Color.BLACK);
    }
    else if (currentScene == "shop")
    {
        Raylib.DrawTexture(backgroundShop,
       0,
       0,
       Color.WHITE);
        Raylib.DrawTexture(Sword, 0, 0, Color.WHITE);
        playerHealth = playerHealthMax;
        Raylib.DrawTexture(steak, 0, 0, Color.WHITE);

    }
    else if (currentScene == "end")
    {
        Raylib.DrawTexture(backgroundDeath, 0, 0, Color.WHITE);
        Raylib.DrawText("Game over", 10, 10, 64, Color.RED);
    }
    else if (currentScene == "end2")
    {
        Raylib.DrawTexture(backgroundDeath2, 0, 0, Color.WHITE);
        Raylib.DrawText("Game over", 10, 10, 64, Color.RED);
    }
    else if (currentScene == "Test")
    {
        Raylib.DrawTexture(backgroundShop, 0, 0, Color.WHITE);
        Raylib.DrawText("W to move upp", 50, 50, 64, Color.WHITE);
        Raylib.DrawText("S to move down,", 60, 150, 64, Color.WHITE);
        Raylib.DrawText("A to move left", 70, 250, 64, Color.WHITE);
        Raylib.DrawText("D to move right", 80, 350, 64, Color.WHITE);
        Raylib.DrawText("K to hit Zombies", 90, 500, 64, Color.WHITE);
    }

    Raylib.EndDrawing();
}

static void Control(ref string currentScene, float speed, int playerHealth, ref float timerGame, ref Rectangle playerRect)
{
    if (currentScene == "game")
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            playerRect.x += speed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            playerRect.x -= speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
        {
            playerRect.y -= speed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
        {
            playerRect.y += speed;
        }
        //  && Raylib.CheckCollisionPointRec(playerRect, zombieRect)
        if (Raylib.IsKeyDown(KeyboardKey.KEY_K))
        {

        }

        if (playerHealth <= 0 && timerGame >= 30)
        {
            currentScene = "end";
        }
        else if (playerHealth <= 0)
        {
            currentScene = "end2";
        }


    }
    else if (currentScene == "start")
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
        {
            currentScene = "game";
        }
    }

    if (currentScene == "start")
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_Q))
        {
            currentScene = "Test";
        }
    }
    else if (currentScene == "end" || currentScene == "end2")
    {
        if (Raylib.IsKeyReleased(KeyboardKey.KEY_R))
        {
            currentScene = "start";
        }
    }
}