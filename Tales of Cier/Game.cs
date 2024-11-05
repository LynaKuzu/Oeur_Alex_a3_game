// Include code libraries you need below (use the namespace).
using System;
using System.Drawing;
using System.Numerics;
using System.Security.Cryptography;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:

        
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            //Window setup
            Window.SetTitle("Tales of Cier");
            Window.SetSize(1280, 640);
            Window.TargetFPS = 30;
        }
        /// <summary>
        ///     Update runs every frame.
        /// </summary>


        ///Setting up variables and game objects
        Player P1 = new Player(100, 320, 20, 0);
        Enemy E1 = new Enemy(20, 800, 320);
        int numScreen = 0;
        TimedAttack RedHit = new TimedAttack(5, 0,60);
        int turnCombat = 1;
        public void Update()
        {
            //BG art

            //movement controls for P1
            if (numScreen == 0)
            {
                if (Input.IsKeyboardKeyDown(KeyboardInput.D))
                {
                    P1.MovePlrPos(10, 0);
                }
                if (Input.IsKeyboardKeyDown(KeyboardInput.A))
                {
                    P1.MovePlrPos(-10, 0);
                }
                if (Input.IsKeyboardKeyDown(KeyboardInput.S))
                {
                    if (P1.getY() + 50 < 450)
                    {
                        P1.MovePlrPos(0, 10);
                    }
                }
                if (Input.IsKeyboardKeyDown(KeyboardInput.W))
                {
                    if (P1.getY() > 200)
                    {
                        P1.MovePlrPos(0, -10);
                    }
                }
            }
            else
            {
                //in combat controls
                P1.SetPlrPos(400, 320);
                //turn setting
                if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
                {
                    if (turnCombat == 1)
                    {
                        turnCombat = 2;
                    }
                    else
                    {
                        turnCombat = 1;
                        
                    }
                }
            }
            //changing to battle mode when you walk far enough
            if(P1.getX() > 600)
            {
                numScreen = 1;
            }
            
            //checking if you are in battle or not
            //changing bg depending on the result
            if (numScreen == 0)
            {
                Window.ClearBackground(new(0, 0, 40));
                Draw.FillColor = Color.Black;
                Draw.Rectangle(0, 0,1280,200);
                Draw.Rectangle(0, 450, 1280, 200);
            }
            else
            {
                Window.ClearBackground(new(75, 75, 75));
                Text.Draw($"BATTLE START", 530,200);
                //Drawing enemy sprite
                E1.Blit();

                //dodge indicator
                if (RedHit.getTime() > -12 & turnCombat == 2)
                {
                    RedHit.Tick(2);
                    Draw.FillColor = Color.White;
                    Draw.Circle(640, 500, 50);
                    Draw.FillColor = Color.Red;
                    Draw.Circle(640, 500 - RedHit.getTime() * 5, 50);
                }
                else
                {
                    if (RedHit.getTime() < 10 & RedHit.getTime() > -10)
                    {
                        E1.HpSub(1);
                        P1.MovePlrPos(10, 0);
                    }
                    else
                    {
                        P1.HpSub(1);
                        P1.MovePlrPos(-10, 0);
                    }
                    RedHit.LoadAtk();
                    turnCombat = 2;
                }
            }
            //draw player sprite
            P1.Blit();
            
        }
    }
}
