using System.Drawing;

namespace WoWRetroLauncher
{
    internal class TextureManager
    {
        private static TextureManager _instance;
        private readonly Bitmap[] background;
        private readonly Bitmap[] btnPlay;
        private readonly Bitmap[] btnPlayFr;

        public TextureManager()
        {
            _instance = this;

            background = new Bitmap[1];
            btnPlay = new Bitmap[4];
            btnPlayFr = new Bitmap[4];
        }

        public void SetSkin()
        {
            background[0] = (Bitmap)Properties.Resources.ResourceManager.GetObject("default_background");
            btnPlay[0] = (Bitmap)Properties.Resources.ResourceManager.GetObject("vanilla_buttonPlay");
            btnPlay[1] = (Bitmap)Properties.Resources.ResourceManager.GetObject("vanilla_buttonPlayHover");
            btnPlay[2] = (Bitmap)Properties.Resources.ResourceManager.GetObject("vanilla_buttonPlayPress");
            btnPlay[3] = (Bitmap)Properties.Resources.ResourceManager.GetObject("vanilla_buttonPlayDisabled");
            btnPlayFr[0] = (Bitmap)Properties.Resources.ResourceManager.GetObject("vanilla_buttonPlayFr");
            btnPlayFr[1] = (Bitmap)Properties.Resources.ResourceManager.GetObject("vanilla_buttonPlayFrHover");
            btnPlayFr[2] = (Bitmap)Properties.Resources.ResourceManager.GetObject("vanilla_buttonPlayFrPress");
            btnPlayFr[3] = (Bitmap)Properties.Resources.ResourceManager.GetObject("vanilla_buttonPlayFrDisabled");
        }

        public Bitmap GetBackground(int i) { return background[i]; }
        public Bitmap GetPlayButtonTexture(int i) { return btnPlay[i]; }
        public Bitmap GetPlayFrButtonTexture(int i) { return btnPlayFr[i]; }
        public static TextureManager GetInstance() { return _instance; }
    }
}
