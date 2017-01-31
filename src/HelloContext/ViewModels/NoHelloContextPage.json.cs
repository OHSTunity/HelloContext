using Colab.Public;
using Starcounter;
using System;
using System.Collections.Generic;
using System.Linq;
using Concepts.Ring1;

namespace Colab.HelloContext
{
    [NoHelloContextPage_json]
    partial class NoHelloContextPage : Page, IBound<Something>, IContextApp
    {
        /// <summary>
        /// This is the secret about a context app,
        /// it needs to return ContextId as a property
        /// </summary>
        public String ContextId
        {
            get
            {
                return DbHelper.GetObjectID(Data);
            }
        }

        public Boolean CanCreate => true; //Check rights to create a hellocontext here.

        void Handle(Input.Create input)
        {
            if (CanCreate)
            {
                Db.Transact(() =>
                {
                    new HelloContextData()
                    {
                        Context = Data,
                        Name = "MySuperData"
                    };
                });
                //Rerequest the current url will load a HelloContextPage for this context instead
                //now that data exist
                Master.SendCommand(ColabCommand.REREQUEST_URL);
            }
        }


    }
}