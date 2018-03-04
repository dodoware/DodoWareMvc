using System;
using System.Runtime.Serialization;

namespace DodoWare.Mvc.Models.Base
{
    [Serializable]
    public abstract class DwException : Exception
    {
        internal DwException(string msg) : base(msg)
        {
        }

        protected DwException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        internal DwException(string msg, Exception cause) : base(msg, cause)
        {
        }
    }

    [Serializable]
    public class DwInputException : DwException
    {
        public string InputId { get; }

        internal DwInputException(string inputId, string msg) : base(msg)
        {
            InputId = inputId;
        }

        protected DwInputException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            InputId = info.GetString("InputId");
        }

        internal DwInputException(string inputId, string msg, Exception cause) : base(msg, cause)
        {
            InputId = inputId;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("InputId", InputId);
        }
    }

    [Serializable]
    public class DwLogicException : DwException
    {
        internal DwLogicException(string msg) : base(msg)
        {
        }
    
        internal DwLogicException(string msg, Exception cause) : base(msg, cause)
        {
        }
    }

    [Serializable]
    public class InvalidScenarioIdException : DwInputException
    {
        internal InvalidScenarioIdException(string id) : base(null, $"Invalid scenario ID '{id}'.")
        {
        }
    }
}
