using System;
using Raylib_cs;
using System.Numerics;

public class Zombie
{
    public Texture2D spriteSheet;
    public Texture2D deathSpriteSheet;

    public int health = 100;

    public Rectangle rect;
    Rectangle sourceRect;

    public Zombie()
    {
        spriteSheet = Raylib.LoadTexture("images/Zombie.png");
        deathSpriteSheet = Raylib.LoadTexture("images/ZombieDeath.png");

        rect = new Rectangle(0, 0, 128, 128);

        sourceRect = new Rectangle(0, 0, 32, 32);
    }

    public void Draw()
    {
        Raylib.DrawTexturePro(spriteSheet, sourceRect, rect, Vector2.Zero, 0, Color.WHITE);
    }

}

