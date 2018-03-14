using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoTile2DGame {
    class Loader {

        private static Loader _instance;

        public static Loader instance() {
            if (_instance == null) {
                _instance = new Loader();
            }

            return _instance;
        }

        public ModContainer activeModContainer() {
            return null; //TEMP
            //return modController != null ? modController.activeContainer() : null;
        }

    }
}
