using Colab.Public;
using Starcounter;
using System;

namespace Colab.HelloContext
{
    [HelloContextMenuItem_json]
    partial class HelloContextMenuItem : ContextMenuItem, IBound<Entity>
    {
        /// <summary>
        /// Decides if it will be shown in menu or directly
        /// Directly(Priority true) should be activated if it exists for this context
        /// </summary>
        public Boolean PriorityCB
        {
            get
            {
                return HelloContextData.For(Data) != null;
            }
        }

        private void Handle(Input.Tap input)
        {
          //   Master.SendCommand(ColabCommand.MORPH_URL, "/colab_hellocontext/myhellocontext/" + DbHelper.GetObjectID(Data));
        }
    }
}