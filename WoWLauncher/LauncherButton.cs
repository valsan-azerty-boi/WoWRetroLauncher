using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WoWRetroLauncher
{
    internal class LauncherButton : Button
    {
        private bool _hovered = false;
        public enum ButtonType
        {
            Play,
            PlayFr
        }

        [Description("Type of Launcher button"), Category("Data")]
        public ButtonType Type { get; set; }

        public LauncherButton()
        {
            this.MouseEnter += new EventHandler(OnHover);
            this.MouseLeave += new EventHandler(OnUnhover);
            this.MouseDown += new MouseEventHandler(OnPress);
            this.MouseUp += new MouseEventHandler(OnRelease);

            if(TextureManager.GetInstance() != null)
                OnRelease(null, null);
        }

        public void OnHover(object sender, EventArgs e)
        {
            _hovered = true;
            if (Type == ButtonType.Play)
                BackgroundImage = (Bitmap)TextureManager.GetInstance().GetPlayButtonTexture(1);
            else if (Type == ButtonType.PlayFr)
                BackgroundImage = (Bitmap)TextureManager.GetInstance().GetPlayFrButtonTexture(1);
        }

        public void OnUnhover(object sender, EventArgs e)
        {
            _hovered = false;
            if (Type == ButtonType.Play)
                BackgroundImage = (Bitmap)TextureManager.GetInstance().GetPlayButtonTexture(0);
            else if (Type == ButtonType.PlayFr)
                BackgroundImage = (Bitmap)TextureManager.GetInstance().GetPlayFrButtonTexture(0);
        }

        private void OnPress(object sender, EventArgs e)
        {
            if (Type == ButtonType.Play)
                BackgroundImage = (Bitmap)TextureManager.GetInstance().GetPlayButtonTexture(2);
            else if (Type == ButtonType.PlayFr)
                BackgroundImage = (Bitmap)TextureManager.GetInstance().GetPlayFrButtonTexture(2);
        }

        public void OnRelease(object sender, EventArgs e)
        {
            if(!_hovered)
            {
                if (Type == ButtonType.Play)
                    BackgroundImage = (Bitmap)TextureManager.GetInstance().GetPlayButtonTexture(0);
                else if (Type == ButtonType.PlayFr)
                    BackgroundImage = (Bitmap)TextureManager.GetInstance().GetPlayFrButtonTexture(0);
            } 
            else
            {
                if (Type == ButtonType.Play)
                    BackgroundImage = (Bitmap)TextureManager.GetInstance().GetPlayButtonTexture(1);
                else if (Type == ButtonType.PlayFr)
                    BackgroundImage = (Bitmap)TextureManager.GetInstance().GetPlayFrButtonTexture(1);
            }
        }
    }
}
