namespace DodoWare.Mvc.Models.Base
{
    public class BaseWorker
    {
        public string InputError { get; internal set; }
        public string LogicError { get; internal set; }
        public string InputErrorId { get; internal set; }

        public bool HasError()
        {
            return (InputError != null || LogicError != null);
        }
    }
}
