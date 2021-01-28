class Tile//represents a type of tile
    {
        public bool blockPath;
        public Rectangle rect;

        public Tile(Rectangle rec, bool blockpath)
        {
            rect = rec;
            blockPath = blockpath;
        }
    }
