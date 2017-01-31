using System;
using Starcounter;

namespace Colab.HelloContext {
    internal static class Mapping {
        public static void Register() {
            //Colab Launcher API
            UriMapping.Map("/colab_hellocontext/app-name", UriMapping.MappingUriPrefix + "/app-name");
            UriMapping.Map("/colab_hellocontext/menu", UriMapping.MappingUriPrefix + "/menu");
            // UriMapping.Map("/colab_hellocontext/search/@w", UriMapping.MappingUriPrefix + "/search?query=@w");
            // UriMapping.Map("/colab_hellocontext/dashboard", UriMapping.MappingUriPrefix + "/dashboard");

        
        }
    }
}
