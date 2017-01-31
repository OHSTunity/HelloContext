using Colab.Public;
using Starcounter;
using System;
using Concepts.Ring1;

namespace Colab.HelloContext
{
    [HelloContextMenuItem_json]
    partial class HelloContextMenuItem : ContextMenuItem, IBound<Something>
    {
        /// <summary>
        /// Decides if it will be shown in menu or directly
        /// Directly(Priority true) should be activated if it exists for this context
        /// </summary>
        public Boolean PriorityCB => (HelloContextData.For(Data) != null);

        public new String Label => (HelloContextData.For(Data) != null) ? "HelloContext" : "Create HelloContext";

        private void Handle(Input.Tap input)
        {
            if (HelloContextData.For(Data) == null)
            {
                Db.Transact(() =>
                {
                    new HelloContextData()
                    {
                        Context = Data
                    };
                });
            }
             Master.SendCommand(ColabCommand.MORPH_URL, "/colab_hellocontext/context/" + DbHelper.GetObjectID(Data));
        }
    }
}