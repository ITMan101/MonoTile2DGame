using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoTile2DGame.sceneManagement {
    public abstract class Scene {

        public void OnSceneLoaded() { }
        public void OnSceneUnloaded() { }

        public void Update() { }
        public void Draw() { }

    }
}
