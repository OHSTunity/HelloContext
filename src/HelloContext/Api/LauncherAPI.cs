using System;
using Starcounter;
using Simplified.Ring1;
using Simplified.Ring2;
using Colab.Public;

namespace Colab.HelloContext {
    /// <summary>
    /// Registers uri:s ready to be mapped into Colab Launcher suchs as menu e.t.c.
    /// </summary>
    internal static class LauncherAPI {
        public static void Register()
        {
            //[Optional] LaunchPad
            Handle.GET("/colab_hellocontext/app-name", () =>
            {
                dynamic json = new Json();
                json.name = "Colab Hello Context";
                json.url = "/colab_hellocontext";
                json.html = "/co-hellocontext/app-icon.html";
                json.description = "Hellocontext by Colab";
                return json;
            });


            //[Optional] Main menu
            Handle.GET("/colab_hellocontext/menu", () =>
            {
                Page p = new Page()
                {
                    Html = "/co-hellocontext/app-menu.html"
                };
                return p;
            });

            //Not optional, register utils that is persistant loaded into launcher
            // Allows for morph uri, add modals and so on
            Handle.GET("/colab_hellocontext/utils", () =>
            {
                Master m = (Master)Self.GET(String.Format("/hellocontext/master"));
                return m.Utils;
            });

            

            //Search in topbar
            Handle.GET("/colab_hellocontext/search/{?}", (string query) =>
            {
                //TODO: Remember to check if user is logged in and only return results
                //he/she is allowed to see

                var sq = new SearchQuery(query);
                if (!String.IsNullOrEmpty(sq.Type) && sq.Type != "t" && sq.Type != "o")
                    return null;

                var st = new SearchType()
                {
                    Type = "HelloContext",
                };
                SearchProvider provider = new SearchProvider();
                st.Count = provider.Count(sq);
                if (st.Count == 0)
                    return null;
                var counter = 0;
                int fetch = (sq.Type == "t" || sq.Type == "o") ? 10 : 5;

                foreach (var item in provider.SelectHellos(sq))
                {
                    st.Items.Add(new HelloContextSearchResult() { Data = item });
                        counter++;
                    if (counter >= fetch)
                        break;
                }
                return new SearchResult() { Types = { st } };
            });
            
            
        }
    }
}
