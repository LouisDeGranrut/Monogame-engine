    static class RessourceLoader
    {
        public static Dictionary<string, Texture2D> Images;
        public static Dictionary<string, SoundEffect> Sounds;
        public static Dictionary<string, SpriteFont> Fonts;

        public static void LoadImages(ContentManager content)
        {
            Images = new Dictionary<string, Texture2D>();

            List<string> imagesName = new List<string>()
            {
                "spriteset"
            };

            foreach (string img in imagesName)
            {
                Images.Add(img, content.Load<Texture2D>(img));
            }
        }

        public static void LoadAudio(ContentManager content)
        {
            Sounds = new Dictionary<string, SoundEffect>();

            List<string> fileName = new List<string>()
            {
            };

            foreach (string file in fileName)
            {
                Sounds.Add(file, content.Load<SoundEffect>(file));
            }

        }

        public static void LoadFont(ContentManager content)
        {
            Fonts = new Dictionary<string, SpriteFont>();

            List<string> fileName = new List<string>()
            {
                "basic"
            };

            foreach (string file in fileName)
            {
                Fonts.Add(file, content.Load<SpriteFont>(file));
            }
        }
    }
