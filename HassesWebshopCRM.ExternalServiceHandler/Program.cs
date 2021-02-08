namespace HassesWebshopCRM.ExternalServiceHandler
{
    class Program
    {

        static void Main(string[] args)
        {
            SendOrderToOldOrderSystem();            
        }

        private static void SendOrderToOldOrderSystem()
        {
            //Todo
            //Get order from WebshopCRM system when any order in placed
            //Send order to old order system 
            //if no error occuered then update order status in WebshopCRM 
            //If oder update return fail then lock the order so that order can not be transfer again 
        }
    }
}
