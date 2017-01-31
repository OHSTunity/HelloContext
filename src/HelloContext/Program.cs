using Starcounter;

namespace Colab.HelloContext {
    class Program {
        static void Main() {
            MainHandlers.Register();

            LauncherAPI.Register();
            OrganizerAPI.Register();

            Mapping.Register();
        }
    }
}
