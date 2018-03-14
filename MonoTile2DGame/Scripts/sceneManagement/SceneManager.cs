using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoTile2DGame.sceneManagement {
    public class SceneManager {

        private Action<Scene> OnSceneLoadedCB;

        public void RegisterSceneLoadedCallback(Action<Scene> sceneLoadedCB) {
            if(sceneLoadedCB != null)
                OnSceneLoadedCB += sceneLoadedCB;
        }

        public void UnregisterSceneLoadedCallback(Action<Scene> sceneLoadedCB) {
            if (sceneLoadedCB != null)
                OnSceneLoadedCB -= sceneLoadedCB;
        }

        private Scene currentScene;

        public void Update() {
            if (currentScene != null)
                currentScene.Update();
        }

        public void Draw() {
            if (currentScene != null)
                currentScene.Draw();
        }

        public void SetScene(Scene scene) {
            if(scene != null) {
                //Unload the currently loaded scene
                currentScene.OnSceneUnloaded();
                //Set the current scene to the scene to load
                currentScene = scene;
                //Load the new current scene
                currentScene.OnSceneLoaded();
                //Run the callback for when a new scene is loaded
                OnSceneLoadedCB.Invoke(scene);
            }
        }

    }
}
