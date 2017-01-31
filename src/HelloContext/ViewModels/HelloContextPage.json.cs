using Colab.Public;
using Starcounter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Colab.HelloContext
{
    [HelloContextPage_json]
    partial class HelloContextPage : Page, IBound<HelloContextData>, IContextApp
    {
        /// <summary>
        /// This is the secret about a context app,
        /// it needs to return ContextId as a property
        /// </summary>
        public String ContextId
        {
            get
            {
                return DbHelper.GetObjectID(Data?.Context);
            }
        }

        public String OrganizerContextId => ContextId;

        public String HelloContextDataId => DbHelper.GetObjectID(Data);


    }
}