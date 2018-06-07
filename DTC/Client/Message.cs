
namespace QANT.DTC
{
    public partial class Client
    {
        public class Message
        {

            public Messages.Header Header { get; set; }

            public byte[] Packet { get; set; }

            public object Content { get; set; }


            public Message(Messages.Header header, byte[] packet, object content)
            {
                Header = header;
                Packet = packet;
                Content = content;
            }

        }
    }
}