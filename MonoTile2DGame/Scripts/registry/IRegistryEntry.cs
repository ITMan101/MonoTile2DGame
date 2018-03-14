using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoTile2DGame.exceptions;

namespace MonoTile2DGame.registry {
    interface IRegistryEntry<V> {

        V setRegistryName(ResourceLocation name);

        ResourceLocation getRegistryName();

        V getRegistryType();

    }

    public class Impl<T> : IRegistryEntry<T> where T : IRegistryEntry<T> {

        private ResourceLocation registryName;

        public ResourceLocation getRegistryName() {
            return registryName != null ? registryName : null;
        }

        public T getRegistryType() {
            throw new NotImplementedException();
        }

        public T setRegistryName(ResourceLocation name) {
            if (getRegistryName() != null)
                throw new IllegalStateException("Attempted to set registry name with existing registry name! New: " + name + " Old: " + getRegistryName());
                
            int index = name.ToString().LastIndexOf(':');
            String oldPrefix = index == -1 ? "" : name.ToString().Substring(0, index).ToLower();
            name = index == -1 ? name : name.ToString().Substring(index + 1);
            ModContainer mc = Loader.instance().activeModContainer();
            String prefix = mc == null || (mc.GetType() == typeof(InjectedModContainer) && ((InjectedModContainer)mc).wrappedContainer == FMLContainer) ? "minecraft" : mc.getModId().ToLower();
            if (!oldPrefix.Equals(prefix) && oldPrefix.Length > 0) {
                //FMLLog.log.info("Potentially Dangerous alternative prefix `{}` for name `{}`, expected `{}`. This could be a intended override, but in most cases indicates a broken mod.", oldPrefix, name, prefix);
                prefix = oldPrefix;
            }
            registryName = new ResourceLocation(prefix, name.ToString());
            return this;
        }
    }
}
