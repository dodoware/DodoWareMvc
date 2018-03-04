using System;

namespace DodoWare.Mvc.Test
{
    public abstract class PostTest
    {
        public string Resource { get; }
        public DodoWareData Data { get; }
        public bool ExpectModalError { get; }

        protected PostTest(string resource, DodoWareData data, bool expectModalError)
        {
            Resource = resource;
            Data = data;
            ExpectModalError = expectModalError;
        }

        public void Go()
        {
            var dodoWareResult = DodoWareWeb.Singleton.Post(Resource, Data);
            if (dodoWareResult.ModalError == null && ExpectModalError) throw new Exception("A modal error was expected.");
            if (dodoWareResult.ModalError != null && !ExpectModalError) throw new Exception("An unexpected modal error occurred.");
            HandleResult(dodoWareResult);
        }

        protected abstract void HandleResult(DodoWareResult xmlResult);
    }
}
