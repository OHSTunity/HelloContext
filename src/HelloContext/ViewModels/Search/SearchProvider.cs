using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;
using Colab.Public;

namespace Colab.HelloContext
{
    public class SearchProvider
    {
        public int Count(SearchQuery sq)
        {
            var count = 0;
            foreach (var act in SelectHellos(sq))
            {
                count++;
                if (count > 25)
                    return count;
            }
            return count;
        }

        public IEnumerable<HelloContextData> SelectHellos(SearchQuery sq)
        {
            foreach (var hello in _selectHellos(sq.Freetext))
            {
                //TODO: Filter/access control here
                yield return hello;
            }
        }

      
        protected QueryResultRows<HelloContextData> _selectHellos(string Key)
        {
            Key = this.PrepareLikeKey(String.IsNullOrEmpty(Key)?"":Key);
            return Db.SQL<HelloContextData>(
                    "SELECT d FROM Colab.HelloContext.HelloContextData d WHERE d.Name LIKE ?", Key);
        }

        protected string PrepareLikeKey(string Key)
        {
            return "%" + Key.Trim('%') + "%";
        }
    }
}