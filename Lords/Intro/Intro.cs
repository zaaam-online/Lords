using Lord;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Lords.Intro
{
    class Intro
    {
        
        private string _introPicture = @"Intro/INTRO";
        private string _L_letter = @"Intro/L";
        private string _o_letter = @"Intro/opng";
        private string _r_letter = @"Intro/r";
        private string _d_letter = @"Intro/d";
        private string _s_letter = @"Intro/s";
        private int i = 0;
        private int Break = 50;
        float scale = .5f;

        private int _tagabsolutex = 100;
        private int _tagabsolutey = 200;

        private Texture2D _INTRO_TXT = null;
        private Texture2D _L_TXT = null;
        private Texture2D _o_TXT = null;
        private Texture2D _r_TXT = null;
        private Texture2D _d_TXT = null;
        private Texture2D _s_TXT = null;

        private bool _showintro = true;

        public Intro(ContentManager contentmanager)
        {
            _INTRO_TXT = contentmanager.Load<Texture2D>(_introPicture);
            _L_TXT = contentmanager.Load<Texture2D>(_L_letter);
            _o_TXT = contentmanager.Load<Texture2D>(_o_letter);
            _r_TXT = contentmanager.Load<Texture2D>(_r_letter);
            _d_TXT = contentmanager.Load<Texture2D>(_d_letter);
            _s_TXT = contentmanager.Load<Texture2D>(_s_letter);
        }

        public bool Showintro { get => _showintro; set => _showintro = value; }

        public void DrawIntro(SpriteBatch batch)
        {
           
            Rectangle tangle = Rectangle.Empty;
            int introwidth = _INTRO_TXT.Width;
            int introheight = _INTRO_TXT.Height;
            float scale1 = Convert.ToSingle(CONSTANTS.WINDOWWIDTH) / Convert.ToSingle(introheight);

            int newwidth = Convert.ToInt32(_INTRO_TXT.Width * scale1);
            int newheight= Convert.ToInt32(_INTRO_TXT.Height * scale1);

            int freespaceleft = (CONSTANTS.WINDOWWIDTH - newwidth) / 2;
            int freespaceup = (CONSTANTS.WINDOWHEIGHT - newheight) / 2;

            batch.Draw(_INTRO_TXT, new Vector2(0, 0), null, Color.White,0, new Vector2(-freespaceleft, -freespaceup), scale1, SpriteEffects.None,0);
            if (i > Break)
            {
                //batch.Draw(_L_TXT, new Vector2(50+ _tagabsolutex, 50+ _tagabsolutey), Color.White);
                batch.Draw(_L_TXT, new Vector2(50 + _tagabsolutex, 50 + _tagabsolutey), null, Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 0);
                if(scale<1f)
                scale = scale + .01f;
            }
            if (i > 2*Break)
                batch.Draw(_o_TXT, new Vector2(250+ _tagabsolutex, 180+ _tagabsolutey), Color.White);
            if (i > 3 * Break)
                batch.Draw(_r_TXT, new Vector2(310+ _tagabsolutex, 178+ _tagabsolutey), Color.White);
            if (i > 4 * Break)
                batch.Draw(_d_TXT, new Vector2(355+ _tagabsolutex, 160+ _tagabsolutey), Color.White);
            if (i > 5 * Break)
                batch.Draw(_s_TXT, new Vector2(425+ _tagabsolutex, 175+ _tagabsolutey), Color.White);
            if (i > 8 * Break)
                this._showintro = false;

            i++;
            
        }
    }
}