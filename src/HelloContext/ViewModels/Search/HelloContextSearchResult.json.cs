using Colab.Public;
using Starcounter;

namespace Colab.HelloContext
{
    [HelloContextSearchResult_json]
    partial class HelloContextSearchResult : SearchItem, IBound<HelloContextData>
    {
        private void Handle(Input.Activate inpute)
        {
            Master.SendCommand(ColabCommand.MORPH_URL, $"/colab_hellocontext/context/{DbHelper.GetObjectID(Data)}");
        }
    }
}