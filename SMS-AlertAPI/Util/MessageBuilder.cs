namespace SMS_AlertAPI.Util
{
    public class MessageBuilder
    {
        public string Type { get; set; }

        public MessageBuilder(string Type)
        {
            this.Type = Type;
        }

        public string GetMessage()
        {

            if(Type == "new_request")
            {
                return "Hello! Hola! We will notify you when your requested shoes are available. \n" +
                    "Hola! Le notificaremos cuando sus zapatos solicitados estén disponibles. \n" +
                    "Thank you! Gracias! \n" +
                    "LatinoShoes \n" +
                    "Sat/Sun - Sab/Domingo";
            }

            if(Type == "in_stock")
            {
                return "Hello! Hola! Your requested shoes are in stock, get them while they last! \n" +
                    "Hola! Tus zapatos solicitados están en stock, ¡consíguelos pronto! \n" +
                    "Thank you! Gracias! \n" +
                    "LatinoShoes \n" +
                    "Sat/Sun - Sab/Domingo";
            }

            return "No message was sent because \' Type \' was not set properly. \n" +
            "Types accepted: \' new_request \' and \' in_stock \' \n"; 

        }
    }
}
