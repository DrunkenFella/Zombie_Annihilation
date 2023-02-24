using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(1000, 800, "Zombie Annihilation");
Raylib.SetTargetFPS(60);

//                                                  Textures
//Background
Texture2D backgroundStart = Raylib.LoadTexture("images/backgroundZombie.png");
Texture2D backgroundDeath = Raylib.LoadTexture("images/DeathScreen.png");
//Characters
Texture2D player = Raylib.LoadTexture("images/characterZombieGame.png");
Texture2D zombie = Raylib.LoadTexture("images/characterZombieGame.png");
Texture2D cat = Raylib.LoadTexture("images/cat_spritesheet.png");

//Props
Texture2D applePie = Raylib.LoadTexture("images/Food/06_apple_pie_dish.png");
Texture2D bacon = Raylib.LoadTexture("images/Food/14_bacon_dish.png");
Texture2D burger = Raylib.LoadTexture("images/Food/16_burger_dish.png");
Texture2D stake = Raylib.LoadTexture("images/Food/96_stake_dish.png");

//                                                     Values
string currentScene = "start"; //Start, game, end
float speed = 1f;
int playerHealth = 50;

//animation 
float frameWidthCat = (float)(cat.width / 15);
int MaxFramesCat = ((int)cat.width / (int)frameWidthCat);
float timer = 0.0f;
int frameCat = 0;



//                                                   Recs
Rectangle catRect = new Rectangle(0, 0, frameWidthCat, (float)cat.height);
Rectangle playerRect = new Rectangle(0, 0, player.width, player.height);

while (Raylib.WindowShouldClose() == false)
{

    // Logic 
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

        if (playerHealth <= 0)
        {
            currentScene = "end";
        }

    }
    else if (currentScene == "start")
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
        {
            currentScene = "game";
        }
    }

    // Grafik
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);

    if (currentScene == "game")
    {

    }
    else if (currentScene == "start")
    {
        Raylib.DrawTexture(backgroundStart,
            0,
            0,
            Color.WHITE);
        Raylib.DrawText("Press [ENTER] to start", 500, 600, 40, Color.BLACK);

        //animation 
        timer += Raylib.GetFrameTime();

        if (timer >= 0.2f)
        {
            timer = 0.0f;
            frameCat += 1;
        }

        frameCat = frameCat & MaxFramesCat;
        Raylib.DrawTextureRec(
            cat,
            new Rectangle(frameWidthCat * frameCat, 0, frameWidthCat, (float)cat.height),
            new Vector2(500, 500),
            Color.WHITE);


    }
    else if (currentScene == "end")
    {
        Raylib.DrawTexture(backgroundDeath, 0, 0, Color.WHITE);
        Raylib.DrawText("Game over", 10, 10, 64, Color.RED);
    }

    Raylib.EndDrawing();
}