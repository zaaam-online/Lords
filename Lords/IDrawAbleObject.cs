using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Lord
{
    public interface IDrawAbleObject
    {

        void InitTextures(ContentManager content);

        void Draw(SpriteBatch batch, GameStatus status);
    }
}
