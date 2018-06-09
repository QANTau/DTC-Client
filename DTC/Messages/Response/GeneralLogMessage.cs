using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <inheritdoc />
        /// <summary>
        /// General Log Message
        /// </summary>
        public class GeneralLogMessage : JsonHeader
        {

            #region C++ Struct
            //char MessageText[128];
            #endregion

            public string MessageText { get; set; }

        }
    }
}
