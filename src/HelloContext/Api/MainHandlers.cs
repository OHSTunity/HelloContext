using System;
using Starcounter;
using Simplified.Ring1;
using Simplified.Ring2;
using Colab.Public;

namespace Colab.HelloContext {
    internal static class MainHandlers {
        /// <summary>
        /// To be a full SC app you need to implement standalone functionality as well
        /// That is NOT done here, this app will only work with a Launcher compatible with
        /// Colab launcher
        /// </summary>
        public static void Register() {

            //Should not be called directly
            Handle.GET("/hellocontext/master", () =>
            {
                return Master.Current;
            });

            //A non context based page
            Handle.GET("/hellocontext", (Request req) => 
            {
                //Master m = (Master)Self.GET(String.Format("/hellocontext/master"));
                //Use above if no login check is needed, 
                return ColabX.BuildOn(req, "/colab_hellocontext/master", (Master master) =>
                {
                    return Master.SimpleApplication<HelloContextMainPage>();
                });
            });

            Handle.GET("/hellocontext/context/{?}", (Request req, string id) =>
            {
                return ColabX.BuildOn(req, "/colab_hellocontext/master", (Master master) =>
                { 
                    //Login check is done above, you still might need to check if user
                    //is allowed to access the given context
                    var context = ContextHandler.GetContext(id);
                    if (context != null)
                    {
                        var hello = HelloContextData.For(context);
                        if (hello != null)
                        {

                            return Master.SimpleApplication<HelloContextPage>(hello);
                        }
                        else
                        {
                            return Master.SimpleApplication<NoHelloContextPage>(context);
                        }
                    }
                    return Master.SimpleApplication<NotFound>();
                });
            });
        }

    }
}
