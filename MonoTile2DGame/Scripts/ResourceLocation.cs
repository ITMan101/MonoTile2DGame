using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoTile2DGame {
    class ResourceLocation {

        protected string resourceDomain;
        protected string resourcePath;

        protected ResourceLocation(int unused, params string[] resourceName) {
            resourceDomain = String.IsNullOrEmpty(resourceName[0]) ? "minecraft" : resourceName[0].ToLower();
            resourcePath = resourceName[1];
            //Validate.notNull(this.resourcePath); //Not sure what to do with this line 
        }

        public ResourceLocation(String resourceName) : this(0, splitObjectName(resourceName)) { }

        public ResourceLocation(String resourceDomainIn, String resourcePathIn) : this(0, new string[] { resourceDomainIn, resourcePathIn }) { }

        /**
         * Splits an object name (such as minecraft:apple) into the domain and path parts and returns these as an array of
         * length 2. If no colon is present in the passed value the returned array will contain {null, toSplit}.
         */
        protected static String[] splitObjectName(String toSplit) {
            String[] astring = new String[] { "minecraft", toSplit };
            int i = toSplit.IndexOf(':');

            if (i >= 0) {
                astring[1] = toSplit.Substring(i + 1, toSplit.Length);

                if (i > 1) {
                    astring[0] = toSplit.Substring(0, i);
                }
            }

            return astring;
        }

        public String getResourcePath() {
            return resourcePath;
        }

        public String getResourceDomain() {
            return resourceDomain;
        }

        public override string ToString() {
            return resourceDomain + ':' + resourcePath;
        }

        public override bool Equals(Object obj_equals) {
            if (this == obj_equals) {
                return true;
            } else if (!(obj_equals.GetType() == typeof(ResourceLocation))) {
                return false;
            } else {
                ResourceLocation resourcelocation = (ResourceLocation)obj_equals;
                return resourceDomain.Equals(resourcelocation.resourceDomain) && resourcePath.Equals(resourcelocation.resourcePath);
            }
        }

        public override int GetHashCode() {
            return 31 * resourceDomain.GetHashCode() + resourcePath.GetHashCode();
        }

        public static implicit operator ResourceLocation(string location) {
            return new ResourceLocation(location);
        }

    }
}
