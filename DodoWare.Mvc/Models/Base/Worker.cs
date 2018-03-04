using System;

namespace DodoWare.Mvc.Models.Base
{
    public abstract class Worker<TInput> : BaseWorker where TInput : Input
    {
        public TInput Input { get; set; }

        protected Worker(TInput input)
        {
            Input = input ?? throw new ArgumentNullException(nameof(input));
        }

        public void Go()
        {
            try
            {
                GoEx();
            }
            catch (DwInputException inputException)
            {
                InputError = inputException.Message;
                InputErrorId = inputException.InputId;
            }
            catch (Exception logicException)
            {
                LogicError = logicException.Message;
            }
        }

        protected abstract void GoEx();
    }
}
