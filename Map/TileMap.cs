[Serializable()]
    public class TileMap
    {
        public int[][] grid;
        public int size;
        public int cellSize;
        public Tile[] tileTypes;
        Random rnd = new Random();
        public TileMap()
        {
            size = 50;
            cellSize = 12;
            grid = new int[50][];

            //Different tile types  TONE LIST ACCESSIBLE FOR EVERY tileMap INSTANCES
            //TODO: find a way to get 1 value from everywhere over the game
            //automate tile creation OR find a way to just store rectangle pos values since only those are changing
            tileTypes = new Tile[11];
            tileTypes[ 0] = new Tile(new Rectangle(157,  53, cellSize, cellSize), false);//black
            tileTypes[ 1] = new Tile(new Rectangle(170, 105, cellSize, cellSize), false);//grass
            tileTypes[ 2] = new Tile(new Rectangle( 14, 105, cellSize, cellSize), false);//planks
            tileTypes[ 3] = new Tile(new Rectangle(118, 105, cellSize, cellSize), false);//blue tiles
            tileTypes[ 4] = new Tile(new Rectangle(144, 105, cellSize, cellSize), false);//grey tiles
            tileTypes[ 5] = new Tile(new Rectangle( 53, 118, cellSize, cellSize), true);//brick wall
            tileTypes[ 6] = new Tile(new Rectangle(157, 118, cellSize, cellSize), true);//tree 1
            tileTypes[ 7] = new Tile(new Rectangle(170, 118, cellSize, cellSize), true);//tree 2
            tileTypes[ 8] = new Tile(new Rectangle(183, 118, cellSize, cellSize), true);//trash
            tileTypes[ 9] = new Tile(new Rectangle(  1, 118, cellSize, cellSize), true);//grey bricks
            tileTypes[10] = new Tile(new Rectangle( 14, 118, cellSize, cellSize), true);//net fence

            //populates the grid with random values
            for (int i = 0; i <= size - 1; i++)
            {
                grid[i] = new int[size];//for each element of the table, create a new 50 int long table
                for (int j = 0; j <= size - 1; j++)
                {
                    grid[i][j] = rnd.Next(0, tileTypes.Length);
                    grid[0][j] = 5;
                    grid[i][0] = 5;
                    //if grid[i,j] == 12, new Door()... 
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //draws the texture of the corresponding tile
                    Tile tile = tileTypes[grid[i][j]];
                    spriteBatch.Draw(RessourceLoader.Images["spriteset"], new Rectangle(i* cellSize, j* cellSize, cellSize, cellSize), tile.rect, Color.White);
                }
            }
        }

        public void saveToXML(string fileName)
        {
            using(FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                var xml = new XmlSerializer(typeof(TileMap));
                xml.Serialize(stream, this);
            }
        }

        public TileMap loadFromXML(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                var xml = new XmlSerializer(typeof(TileMap));
                return (TileMap)xml.Deserialize(stream);
            }
        }
    }
