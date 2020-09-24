abstract class Interface
    {
        public Vector2 position;
        public Vector2 size;
        private Texture2D texture;
        private bool isActive;

        public Interface(Vector2 pos, Vector2 sz)
        {
            position = pos;
            size = sz;
            isActive = false;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            int posX = (int)position.X;
            int posY = (int)position.Y;
            //Angles
            spriteBatch.Draw(RessourceLoader.Images["menuAtlas"], new Rectangle(posX, posY, 12, 12), new Rectangle(0, 0, 12, 12), Color.White);
            spriteBatch.Draw(RessourceLoader.Images["menuAtlas"], new Rectangle(posX + ((int)size.X * 12), posY, 12, 12), new Rectangle(24, 0, 12, 12), Color.White);
            spriteBatch.Draw(RessourceLoader.Images["menuAtlas"], new Rectangle(posX, posY + ((int)size.Y * 12), 12, 12), new Rectangle(0, 24, 12, 12), Color.White);
            spriteBatch.Draw(RessourceLoader.Images["menuAtlas"], new Rectangle(posX + ((int)size.X * 12), posY + ((int)size.Y * 12), 12, 12), new Rectangle(24, 24, 12, 12), Color.White);
            
            //Horitontal Sides
            for (int i = 1; i < size.X; i++)
            {
                spriteBatch.Draw(RessourceLoader.Images["menuAtlas"], new Rectangle(posX + i*12, posY, 12, 12), new Rectangle(12, 0, 12, 12), Color.White);
                spriteBatch.Draw(RessourceLoader.Images["menuAtlas"], new Rectangle(posX + i*12, posY + (int)size.Y * 12, 12, 12), new Rectangle(12, 24, 12, 12), Color.White);
            }

            //Vertical Sides
            for (int i = 1; i < size.Y; i++)
            {
                spriteBatch.Draw(RessourceLoader.Images["menuAtlas"], new Rectangle(posX, posY + i * 12, 12, 12), new Rectangle(0, 12, 12, 12), Color.White);
                spriteBatch.Draw(RessourceLoader.Images["menuAtlas"], new Rectangle(posX + (int)size.X * 12, posY + i * 12, 12, 12), new Rectangle(24, 12, 12, 12), Color.White);
            }

            //Background Tiles
            for(int i = 1; i < size.X; i++)
            {
                for (int j = 1; j < size.Y; j++)
                {
                    spriteBatch.Draw(RessourceLoader.Images["menuAtlas"], new Rectangle(posX + i * 12, posY + j * 12, 12, 12), new Rectangle(12, 12, 12, 12), Color.White);
                }
            }

            //Title
            spriteBatch.DrawString(RessourceLoader.Fonts["basic"], "Window", new Vector2(posX+10, posY+10) , Color.White);
        }
    }
