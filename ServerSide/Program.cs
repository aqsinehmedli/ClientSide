using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Server:");


var server = new UdpClient(27001);

var remoteEndPoit = new IPEndPoint(IPAddress.Any, 0);


try
{
    while (true)
    {
        var bytes = server.Receive(ref remoteEndPoit);
        byte[] imageb = bytes;
        var imagePath = @"C:\Users\Ahmed_hb29\Desktop\images.jpg";

        using (var writefs = new FileStream(imagePath, FileMode.CreateNew))
        {
            writefs.Write(bytes, 0, bytes.Length);
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}