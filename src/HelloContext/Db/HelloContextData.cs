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

namespace Colab.HelloContext
{
    /// <summary>
    /// 
    /// </summary>
    [Database]
    public class HelloContextData: Entity
    {
        public HelloContextData()
        {
        }

        public static HelloContextData For(Entity context)
        {
            return Db.SQL<HelloContextData>("SELECT a FROM Colab.HelloContextData.MyHelloContext a WHERE a.Context=?", context).First;
        }
        
        /// <summary>
        /// Context  
        /// </summary>
        public Entity Context;


        ///More data
        public new String Name { get; set; }
        public String Description { get; set; }
        
    }
}
