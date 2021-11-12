using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace pacman
{
    class Bar
    {

        public Vector2 Position { get; }
        public int Length;
        public int Width;

        public Bar(Vector2 position, int width, int length)
        {
            this.Position = position;
            this.Length = length;
            this.Width = width;
        }
    }
}
