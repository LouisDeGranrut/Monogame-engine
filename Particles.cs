class Particles
    {

        public Texture2D texture;
        public Vector2 position { get; set; }        // The current position of the particle        
        public Vector2 velocity { get; set; }        // The speed of the particle at the current instance
        public float angle { get; set; }            // The current angle of rotation of the particle
        public float angularVelocity { get; set; }    // The speed that the angle is changing
        public Color color { get; set; }            // The color of the particle
        public float size { get; set; }                // The size of the particle
        public int TTL { get; set; }                // The 'time to live' of the particle

        public Particle(Texture2D tex, Vector2 pos, Vector2 vel,
            float a, float aVelocity, Color col, float sz, int ttl)
        {
            texture = tex;
            position = pos;
            velocity = vel;
            angle = a;
            angularVelocity = aVelocity;
            color = col;
            size = sz;
            TTL = ttl;
        }

        public void Update()
        {
            TTL--;
            position += velocity;
            angle += angularVelocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            Vector2 origin = new Vector2(texture.Width / 2, texture.Height / 2);

            spriteBatch.Draw(texture, position, sourceRectangle, color,
                angle, origin, size, SpriteEffects.None, 0f);
        }

    }
