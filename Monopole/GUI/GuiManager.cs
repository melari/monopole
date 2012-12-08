using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Atomic
{
    public class GuiManager : Dictionary<string, InputField>
    {
        public InputField focus { get; private set; }

		public void Add(InputField field)
		{
			string _key = "0";
			while (ContainsKey(_key))
				MathExtra.random.Next().ToString();
			Add(_key, field);
		}

        public void Update()
        {
            foreach (InputField field in this.Values)
            {
                if (field.enabled && Input.MLBPressed() && Input.mouse.X >= field.position.X && Input.mouse.Y >= field.position.Y && Input.mouse.X <= (field.position + field.size).X && Input.mouse.Y <= (field.position + field.size).Y)
                {
                    if (focus != null)
                        focus.focused = false;
                    field.focused = true;
                    focus = field;
                }
                field.Update();
            }

            if (Input.KeyPressed(Microsoft.Xna.Framework.Input.Keys.Tab) && focus != null && focus.tab != null)
            {
                focus.focused = false;
                focus.tab.focused = true;
                focus = focus.tab;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (InputField field in this.Values)
                field.Draw(spriteBatch);
        }
    }
}
