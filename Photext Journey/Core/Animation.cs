using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Photext_Journey.Core
{
    class Animation
    {
        private Texture2D sheet;
        private int rows;
        private int columns;
        private int currentFrame;
        private int totalFrames;

        private float elapsed;
        private int updateTime;

        private Rectangle source, destination;
        private int width, height, currentRow, currentColumn;

        public Animation(Texture2D sheet, int rows, int columns, int updateTime)
        {
            this.sheet = sheet;
            this.rows = rows;
            this.columns = columns;
            this.currentFrame = 0;
            this.totalFrames = this.rows * this.columns;

            this.updateTime = updateTime;
            this.elapsed = 0;
        }

        public void Update(GameTime gameTime)
        {
            this.elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (this.elapsed > this.updateTime)
            {
                this.elapsed = 0;
                this.currentFrame++;
            }

            if (this.currentFrame == this.totalFrames)
                this.currentFrame = 0;
        }

        public void Draw(SpriteBatch sb, Vector2 pos)
        {
            this.width = this.sheet.Width / this.columns;
            this.height = this.sheet.Height / this.rows;

            this.currentRow = (int)((float)this.currentFrame / (float)this.columns);
            this.currentColumn = this.currentFrame % this.columns;

            this.source = new Rectangle(width * currentColumn, height * currentRow, width, height);
            this.destination = new Rectangle((int)pos.X, (int)pos.Y, width, height);

            sb.Draw(this.sheet, this.destination, this.source, Color.White);
        }
    }
}
