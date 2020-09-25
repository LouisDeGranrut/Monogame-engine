class moveAction : Action
    {
        private int Xdirection;
        private int Ydirection;
        private TileMap currentMap;

        public moveAction(Actor act, int xd, int yd, TileMap map) : base(act)
        {
            Xdirection = xd;
            Ydirection = yd;
            actor = act;
            currentMap = map;//required to know what tile is the actor on
        }

        public override void perform()
        {
            int tileID = currentMap.grid[(int)actor.pos.X/12 + Xdirection, (int)actor.pos.Y/12 + Ydirection];
            if (!currentMap.tileTypes[tileID].blockPath) {//if the tile the actor is trying to go to doesn't block the path, move
            actor.pos = new Vector2(actor.pos.X + Xdirection * 12, actor.pos.Y + Ydirection * 12);
            }
            //System.Diagnostics.Debug.WriteLine(actor.pos.X+" "+actor.pos.Y);//big lag if I do that
        }
    }
