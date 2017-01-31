using System;
using Starcounter;
using Colab.Public;
using Concepts.Ring1;

namespace Colab.HelloContext {
    /// <summary>
    /// Registers uri:s ready to be mapped into Colab Organizer
    /// Context aware and such
    /// </summary>
    internal static class OrganizerAPI {


        /// <summary>
        /// This is actually normal Handle.GET thats being mapped into
        /// organizer uris, just wrapped into functions for convenience
        /// Check ContextHandler for details
        /// </summary>
        public static void Register()
        {
            ContextHandler.OnContextMenuRequested((Something context) =>
            {
                var menu = new Menu();
                if (true) //&& TODO: Here is good to check access rights
                {
                    menu.Items.Add(new HelloContextMenuItem()
                    {
                        Data = context
                    });
                }
                return menu;
            });


            //Gets called if a new context is selected but ONLY if this app is the current app
            ContextHandler.OnContextSelected((Something context) =>
            {
                if (context != null)
                {
                    //Tell client to change URL, This one 
                    Master.SendCommand(ColabCommand.MORPH_URL, String.Format("/colab_hellocontext/context/{0}", DbHelper.GetObjectID(context)));
                }
            });
        }
    }
}
