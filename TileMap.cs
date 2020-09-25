class TileMap
    {
        public int[,] grid;
        private int size;
        private int cellWidth;
        private int cellHeight;
        private Tile[] tileTypes;
        Random rnd = new Random();

        public TileMap(int sz, int ch, int cw)
        {
            size = sz;
            cellHeight = ch;
            cellWidth = cw;
            grid = new int[size,size];

            //Differents types de tile
            tileTypes = new Tile[3];
            tileTypes[0]= new Tile(new Rectangle(157,53,12,12), false);//black
            tileTypes[1]= new Tile(new Rectangle(170,105,12,12), false);//grass
            tileTypes[2]= new Tile(new Rectangle(14,105,12,12), true);//planks

            //populates the grid with random values
            for (int i = 0; i <= size - 1; i++)
            {
                for (int j = 0; j <= size - 1; j++)
                {
                    grid[i, j] = rnd.Next(0, tileTypes.Length);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //draws the texture of the correspunding tile
                    Tile tile = tileTypes[grid[i, j]];
                    spriteBatch.Draw(RessourceLoader.Images["spriteset"], new Rectangle(i*12,j*12,12,12), tile.rect, Color.White);
                    spriteBatch.DrawString(RessourceLoader.Fonts["basic"], tile.blockPath.ToString(), new Vector2(i*12, j*12), Color.White);
                }
            }
        }
    }
