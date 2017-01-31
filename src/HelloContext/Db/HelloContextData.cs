/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/Project/TunityProjectEventInfo.cs#4 $
      $DateTime: 2009/11/26 13:39:19 $
      $Change: 27500 $
      $Author: davros $
      =========================================================
*/

using System;
using System.Linq;
using System.Collections.Generic;
using Starcounter;
using Concepts.Ring1;

namespace Colab.HelloContext
{
    /// <summary>
    /// 
    /// </summary>
    [Database]
    public class HelloContextData: Something
    {
        public HelloContextData()
        {
        }

        public static HelloContextData For(Something context)
        {
            return Db.SQL<HelloContextData>("SELECT a FROM Colab.HelloContextData.MyHelloContext a WHERE a.Context=?", context).First;
        }
        
        /// <summary>
        /// Context  
        /// </summary>
        public Something Context;


        //More data here
        
    }
}
