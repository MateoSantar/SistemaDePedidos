using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Views;
using Models;

namespace Controllers
{
    class ClientController
    {
        
        public ClientController()
        {
        }

        public Client LoadClient()
        {
            Client temp = ClientView.LoadClient();
            return temp;
        }

        public void ShowClient(Client c)
        {
            ClientView.ShowClient(c);
        }


    }
}
