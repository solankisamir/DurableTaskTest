namespace DurableTaskTest
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Class defining exception in RestoreOrchestration due to Validation Failures
    /// of Input Provided.
    /// </summary>
    [Serializable]
    public class SerializableException : Exception
    {
        public SerializableException(string message)
            : base(message)
        {
        }

        public SerializableException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected SerializableException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}