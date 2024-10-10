


using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Client:");

var client = new UdpClient();

var endPoint = new IPEndPoint(IPAddress.Loopback, 27001);

try
{
    while (true)
    {
        var imagePath = @"C:\Users\Ahmed_hb29\Desktop\images.jpg";
        using (var readFs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
        {
            var bytes = new byte[1024];
            var len = 0;


            while ((len = readFs.Read(bytes, 0, bytes.Length)) > 0)
            {
                client.Send(bytes, bytes.Length, endPoint);
                Console.WriteLine("Image sending...");
            }
        }
    }
   

}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
}