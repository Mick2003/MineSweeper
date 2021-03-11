using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MineSweeper
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        struct CellStruct
        {
            public bool hasFlag;
            public bool hasBomb;
            public bool isUncoverd;
            public int neighboringBombs;
            public Rectangle position;
            public Texture2D texture;
        }

        const int BOARD_ZISE = 10;
        const int CELL_WIDTH = 48;
        CellStruct[,] cell = new CellStruct[BOARD_ZISE + 2, BOARD_ZISE + 2];
        Texture2D bombTexture, flagTexture, blankTexture;
        Texture2D[] numbers = new Texture2D[9];
        MouseState mouse, prevMouse;
        bool gameOver;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            IsMouseVisible = true;

            plantBombs();
            InitializeBoard();
            PlantBombs();
            CountNeighbors();
            gameOver = false;

            base.Initialize(); // OnderaanHouden! 
        }

        void CountNeighbors()
        {

        }

        void plantBombs()
        {
            Random rand = new Random();

            bool[] n = new bool[100];

            for (int i = 0; i < 90;  i++)
                n[i] = false;

            for (int i = 90; i < 100; i++)
                n[i] = true;

            for (int i = 0; i < 100; i++)
            {
                int pos = rand.Next(100);
                bool save = n[i];
                n[i] = n[pos];
                n[pos] = save;
            }

            for (int i = 0; i < 100; i++)
            {
                if (n[i])
                    Console.WriteLine("*");
                else
                    Console.WriteLine(".");
                if ((i + 1) % 10 == 0)
                    Console.WriteLine();

            }
            Console.ReadLine();
        }

        void PlantBombs()
        {

        }

        void InitializeBoard()
        {

        }


        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            for (int r = 1; r <= BOARD_ZISE; r++)
                for (int c = 1; c <= BOARD_ZISE; c++)
                    cell[r, c].texture = this.Content.Load<Texture2D>("blank");

            bombTexture = Content.Load<Texture2D>("bomb");
            flagTexture = Content.Load<Texture2D>("flag");
            blankTexture = Content.Load<Texture2D>("blank");
            numbers[0] = Content.Load<Texture2D>("zero");
            numbers[1] = Content.Load<Texture2D>("one");
            numbers[2] = Content.Load<Texture2D>("two");
            numbers[3] = Content.Load<Texture2D>("three");
            numbers[4] = Content.Load<Texture2D>("four");
            numbers[5] = Content.Load<Texture2D>("five");
            numbers[6] = Content.Load<Texture2D>("six");
            numbers[7] = Content.Load<Texture2D>("seven");
            numbers[8] = Content.Load<Texture2D>("eight");

        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            mouse = Mouse.GetState();
            int row, col;

            prevMouse = mouse;

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}
